using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMexample.Model;

namespace MVVMexample.ViewModel
{
    public class VideoVM: INotifyPropertyChanged
    {
        private Video _video;

        public VideoVM(Video video)
        {
            this._video = video;
        }

        public string Title { get { return _video.Title; } set { _video.Title = value; } }

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
