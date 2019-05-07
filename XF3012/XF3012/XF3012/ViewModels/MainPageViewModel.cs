using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3012.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool Label1Visible { get; set; } = true;
        public bool Label2Visible { get; set; } = true;
        public string Btn1Text { get; set; }
        public string Btn2Text { get; set; }
        public DelegateCommand Btn1Command { get; set; }
        public DelegateCommand Btn2Command { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Btn1Text = "隱藏 文字1";
            Btn2Text = "隱藏 文字2";
            Btn1Command = new DelegateCommand(() =>
            {
                if (Btn1Text == "隱藏 文字1")
                {
                    Btn1Text = "顯示 文字1";
                    Label1Visible = false;
                }
                else
                {
                    Btn1Text = "隱藏 文字1";
                    Label1Visible = true;
                }
            });
            Btn2Command = new DelegateCommand(() =>
            {
                if (Btn2Text == "隱藏 文字2")
                {
                    Btn2Text = "顯示 文字2";
                    Label2Visible = false;
                }
                else
                {
                    Btn2Text = "隱藏 文字2";
                    Label2Visible = true;
                }
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
