using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XF3028.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Color FavoriteColor { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
