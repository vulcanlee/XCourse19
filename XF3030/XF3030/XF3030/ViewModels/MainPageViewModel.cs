using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3030.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3030.Models;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<OpenSpaceItem> AllItems { get; set; }
        public OpenSpaceItem OpenSpaceItemSelected { get; set; }
        public ObservableCollection<OpenSpaceItem> OpenSpaceItems { get; set; } = new ObservableCollection<OpenSpaceItem>();
        public DelegateCommand ItemClickCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ItemClickCommand = new DelegateCommand(() =>
            {
                var fooPara = new NavigationParameters();
                fooPara.Add("Item", OpenSpaceItemSelected);
                _navigationService.NavigateAsync("DetailPage", fooPara);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (OpenSpaceItems.Count == 0)
            {
                await Loading();
            }
        }

        public async Task Loading()
        {
            HttpClient fooClient = new HttpClient();
            var fooResult = await fooClient.GetStringAsync("http://sme.moeasmea.gov.tw/startup/upload/opendata/gov_source_map_opendata.json");
            AllItems = JsonConvert.DeserializeObject<List<OpenSpaceItem>>(fooResult);
            OpenSpaceItems.Clear();
            foreach (var item in AllItems)
            {
                OpenSpaceItems.Add(item);
            }
        }
    }
}
