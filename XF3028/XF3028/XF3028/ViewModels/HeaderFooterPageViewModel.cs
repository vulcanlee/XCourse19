using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF3028.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3028.Repositories;

    public class HeaderFooterPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PersonWithButtonViewModel> MyData { get; set; } = new ObservableCollection<PersonWithButtonViewModel>();
        public ObservableCollection<PersonWithButtonViewModel> myItemList { get; set; } = new ObservableCollection<PersonWithButtonViewModel>();
        private readonly INavigationService navigationService;

        public HeaderFooterPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            MyData = PersonRepository.SampleWithButtonViewModel();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
