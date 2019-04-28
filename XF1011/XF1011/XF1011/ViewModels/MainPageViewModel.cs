using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF1011.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string YourAccount { get; set; }
        public string YourAnswer { get; set; }
        public DelegateCommand 登入Command { get; set; }
        public bool Button登入CommandEnable { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            登入Command = new DelegateCommand(() =>
            {
                YourAnswer = YourAccount;
            }, ()=>
            {
                return Button登入CommandEnable;
            });
        }

        public void OnYourAccountChanged()
        {
            if(YourAccount?.Length>6)
            {
                Button登入CommandEnable = true;
            }
            else
            {
                Button登入CommandEnable = false;
            }
            登入Command.RaiseCanExecuteChanged();
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
