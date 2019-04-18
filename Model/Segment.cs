using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMexample.Model
{
    public class Segment : INotifyPropertyChanged
    {

        [NotMapped]
        private TimeSpan _time { get; set; }

        public TimeSpan Time
        {
            get { return _time; }
            set { _time = value; OnPropertyChanged("Time"); }
        }

        public Segment(TimeSpan time)
        {
            Time = time;
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
