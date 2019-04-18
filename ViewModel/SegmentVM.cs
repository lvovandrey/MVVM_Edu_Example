using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMexample.ViewModel
{
    public class SegmentVM : INotifyPropertyChanged
    {
        private Segment _segment;

        public VideoVM(SegmentVM segment)
        {
            this._video = video;
        }

        public string Title
        {
            get { return _video.Title; }
            set { _video.Title = value; OnPropertyChanged("Title"); }
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
