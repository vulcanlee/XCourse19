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
    using System.IO;
    using Newtonsoft.Json;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class UserModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
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

                    string rootPath = Path.Combine(FileSystem.AppDataDirectory, "MyFolder"); 
                    if(Directory.Exists(rootPath) == false)
                    {
                        Directory.CreateDirectory(rootPath);
                    }
                    string filename = Path.Combine(rootPath, "MyUser.txt");

                    UserModel userModel = new UserModel()
                    {
                        Account = Account,
                        Password = Password,
                    };
                    string content = JsonConvert.SerializeObject(userModel);
                    File.WriteAllText(filename, content);
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
            string rootPath = FileSystem.AppDataDirectory;
            string filename = Path.Combine(rootPath, "MyFolder", "MyUser.txt");
            if (File.Exists(filename) == true)
            {
                string content = File.ReadAllText(filename);
                UserModel userModel = JsonConvert.DeserializeObject<UserModel>(content);
                if (userModel != null)
                {
                    Account = userModel.Account;
                    Password = userModel.Password;
                }
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
