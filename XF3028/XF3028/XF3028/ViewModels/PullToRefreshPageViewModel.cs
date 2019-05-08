using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF3028.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3028.Repositories;

    public class PullToRefreshPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PersonWithButtonViewModel> MyData { get; set; } = new ObservableCollection<PersonWithButtonViewModel>();
        public bool IsBusy { get; set; }
        public DelegateCommand 更新資料Command { get; private set; }
        private readonly INavigationService navigationService;

        public PullToRefreshPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            //MyData = PersonRepository.SampleWithButtonViewModel();
            更新資料Command = new DelegateCommand(更新資料);
        }
        private async void 更新資料()
        {
            await 從網路取得最新資料();
            IsBusy = false;
        }

        public async Task 從網路取得最新資料()
        {
            await Task.Delay(3000);
            var fooMyData = PersonRepository.SampleWithButtonViewModel();
            foreach (var item in fooMyData)
            {
                MyData.Add(item);
            }
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
