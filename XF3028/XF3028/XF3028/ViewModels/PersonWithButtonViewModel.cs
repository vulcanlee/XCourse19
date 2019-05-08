using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Prism.Ioc;
using Prism.Services;

namespace XF3028.ViewModels
{
    public class PersonWithButtonViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Color FavoriteColor { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand<PersonWithButtonViewModel> 進行互動Command { get; private set; }
        public DelegateCommand<PersonWithButtonViewModel> 立即產生Command { get; private set; }
        public DelegateCommand<PersonWithButtonViewModel> 刪除Command { get; private set; }
        public readonly IPageDialogService dialogService;

        public PersonWithButtonViewModel()
        {
            #region 使用 Prism 的容器 IUnityContainer，解析 IPageDialogService 物件
            // 在這裡不使用建構式注入，是因為，PersonRepository.SampleWithButtonViewModel() 要產生的清單物件，不是透過 Unity 所建立的
            // 所以，手動進行物件解析，取得實作的物件
            var fooApp = App.Current as App;
            IContainerProvider fooIUnityContainer = fooApp.Container;
            dialogService = fooApp.Container.Resolve<IPageDialogService>();
            #endregion

            進行互動Command = new DelegateCommand<PersonWithButtonViewModel>(進行互動);
            立即產生Command = new DelegateCommand<PersonWithButtonViewModel>(立即產生);
            刪除Command = new DelegateCommand<PersonWithButtonViewModel>(刪除);
        }

        private async void 進行互動(PersonWithButtonViewModel obj)
        {
            await dialogService.DisplayAlertAsync("請確定", $"您選取了 {obj.Name}", "確定");
        }

        private async void 刪除(PersonWithButtonViewModel obj)
        {
            await dialogService.DisplayAlertAsync("請確定", $"準備刪除 {obj.Name}", "確定");
        }

        private async void 立即產生(PersonWithButtonViewModel obj)
        {
            await dialogService.DisplayAlertAsync("請確定", $"立即執行 {obj.Name}", "確定");
        }

    }
}
