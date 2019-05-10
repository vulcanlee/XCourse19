using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF4017.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public string PickerSelectedTitle { get; set; }
        public string PickerSelected { get; set; }
        public ObservableCollection<string> PickerVM { get; set; } = new ObservableCollection<string>();
        public DelegateCommand<object> SelectedIndexChangedCommand { get; private set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            PickerVM = new ObservableCollection<string>();
            PickerVM.Add("Item1");
            PickerVM.Add("Item2");
            PickerVM.Add("Item3");
            PickerVM.Add("Item4");
            PickerVM.Add("Item5");
            PickerVM.Add("Item6");
            PickerVM.Add("Item7");

            Title = "這裡是由 SelectedItemCommand 命令觸發來設定";
            PickerSelectedTitle = "這裡是由 SelectedItem 資料綁定自動設定";
            SelectedIndexChangedCommand = new DelegateCommand<object>(SelectedIndexChanged);
        }
        private void SelectedIndexChanged(object obj)
        {
            Title = $"已經選擇 {obj}";
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
