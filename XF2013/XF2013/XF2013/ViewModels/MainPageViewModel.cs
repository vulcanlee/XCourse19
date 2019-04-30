using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2013.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF2013.Events;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public DelegateCommand GoNextCommand { get; set; }
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            GoNextCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("NextPage");
            });
            eventAggregator.GetEvent<YourAnswerEvent>().Subscribe(x =>
            {
                Title = x.Answer;
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
