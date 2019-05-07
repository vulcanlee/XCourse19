using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3018.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;
    using XF3018.Models;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public MyButtonModel DeleteButton { get; set; }
        public MyButtonModel SaveButton { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            DeleteButton = new MyButtonModel()
            {
                BackgroundColor = Color.Red,
                ButtonLabelColor = Color.LightYellow,
                ButtonLabel = "刪除",
                MyButtonCommand = new DelegateCommand(() =>
                {
                    Title = "你按下了 刪除 按鍵";
                }),
            };
            SaveButton = new MyButtonModel()
            {
                BackgroundColor = Color.LightGreen,
                ButtonLabelColor = Color.Black,
                ButtonLabel = "儲存",
                MyButtonCommand = new DelegateCommand(() =>
                {
                    Title = "你按下了 儲存 按鍵";
                }),
            };
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
