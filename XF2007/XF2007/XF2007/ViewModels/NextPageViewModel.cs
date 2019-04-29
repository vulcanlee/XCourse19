using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF2007.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class NextPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand 回到上一頁Command { get; set; }
        public string YourName { get; set; }
        public string YourAccount { get; set; }
        private readonly INavigationService navigationService;

        public NextPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            回到上一頁Command = new DelegateCommand(() =>
            {
                NavigationParameters para = new NavigationParameters();
                para.Add("NextName", "我從上一頁回來了");
                navigationService.GoBackAsync(para);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            YourName = parameters.GetValue<string>("Name");
            YourAccount = parameters.GetValue<string>("Account");
            (string barAccount, string barName) = parameters.GetValue<(string, string)>("UserInputByCSharp7");
            (string fooAccount, string fooName) = parameters.GetValue<Tuple<string, string>>("UserInputByTupleType");
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
