using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2005.ViewModels
{
    using System.ComponentModel;
    using System.Diagnostics;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GoNextCommand { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GoNextCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("NextPage");
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  主頁面     OnNavigatedFrom");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  主頁面     OnNavigatedTo");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Debug.WriteLine($"------>>>  主頁面     OnNavigatingTo");
        }
    }
}
