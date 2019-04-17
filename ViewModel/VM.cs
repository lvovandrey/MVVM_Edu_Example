using MVVMexample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMexample.ViewModel
{
    class VM : INotifyPropertyChanged
    {

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
            _levels = new ObservableCollection<Level>();
            _levels.Add(new Level() { Video = new Video() { Title = "sdfsadfs" }, Name = "sdfasdfnsdf" });
            _levels.Add(new Level() { Video = new Video() { Title = "sdfsadfs" }, Name = "sdfasdfnsdf" });
            _levels.Add(new Level() { Video = new Video() { Title = "sdfsadfs" }, Name = "sdfasdfnsdf" });

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
