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

    public class VariRowHeithtPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MyItemViewModel> MyItemList { get; set; } = new ObservableCollection<MyItemViewModel>();
        public MyItemViewModel MyItemListSelected { get; set; }
        public DelegateCommand 可變列高Command { get; private set; }
        public DelegateCommand 固定列高Command { get; private set; }
        private readonly INavigationService navigationService;

        public VariRowHeithtPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            MyItemList = MyItemRepository.SampleLongViewModel();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
