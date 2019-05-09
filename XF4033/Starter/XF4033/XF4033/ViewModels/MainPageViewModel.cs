using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF4033.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF4033.Models;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public bool GetLabelBC { get; set; } = false;
        public bool GetViewCellBC { get; set; } = false;
        public ObservableCollection<ProductItem> ProductItemList { get; set; } = new ObservableCollection<ProductItem>();
        public DelegateCommand<ProductItem> ChangeNameCommand { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            ChangeNameCommand = new DelegateCommand<ProductItem>(x =>
              {
                  x.Name = "此名稱已經修正了";
              });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            for (int i = 0; i < 10; i++)
            {
                ProductItemList.Add(new ProductItem
                {
                    id = i,
                    Name = $"產品名稱{i}",
                    Description = $"規格說明{i}"
                });
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
