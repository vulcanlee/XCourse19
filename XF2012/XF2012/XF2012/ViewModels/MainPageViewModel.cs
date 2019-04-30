using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2012.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand 選擇項目Command { get; set; }
        public DelegateCommand 注意事項對話窗Command { get; set; }
        public string Title { get; set; }  
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            選擇項目Command = new DelegateCommand(async () =>
            {
                var fooResult = await dialogService.DisplayActionSheetAsync("Information", "取消", null, "Option1", "Option2", "Option3", "Option4");
                if (string.IsNullOrEmpty(fooResult))
                {
                    Title = $"你沒有選擇任何項目";
                }
                else
                {
                    Title = $"你回答的是 {fooResult}";
                }
            });
            注意事項對話窗Command = new DelegateCommand(async () =>
            {
                var fooResult = await dialogService.DisplayAlertAsync("警告", "你的裝置需要連上網際網路，才能正常操作!?", "確定", "取消");
                Title = $"你回答的是 {fooResult}";
            });

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
