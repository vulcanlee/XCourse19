using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF2001.ViewModels
{
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Acr.UserDialogs;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand Progress預設用法Command { get; set; }
        public DelegateCommand Progress有取消Command { get; set; }
        public DelegateCommand Progress有取消有進度Command { get; set; }
        public DelegateCommand Loading預設用法Command { get; set; }
        public DelegateCommand Loading有取消Command { get; set; }
        public string ResultMessage { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Progress預設用法Command = new DelegateCommand(async () =>
            {
                using (Acr.UserDialogs.UserDialogs.Instance.Progress("處理中，請稍待"))
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            });
            Progress有取消Command = new DelegateCommand(async () =>
            {
                ResultMessage = "";
                var cancelSrc = new CancellationTokenSource();


                var config = new ProgressDialogConfig()
                    .SetTitle("請稍後，正在處理中...")
                    .SetIsDeterministic(false)
                    .SetMaskType(MaskType.Clear)
                    .SetCancel("點選這裡則會取消", onCancel: cancelSrc.Cancel);

                using (IProgressDialog progressDialog = Acr.UserDialogs.UserDialogs.Instance.Progress(config))
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5), cancelSrc.Token);
                        progressDialog.Title = "正在進行第 2 階段";
                        progressDialog.PercentComplete = 66;
                        await Task.Delay(TimeSpan.FromSeconds(3), cancelSrc.Token);
                        progressDialog.Title = "正在進行第 3 階段";
                        await Task.Delay(TimeSpan.FromSeconds(3), cancelSrc.Token);
                    }
                    catch { }
                }
                if (cancelSrc.IsCancellationRequested)
                {
                    ResultMessage = "使用者已經取消";
                }
                else
                {
                    ResultMessage = "已經完成";
                }
            });
            Progress有取消有進度Command = new DelegateCommand(async () =>
            {
                ResultMessage = "";
                var cancelSrc = new CancellationTokenSource();

                var config = new ProgressDialogConfig()
                    .SetTitle("請稍後，正在處理中...")
                    .SetIsDeterministic(true)
                    .SetMaskType(MaskType.Gradient)
                    .SetCancel("點選這裡則會取消", onCancel: cancelSrc.Cancel);

                using (IProgressDialog progressDialog = Acr.UserDialogs.UserDialogs.Instance.Progress(config))
                {
                    try
                    {
                        progressDialog.PercentComplete = 0;
                        for (int i = 0; i < 50; i++)
                        {
                            await Task.Delay(100, cancelSrc.Token);
                            progressDialog.PercentComplete += 1;
                        }
                        progressDialog.Title = "正在進行第 2 階段";
                        for (int i = 0; i < 3; i++)
                        {
                            await Task.Delay(1000, cancelSrc.Token);
                            progressDialog.PercentComplete += 10;
                        }
                        progressDialog.Title = "正在進行第 3 階段";
                        for (int i = 0; i < 20; i++)
                        {
                            await Task.Delay(100, cancelSrc.Token);
                            progressDialog.PercentComplete += 1;
                        }
                    }
                    catch { }
                }
                if (cancelSrc.IsCancellationRequested)
                {
                    ResultMessage = "使用者已經取消";
                }
                else
                {
                    ResultMessage = "已經完成";
                }
            });
            Loading預設用法Command = new DelegateCommand(async () =>
            {
                using (Acr.UserDialogs.UserDialogs.Instance.Loading("登入中，請稍待"))
                {
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            });
            Loading有取消Command = new DelegateCommand(async () =>
            {
                ResultMessage = "";
                var cancelSrc = new CancellationTokenSource();

                using (IProgressDialog progressDialog = Acr.UserDialogs.UserDialogs.Instance.Loading(
                    "登入中，請稍後", cancelSrc.Cancel, "停止登入", true, MaskType.Clear))
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5), cancelSrc.Token);
                        progressDialog.Title = "正在進行第 2 階段";
                        await Task.Delay(TimeSpan.FromSeconds(3), cancelSrc.Token);
                        progressDialog.Title = "正在進行第 3 階段";
                        await Task.Delay(TimeSpan.FromSeconds(3), cancelSrc.Token);
                    }
                    catch { }
                }
                if (cancelSrc.IsCancellationRequested)
                {
                    ResultMessage = "使用者已經取消";
                }
                else
                {
                    ResultMessage = "已經完成";
                }
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
