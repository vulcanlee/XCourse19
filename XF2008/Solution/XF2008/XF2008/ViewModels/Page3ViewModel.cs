using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF2008.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class Page3ViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GoHomeCommand { get; set; }
        public string Message { get; set; }
        private readonly INavigationService navigationService;

        public Page3ViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GoHomeCommand = new DelegateCommand(() =>
            {
                navigationService.GoBackToRootAsync();
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                Message = parameters.GetValue<string>("Para");
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
