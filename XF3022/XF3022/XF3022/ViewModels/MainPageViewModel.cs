using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3022.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string SelectedMainCategory { get; set; }
        public string SelectedSubCategory { get; set; }
        public ObservableCollection<string> MainCategoryList { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> SubCategoryList { get; set; } = new ObservableCollection<string>();
        private readonly INavigationService navigationService;
        public DelegateCommand MainCategoryChangeCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            MainCategoryChangeCommand = new DelegateCommand(() =>
            {
                if (string.IsNullOrEmpty(SelectedMainCategory) == false)
                    SubCategoryList.Clear();
                for (int i = 0; i < 50; i++)
                {
                    SubCategoryList.Add($"{SelectedMainCategory} - {i}");
                }
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            MainCategoryList.Clear();
            for (int i = 0; i < 30; i++)
            {
                MainCategoryList.Add($"主要分類選項 {i}");
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
