using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF5002.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;
    using ZXing.Mobile;

    public class ScanningPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsAnalyzing { get; set; }
        public bool IsScanning { get; set; }
        public ZXing.Result ScanResult { get; set; }
        public DelegateCommand ScanResultCommand { get; set; }
        private readonly INavigationService navigationService;

        public ScanningPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            IsAnalyzing = true;
            IsScanning = true;
            MobileBarcodeScanningOptions mobileBarcodeScanningOptions = new MobileBarcodeScanningOptions();

            ScanResultCommand = new DelegateCommand(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsAnalyzing = false;
                    IsScanning = false;

                    var fooPara = new NavigationParameters();
                    fooPara.Add("Result", ScanResult.Text);
                    // 回到上頁，並且把掃描結果帶回去
                    navigationService.GoBackAsync(fooPara);
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
