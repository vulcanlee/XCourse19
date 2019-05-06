using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF3006.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MDPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<string> NavigateCommand { get; set; }
        private readonly INavigationService navigationService;

        public MDPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            NavigateCommand = new DelegateCommand<string>(x =>
            {
                navigationService.NavigateAsync($"/MDPage/NaviPage/{x}");
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
