using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XF3028.ViewModels
{
    public class MyItemViewModel : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
