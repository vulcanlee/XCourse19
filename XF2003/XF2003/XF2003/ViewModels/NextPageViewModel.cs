using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF2003.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class NextPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand 回到上一頁Command { get; set; }
        private readonly INavigationService navigationService;

        public NextPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            回到上一頁Command = new DelegateCommand(() =>
            {
                navigationService.GoBackAsync();
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
        }

    }
}
