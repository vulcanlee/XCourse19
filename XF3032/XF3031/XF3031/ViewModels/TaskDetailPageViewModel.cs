using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF3031.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XF3031.Models;

    public class TaskDetailPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MyTaskItem MyTaskItemSelected { get; set; }
        public string TaskMode { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        private readonly INavigationService navigationService;

        public TaskDetailPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Mode"))
            {
                TaskMode = parameters.GetValue<string>("Mode");
                if (TaskMode == "Edit")
                {
                    MyTaskItemSelected = parameters.GetValue< MyTaskItem>("MyTaskItem");
                }
                else
                {
                    MyTaskItemSelected = new MyTaskItem();
                }
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
