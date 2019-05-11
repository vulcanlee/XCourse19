using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF4027.ViewModels
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public DelegateCommand 下一頁Command { get; private set; }
        public DelegateCommand 各自動畫Command { get; private set; }
        public DelegateCommand 串接動畫Command { get; private set; }
        public Func<Task> 各自動畫Delegate;
        public Func<Task> 串接動畫Delegate;
        public Func<Task> 頁面消失動畫Delegate;
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            下一頁Command = new DelegateCommand(async () =>
            {
                await 頁面消失動畫Delegate();
                await Task.Delay(1000);
                await navigationService.NavigateAsync("NewPage", null, null, false);
            });
            各自動畫Command = new DelegateCommand(async () =>
            {
                await 各自動畫Delegate();
            });
            串接動畫Command = new DelegateCommand(async () =>
            {
                await 串接動畫Delegate();
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
