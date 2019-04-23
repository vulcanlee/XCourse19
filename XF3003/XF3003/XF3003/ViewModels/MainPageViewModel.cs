using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3003.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3003.Models;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ItemBlock> myItemList { get; set; } = new ObservableCollection<ItemBlock>();
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
            myItemList.Add(new ItemBlock()
            {
                ShowViewType = ItemBlockTypeEnum.Label,
                LabelText = "User Account"
            });
            myItemList.Add(new ItemBlock()
            {
                ShowViewType = ItemBlockTypeEnum.Entry,
                LabelText = "Please Enter Account"
            });
            myItemList.Add(new ItemBlock()
            {
                ShowViewType = ItemBlockTypeEnum.Label,
                LabelText = "User Password"
            });
            myItemList.Add(new ItemBlock()
            {
                ShowViewType = ItemBlockTypeEnum.Entry,
                LabelText = "Please Enter Password"
            });
            myItemList.Add(new ItemBlock()
            {
                ShowViewType = ItemBlockTypeEnum.BoxView,
            });
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
