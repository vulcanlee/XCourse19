using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3024.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand 圖片大小與填滿Command { get; private set; }
        public DelegateCommand 圖片資源Command { get; private set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            圖片大小與填滿Command = new DelegateCommand(圖片大小與填滿);
            圖片資源Command = new DelegateCommand(圖片資源);
        }
        private async void 圖片資源()
        {
            await navigationService.NavigateAsync("IndependentImagePage");
        }

        private async void 圖片大小與填滿()
        {
            await navigationService.NavigateAsync("AspectPage");
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
