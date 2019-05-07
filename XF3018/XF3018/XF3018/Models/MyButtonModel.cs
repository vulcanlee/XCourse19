using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XF3018.Models
{
    public class MyButtonModel : INotifyPropertyChanged
    {
        public Color BackgroundColor { get; set; }
        public Color ButtonLabelColor { get; set; }
        public string ButtonLabel { get; set; }
        public DelegateCommand MyButtonCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
