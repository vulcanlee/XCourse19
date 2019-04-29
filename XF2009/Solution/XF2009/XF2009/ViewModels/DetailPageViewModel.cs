using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF2009.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class DetailPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand GotoEditPageCommand { get; set; }

        private readonly INavigationService navigationService;

        public DetailPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            GotoEditPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("EditPage", null, true);
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
