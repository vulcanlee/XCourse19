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

    public class CustomButtonPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PersonViewModel> MyData { get; set; } = new ObservableCollection<PersonViewModel>();
        public PersonViewModel MyDataSelected { get; set; }
        public DelegateCommand<PersonViewModel> 進行互動Command { get; private set; }

        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;

        public CustomButtonPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            MyData = PersonRepository.SampleViewModel();

            進行互動Command = new DelegateCommand<PersonViewModel>(進行互動);
        }
        private async void 進行互動(PersonViewModel obj)
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
