using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3005.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool 是否啟用 { get; set; }
        private readonly INavigationService navigationService;
        public DelegateCommand 切換到新頁面Command { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            切換到新頁面Command = new DelegateCommand(On切換到新頁面, Can切換到新頁面);
        }

        private bool Can切換到新頁面()
        {
            return 是否啟用;
        }

        private void On切換到新頁面()
        {
            navigationService.NavigateAsync("Page1");
        }
        public void On是否啟用Changed()
        {
            切換到新頁面Command.RaiseCanExecuteChanged();
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
