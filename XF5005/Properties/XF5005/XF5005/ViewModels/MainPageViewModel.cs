using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF5005.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Account { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsShowErrorMessage { get; set; }
        public DelegateCommand LoginCommand { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            LoginCommand = new DelegateCommand(() =>
            {
                if (Account == "user1" && Password == "password1")
                {
                    ErrorMessage = "";
                    IsShowErrorMessage = false;

                    App.Current.Properties.Add("Account", Account);
                    App.Current.Properties.Add("Password", Password);
                    App.Current.SavePropertiesAsync();
                }
                else
                {
                    ErrorMessage = "帳號或密碼錯誤，重新輸入!!";
                    IsShowErrorMessage = true;
                }
            });

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (App.Current.Properties.ContainsKey("Account"))
            {
                Account = App.Current.Properties["Account"].ToString();
            }
            if (App.Current.Properties.ContainsKey("Password"))
            {
                Password = App.Current.Properties["Password"].ToString();
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
