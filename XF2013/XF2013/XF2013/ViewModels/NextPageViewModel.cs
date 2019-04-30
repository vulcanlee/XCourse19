using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF2013.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF2013.Events;

    public class NextPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string YourAnswer { get; set; }
        public DelegateCommand PublishCommand { get; set; }
        private readonly INavigationService navigationService;
        private readonly IEventAggregator eventAggregator;

        public NextPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            this.navigationService = navigationService;
            this.eventAggregator = eventAggregator;
            PublishCommand = new DelegateCommand(() =>
            {
                eventAggregator.GetEvent<YourAnswerEvent>().Publish(new YourAnswerPayload()
                {
                    Answer = YourAnswer
                });
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
