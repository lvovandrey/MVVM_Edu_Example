using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMexample.Model
{
    //[ComplexType]
    public class Video : INotifyPropertyChanged
    {
        public int Id { get; set; }

        [NotMapped]
        private string _title { get; set; }

        public string Title { get { return _title; }
            set { _title = value; }
        }
//        OnPropertyChanged("Title");


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
