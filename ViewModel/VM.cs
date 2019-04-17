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
            //_levels.Add(new Level() { Video = new Video() { Title = "sdfsadfs" }, Name = "sdfasdfnsdf" });
            //_levels.Add(new Level() { Video = new Video() { Title = "sdfsadfs" }, Name = "sdfasdfnsdf" });
            //_levels.Add(new Level() { Video = new Video() { Title = "sdfsadfs" }, Name = "sdfasdfnsdf" });


             _levels = new ObservableCollection<Level>();
            using (Context context = new Context())
            {
                var temp = Repository.Select<Level>().Where(c => true==true).ToList();

                if (context.Levels.Count() > 0)
                {
                    foreach (var item in temp)
                    {
                        _levels.Add(item);
                    }
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
                      _levels.Insert(0, l);

                     
                          context.Levels.Add(l);
                          context.SaveChanges();

                          foreach(Level vl in context.Levels)
                          { }

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
//                      context.Levels.First() = _levels.First() ;
                      context.Entry(_levels.First()).State = EntityState.Modified;
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
