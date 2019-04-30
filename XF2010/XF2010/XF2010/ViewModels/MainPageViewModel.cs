using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2010.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF2010.Services;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Message { get; set; }  
        private readonly INavigationService navigationService;
        private readonly ISayHello sayHello;

        public DelegateCommand GetSystemCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService, ISayHello sayHello)
        {
            this.navigationService = navigationService;
            this.sayHello = sayHello;
            GetSystemCommand = new DelegateCommand(() =>
            {
                Message = sayHello.Hello();
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
