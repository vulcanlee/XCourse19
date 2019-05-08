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

    public class ItemClickPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PersonWithButtonViewModel> MyData { get; set; } = new ObservableCollection<PersonWithButtonViewModel>();
        public PersonWithButtonViewModel MyDataSelected { get; set; }
        public DelegateCommand MyDataClickedCommand { get; private set; }
        private readonly INavigationService navigationService;

        public ItemClickPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            MyData = PersonRepository.SampleWithButtonViewModel();
            MyDataClickedCommand = new DelegateCommand(MyDataClicked);
        }
        private async void MyDataClicked()
        {
            await navigationService.NavigateAsync("Basic1Page");
            // 若沒有加入底下這行，則當回到這個頁面的時候，這筆一樣有被選取
            MyDataSelected = null;
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
