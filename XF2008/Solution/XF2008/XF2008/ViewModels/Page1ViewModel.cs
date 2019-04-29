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
    public class Page1ViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GoPage2Command { get; set; }
        public string Message { get; set; }
        private readonly INavigationService navigationService;

        public Page1ViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GoPage2Command = new DelegateCommand(() =>
            {
                NavigationParameters para = new NavigationParameters();
                para.Add("Para", "來自Page1的訊息");
                navigationService.NavigateAsync("Page2", para);
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
