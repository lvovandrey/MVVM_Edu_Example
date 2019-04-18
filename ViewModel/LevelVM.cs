using MVVMexample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMexample.ViewModel
{
    class LevelVM : INotifyPropertyChanged
    {
        private Level _level;
        private Video _video { get { return _level.Video; } set { _level.Video = value; } }

        public LevelVM(Level level)
        {
            _level = level;
            _videovm = new VideoVM(_level.Video);  //ВОт как надо - надо опираться на единую модель и не создавать новые представления в геттерах!!!
        }

        public string Name
        {
            get { return _level.Name; }
            set { _level.Name = value; OnPropertyChanged("Name"); }
        }

        /// <summary>
        /// ВОТ !!! Вот как нада! 
        /// </summary>
        private VideoVM _videovm { get; set; } 
        public VideoVM Video
        {
            get {
                return _videovm;
            } // ЕСЛИ СЛОЖНАЯ ВЛОЖЕННАЯ СТРУКТУРА - то ее не присваиваем! А?
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
