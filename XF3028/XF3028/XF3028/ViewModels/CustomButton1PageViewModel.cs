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

    public class CustomButton1PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PersonWithButtonViewModel> MyData { get; set; } = new ObservableCollection<PersonWithButtonViewModel>();
        public PersonWithButtonViewModel MyDataSelected { get; set; }
        public DelegateCommand<PersonWithButtonViewModel> 進行互動Command { get; private set; }
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;

        public CustomButton1PageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            MyData = PersonRepository.SampleWithButtonViewModel();

            進行互動Command = new DelegateCommand<PersonWithButtonViewModel>(進行互動);
        }

        private async void 進行互動(PersonWithButtonViewModel obj)
        {
            await dialogService.DisplayAlertAsync("請確定", $"您選取了 {obj.Name}", "確定");
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
