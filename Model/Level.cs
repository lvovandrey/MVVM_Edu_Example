﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMexample.Model
{
    public class Level : INotifyPropertyChanged
    {
        private string _name { get; set; }
        private Video _video { get; set; }

        public string Name { get { return _name; } set { _name = value; OnPropertyChanged("Name"); } }
        public Video Video { get { return _video; } set { _video = value; OnPropertyChanged("Video"); } }


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
