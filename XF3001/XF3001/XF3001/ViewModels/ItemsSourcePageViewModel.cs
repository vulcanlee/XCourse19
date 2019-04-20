using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF3001.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;
    using XF3001.Models;

    public class ItemsSourcePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ItemBlock> myItemList { get; set; } = new ObservableCollection<ItemBlock>();
        private readonly INavigationService navigationService;

        public ItemsSourcePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Random rnd = new Random();
            ItemBlock fooItem;
            for (int i = 0; i < 3; i++)
            {
                fooItem = new ItemBlock()
                {
                    Width = 120,
                    Height = 100,
                    Color = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(256)),
                    ShowLabel = false,
                };
                myItemList.Add(fooItem);
            }
            fooItem = new ItemBlock()
            {
                Width = 360,
                Height = 50,
                Color = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(256)),
                ShowLabel = true,
                ShowBoxView = false
            };
            myItemList.Add(fooItem);
            fooItem = new ItemBlock()
            {
                Width = 360,
                Height = 200,
                Color = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(256)),
                ShowLabel = false,
            };
            myItemList.Add(fooItem);
            for (int i = 0; i < 31; i++)
            {
                fooItem = new ItemBlock()
                {
                    Width = 120,
                    Height = 100,
                    Color = Color.FromRgba(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(256)),
                    ShowLabel = false,
                };
                myItemList.Add(fooItem);
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
