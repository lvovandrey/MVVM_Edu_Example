using MVVMexample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMexample.ViewModel
{
    class VM : INotifyPropertyChanged
    {
        Context context;

        private ObservableCollection<Level> _levels { get; set; }
        private ObservableCollection<LevelVM> _levelsvm { get; set; }

        public ObservableCollection<LevelVM> LevelVMs
        {
            get
            {
                _levelsvm = new ObservableCollection<LevelVM>(from l in _levels select new LevelVM(l));
                return _levelsvm;
            }
        }


        private LevelVM _SelectedLevelVM;
        public LevelVM SelectedLevelVM
        {
            get
            { return _SelectedLevelVM; }
            set
            {
                _SelectedLevelVM = value;
                OnPropertyChanged("SelectedLevelVM");
            }

        }

        public VM()
        {
            context = new Context();
            _levels = new ObservableCollection<Level>();
            _levels = new ObservableCollection<Level>();
            using (Context context = new Context())
            {


                var levels = context.Levels.Join(context.Videos, // второй набор
                p => p.VideoId, // свойство-селектор объекта из первого набора
                c => c.Id, // свойство-селектор объекта из второго набора
                (p, c) => new // результат
                {
                levelId = p.Id,
                vidId = p.VideoId,
                Name = p.Name,
                Title = c.Title,
               });

                foreach (var p in levels)
                {
                    Level l = new Level()
                    {
                        Name = p.Name,
                        Id = p.levelId,
                        VideoId = p.vidId,
                        Video = new Video { Title = p.Title,Id=p.vidId} };
                       _levels.Add(l);
                }

            }
        }



        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Level l = new Level();
                      l.Name = "New Book";
                      l.Video = new Video() { Title = "dsdn" };
                      _levels.Add(l);
                      context.Levels.Add(l);
                      context.SaveChanges();

                      OnPropertyChanged("LevelVMs");
                     
                  }));
            }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      foreach(Level l in _levels)
                      {
                          context.Entry(l).State = EntityState.Modified;
                          context.Entry(l.Video).State = EntityState.Modified;
                      }
                     
                      context.SaveChanges();
                      foreach (Level vl in context.Levels)
                      { }
                      foreach (Level vl in _levels)
                      { }
                      OnPropertyChanged("LevelVMs");

                  }));
            }
        }



        #region mvvm
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
