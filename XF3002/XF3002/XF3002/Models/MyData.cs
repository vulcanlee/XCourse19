using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XF3002.Models
{
    public class MyData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public int OrderId { get; set; }
    }
}
