using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3013.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Color> ColorList { get; set; } = new ObservableCollection<Color>();
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ColorList.Add(Color.Aqua);
            ColorList.Add(Color.Blue);
            ColorList.Add(Color.Fuchsia);
            ColorList.Add(Color.Silver);
            ColorList.Add(Color.Maroon);
            ColorList.Add(Color.Orange);
            ColorList.Add(Color.Purple);
            ColorList.Add(Color.Teal);
            ColorList.Add(Color.Red);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
