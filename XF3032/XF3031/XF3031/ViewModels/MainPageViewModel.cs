using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF3031.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3031.Models;
    using XF3031.Repositories;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MyTaskItem MyTaskItemSelected { get; set; }
        public bool RefreshingStatus { get; set; }
        public ObservableCollection<MyTaskItem> MyTaskItemList { get; set; } = new ObservableCollection<MyTaskItem>();
        public int RefreshIndex { get; set; } = 0;
        public DelegateCommand MyTaskItemSelectedCommand { get; set; }
        public DelegateCommand MyTaskRefreshCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            MyTaskItemSelectedCommand = new DelegateCommand(async () =>
            {
                //await _dialogService.DisplayAlertAsync("Info", $"你選取的是 {MyTaskItemSelected.MyTaskName}", "OK");

                NavigationParameters fooPara = new NavigationParameters();
                fooPara.Add("MyTaskItem", MyTaskItemSelected.Clone());
                fooPara.Add("Mode", "Edit");
                await navigationService.NavigateAsync("TaskDetailPage", fooPara);
            });

            MyTaskRefreshCommand = new DelegateCommand(() =>
            {
                RefreshIndex++;
                MyTaskItemList.Clear();
                MyTaskRepository fooMyTaskRepository = new MyTaskRepository();
                var fooTasks = fooMyTaskRepository.GetMyTask();
                foreach (var item in fooTasks)
                {
                    MyTaskItemList.Add(new MyTaskItem
                    {
                        MyTaskName = $"{RefreshIndex} {item.MyTaskName}",
                        MyTaskDate = item.MyTaskDate,
                        MyTaskStatus = item.MyTaskStatus,
                    });
                }
                RefreshingStatus = false;
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            MyTaskRepository fooMyTaskRepository = new MyTaskRepository();
            var fooTasks = fooMyTaskRepository.GetMyTask();
            foreach (var item in fooTasks)
            {
                MyTaskItemList.Add(new MyTaskItem
                {
                    MyTaskName = item.MyTaskName,
                    MyTaskDate = item.MyTaskDate,
                    MyTaskStatus = item.MyTaskStatus,
                });
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
