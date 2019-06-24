using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF6005.ViewModels
{
    using System.ComponentModel;
    using System.IO;
    using Newtonsoft.Json;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService navigationService;
        public string Account { get; set; }
        public string Password { get; set; }
        public MyUser LoginUser { get; set; }
        public DelegateCommand LoginCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            LoginCommand = new DelegateCommand(OnLoginCommand);
        }

        private void OnLoginCommand()
        {
            // 將使用者輸入的資料，建立一個 MyUser 物件
            MyUser myUser = new MyUser();
            myUser.Account = Account;
            myUser.Password = Password;

            // 將該 .NET 物件(myUser) 序列化成為 JSON
            string json = JsonConvert.SerializeObject(myUser);

            // 建立要寫入檔案的絕對路徑位置
            string path = FileSystem.AppDataDirectory;
            string filename = Path.Combine(path, "MyUser.json");
            // 將該 JSON 文字寫入到指定檔案內
            File.WriteAllText(filename, json);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            // 建立要寫入檔案的絕對路徑位置
            string path = FileSystem.AppDataDirectory;
            string filename = Path.Combine(path, "MyUser.json");

            // 將該 JSON 文字從指定檔案讀取出來
            string json = File.ReadAllText(filename);

            // 將此 JSON 反序列化成為 .NET 物件 (myUser)
            MyUser myUser = JsonConvert.DeserializeObject<MyUser>(json);

            // 從 .NET 物件中把相關資料指定資料綁定的屬性上
            Account = myUser.Account;
            Password = myUser.Password;
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
