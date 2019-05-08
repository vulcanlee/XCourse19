using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace XF3024.ViewModels
{
    using System.ComponentModel;
    using System.Net.Http;
    using PCLStorage;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    public class IndependentImagePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string PCLImage { get; set; }
        public string LocalImage1 { get; set; }
        public string LocalImage2 { get; set; }
        public string 下載背景顏色 { get; set; }
        public ImageSource MyImageSource { get; set; }
        public DelegateCommand 下載圖片Command { get; private set; }
        private readonly INavigationService navigationService;

        public IndependentImagePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            下載圖片Command = new DelegateCommand(下載圖片);

            LocalImage1 = "platformImage.jpg";
            下載背景顏色 = "White";
        }
        private async void 下載圖片()
        {
            下載背景顏色 = "Red";

            #region 從網路下載後，先儲存到本機檔案系統內，接著再讀出來，進行圖片資料綁定
            HttpClient client = new HttpClient();
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync("Images", CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync("MyLocalImage.jpg", CreationCollisionOption.ReplaceExisting);
            using (var fooTargetStream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                using (var fooSourceString = await client.GetStreamAsync("https://developer.xamarin.com/demo/IMG_3256.JPG?width=640"))
                {
                    await fooSourceString.CopyToAsync(fooTargetStream);
                }
            }

            file = await folder.GetFileAsync("MyLocalImage.jpg");
            var fooTargetReadStream = await file.OpenAsync(FileAccess.Read);
            MyImageSource = ImageSource.FromStream(() => fooTargetReadStream);
            #endregion

            #region 直接從網路下載後，就進行圖片資料綁定
            //HttpClient client = new HttpClient();
            //var fooSourceString = await client.GetStreamAsync("https://developer.xamarin.com/demo/IMG_3256.JPG?width=640");
            //MyImageSource = ImageSource.FromStream(() => fooSourceString);
            #endregion

            下載背景顏色 = "Green";
            LocalImage2 = "MyLocalImage.jpg";

            PCLImage = "";
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
