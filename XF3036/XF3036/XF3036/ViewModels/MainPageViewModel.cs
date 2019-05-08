using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3036.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;

    public class MyItem
    {
        public string Name { get; set; }
        public int ID { get; set; }
    }
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MyItem> MyListItems { get; set; } = new ObservableCollection<MyItem>();
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            for (int i = 0; i < 500; i++)
            {
                var fooObject = new MyItem
                {
                    Name = $"Item Name :{i}",
                    ID = i,
                };
                MyListItems.Add(fooObject);
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
