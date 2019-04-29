using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2007.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GoNextCommand { get; set; }
        private readonly INavigationService navigationService;
        public string Name { get; set; }
        public string Account { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GoNextCommand = new DelegateCommand(() =>
            {
                NavigationParameters para = new NavigationParameters();
                para.Add("UserInputByCSharp7", (Account: Account, Name: Name));
                para.Add("UserInputByTupleType", Tuple.Create(Account, Name));
                para.Add("Name", Name);
                para.Add("Account", Account);
                navigationService.NavigateAsync("NextPage", para);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if(parameters.GetNavigationMode() == NavigationMode.Back)
            {
                Account = parameters.GetValue<string>("NextName");
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
