using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF3030.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using XF3030.Models;

    public class DetailPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public OpenSpaceItem OpenSpaceItemSelected { get; set; }
        public HtmlWebViewSource HtmlSource { get; set; }
        private readonly INavigationService _navigationService;
        public DelegateCommand MakePhoneCallCommand { get; set; }
        public DelegateCommand OpenWebCommand { get; set; }
        public DelegateCommand SendMailCommand { get; set; }
        public DelegateCommand ShowMapCommand { get; set; }
        public DetailPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MakePhoneCallCommand = new DelegateCommand(() =>
            {
                try
                {
                    PhoneDialer.Open(OpenSpaceItemSelected.連絡電話);
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            });
            OpenWebCommand = new DelegateCommand(() =>
            {
                try
                {
                    Device.OpenUri(new Uri(OpenSpaceItemSelected.官方網站));
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            });
            SendMailCommand = new DelegateCommand(async () =>
            {
                try
                {
                    var message = new EmailMessage
                    {
                        Subject = "",
                        Body = "",
                        To = new List<string>() { OpenSpaceItemSelected.聯絡email },
                        //Cc = ccRecipients,
                        //Bcc = bccRecipients
                    };
                    await Email.ComposeAsync(message);
                }
                catch (Exception ex)
                {
                    // Some other exception occured
                }
            });
            ShowMapCommand = new DelegateCommand(() =>
            {
                string url = "";
                string address = $"{OpenSpaceItemSelected.座標緯度},{OpenSpaceItemSelected.座標經度}";

                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        url = String.Format("http://maps.apple.com/maps?q={0}", address);
                        break;
                    case Device.Android:
                        url = String.Format("http://maps.google.com/maps?q={0}", address);
                        break;
                    default:
                        break;
                }
                Device.OpenUri(new Uri(url));
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Item"))
            {
                OpenSpaceItemSelected = parameters["Item"] as OpenSpaceItem;

                HtmlSource = new HtmlWebViewSource();
                HtmlSource.Html = OpenSpaceItemSelected.空間資訊;
            }
        }
    }
}
