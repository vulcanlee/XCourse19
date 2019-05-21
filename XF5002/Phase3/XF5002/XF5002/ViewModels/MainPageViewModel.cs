using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF5002.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string ScanningResult { get; set; }
        public string InputQRCode { get; set; }
        public DelegateCommand StartCommand { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            StartCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("ScanningPage");
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if(parameters.GetNavigationMode() == NavigationMode.Back)
            {
                var result = parameters.GetValue<string>("Result");
                if(string.IsNullOrEmpty(result)==false)
                {
                    ScanningResult = result;
                }
            }
        }

    }
}
