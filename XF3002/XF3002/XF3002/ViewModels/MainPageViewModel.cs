using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3002.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3002.Models;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MyData> myItemList { get; set; } = new ObservableCollection<MyData>();
        public MyData SelectedItem { get; set; }
        public int GridItemsLayoutSpan { get; set; } = 2;
        public DelegateCommand SelectionChangedCommand { get; set; }
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;

        public MainPageViewModel()
        {
            ReadData();
        }
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            SelectionChangedCommand = new DelegateCommand(() =>
            {
                dialogService.DisplayAlertAsync("Info", SelectedItem.Name, "OK");
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ReadData();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
        public void ReadData()
        {
            int cc = 1;
            for (int i = 0; i < 10; i++)
            {
                myItemList.Add(new MyData() { Name = "Baboon", OrderId=cc++ });
                myItemList.Add(new MyData() { Name = "Capuchin Monkey", OrderId = cc++ });
                myItemList.Add(new MyData() { Name = "Blue Monkey", OrderId = cc++ });
                myItemList.Add(new MyData() { Name = "Squirrel Monkey", OrderId = cc++ });
                myItemList.Add(new MyData() { Name = "Golden Lion Tamarin", OrderId = cc++ });
                myItemList.Add(new MyData() { Name = "Howler Monkey", OrderId = cc++ });
                myItemList.Add(new MyData() { Name = "Japanese Macaque", OrderId = cc++ });
            }
        }
    }
}
