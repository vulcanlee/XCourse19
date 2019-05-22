using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF5004.ViewModels
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand 客製化對話窗Command;
        public DelegateCommand 處理中遮罩Comnand;
        public DelegateCommand 點選遮罩Command;
        public DelegateCommand 客製化對話窗確定Command;
        public DelegateCommand 客製化對話窗取消Command;
        public bool 顯示客製化對話窗 { get; set; }
        public string 對話窗主題 { get; set; }
        public string 對話窗內容 { get; set; }
        public string 使用者輸入內容 { get; set; }
        public ProcessingUserControlViewModel 處理中ViewModel { get; set; } = new ProcessingUserControlViewModel();
        public CustDialogUserControlViewModel 客製化使用者對話窗ViewModel { get; set; } = new CustDialogUserControlViewModel();
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            客製化對話窗Command = new DelegateCommand(客製化對話窗);
            處理中遮罩Comnand = new DelegateCommand(處理中遮罩);
            點選遮罩Command = new DelegateCommand(點選遮罩);
            客製化對話窗確定Command = new DelegateCommand(客製化對話窗確定);
            客製化對話窗取消Command = new DelegateCommand(客製化對話窗取消);
        }

        private void 客製化對話窗取消()
        {
            使用者輸入內容 = "";
            客製化使用者對話窗ViewModel.關閉客製化使用者對話窗控制項();
        }

        private async void 客製化對話窗確定()
        {
            if (string.IsNullOrEmpty(客製化使用者對話窗ViewModel.對話窗使用者帳號) || 客製化使用者對話窗ViewModel.對話窗使用者帳號.Length < 6)
            {
                await dialogService.DisplayAlertAsync("警告", "帳號不可為空值或者小於6個字元", "確定");
            }
            else if (string.IsNullOrEmpty(客製化使用者對話窗ViewModel.對話窗使使用者密碼) || 客製化使用者對話窗ViewModel.對話窗使使用者密碼.Length < 8)
            {
                await dialogService.DisplayAlertAsync("警告", "密碼不可為空值或者小於8個字元", "確定");
            }
            else
            {
                使用者輸入內容 = $"帳號:{客製化使用者對話窗ViewModel.對話窗使用者帳號} / 密碼: {客製化使用者對話窗ViewModel.對話窗使使用者密碼}";
                客製化使用者對話窗ViewModel.關閉客製化使用者對話窗控制項();
            }
        }

        private void 點選遮罩()
        {
            處理中ViewModel.關閉忙碌中使用者控制項();
        }

        private async void 處理中遮罩()
        {
            處理中ViewModel.顯示忙碌中使用者控制項("正在更新資料", "正在更新資料，需要2秒鐘");
            await Task.Delay(2000);
            處理中ViewModel.關閉忙碌中使用者控制項();
        }

        private void 客製化對話窗()
        {
            客製化使用者對話窗ViewModel.顯示客製化使用者對話窗控制項("請進行身分驗證", "請輸入您的帳號與密碼，並且點選確定按鈕");
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
