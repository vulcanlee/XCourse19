using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2008.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GoPage1Command { get; set; }
        public DelegateCommand GoDeeplyPage3Command { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GoPage1Command = new DelegateCommand(() =>
            {
                NavigationParameters para = new NavigationParameters();
                para.Add("Para", "來自主畫面的訊息");
                navigationService.NavigateAsync("Page1", para);
            });
            GoDeeplyPage3Command = new DelegateCommand(() =>
            {
                NavigationParameters paraM = new NavigationParameters();
                paraM.Add("Para", "@來自主畫面的訊息");
                NavigationParameters para1 = new NavigationParameters();
                para1.Add("Para", "@來自Page1的訊息");
                NavigationParameters para2 = new NavigationParameters();
                para2.Add("Para", "@來自Page2的訊息");
                string deepPara = $"Page1{paraM.ToString()}/Page2{para1.ToString()}/Page3{para2.ToString()}";
                navigationService.NavigateAsync(deepPara);
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
