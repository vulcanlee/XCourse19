using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF5001.ViewModels
{
    using System.ComponentModel;
    using System.IO;
    using System.Net.Http;
    using Newtonsoft.Json;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ImageSource MyImageSource { get; set; }
        public DelegateCommand TakePhotoCommand { get; set; }
        public DelegateCommand UploadPhotoCommand { get; set; }
        public string UploadImageUrl { get; set; }
        private readonly INavigationService navigationService;
        private readonly IPageDialogService dialogService;
        string imagePath;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            TakePhotoCommand = new DelegateCommand(async () =>
            {
                // 進行 Plugin.Media 套件的初始化動作
                await Plugin.Media.CrossMedia.Current.Initialize();

                // 確認這個裝置是否具有拍照的功能
                if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
                {
                    await dialogService.DisplayAlertAsync("No Camera", ":( No camera available.", "OK");
                    return;
                }

                // 啟動拍照功能，並且儲存到指定的路徑與檔案中
                var file = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "Sample.jpg",
                    //CompressionQuality = 90,
                    //PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    //DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                });

                if (file == null)
                    return;

                imagePath = file.Path;

                // 讀取剛剛拍照的檔案內容，轉換成為 ImageSource，如此，就可以顯示到螢幕上了
                MyImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            });
            UploadPhotoCommand = new DelegateCommand(async () =>
            {
                UploadImageUrl = "";
                // 取得剛剛拍照完成的照片檔案名稱與完整路徑名稱
                string fileName = Path.GetFileName(imagePath);
                string imageFileName = imagePath;

                // 建立 HttpClient 物件
                HttpClient client = new HttpClient();
                string url = $"http://lobworkshop.azurewebsites.net/api/UploadImage";
                #region 將圖片檔案，上傳到網路伺服器上(使用 Multipart 的規範)
                // 規格說明請參考 https://www.w3.org/Protocols/rfc1341/7_2_Multipart.html

                //建立 MultipartFormDataContent 物件，並把圖片檔案 Stream 放入 StreamContent 物件
                using (var content = new MultipartFormDataContent())
                {
                    // 開啟這個圖片檔案，並且讀取其內容
                    using (var fs = File.Open(imageFileName, FileMode.Open))
                    {
                        var streamContent = new StreamContent(fs);
                        streamContent.Headers.Add("Content-Type", "application/octet-stream");
                        streamContent.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + fileName + "\"");
                        content.Add(streamContent, "file", fileName);

                        // 上傳到遠端伺服器上
                        HttpResponseMessage response = await client.PostAsync(url, content);

                        if (response != null)
                        {
                            if (response.IsSuccessStatusCode == true)
                            {
                                // 取得呼叫完成 API 後的回報內容
                                String strResult = await response.Content.ReadAsStringAsync();
                                APIResult apiResult = JsonConvert.DeserializeObject<APIResult>(strResult, new JsonSerializerSettings { MetadataPropertyHandling = MetadataPropertyHandling.Ignore });
                                if (apiResult?.Status == true)
                                {
                                    // 得到上傳圖片 API 回傳內容
                                    UploadImageResponseDTO uploadImageResponseDTO = JsonConvert.DeserializeObject<UploadImageResponseDTO>(apiResult.Payload.ToString());
                                    UploadImageUrl = uploadImageResponseDTO.ImageUrl;
                                }
                            }
                        }
                    }
                }
                #endregion
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
    /// <summary>
    /// 呼叫 API 回傳的制式格式
    /// </summary>
    public class APIResult
    {
        /// <summary>
        /// 此次呼叫 API 是否成功
        /// </summary>
        public bool Status { get; set; } = true;
        public int HTTPStatus { get; set; } = 200;
        public int ErrorCode { get; set; }
        /// <summary>
        /// 呼叫 API 失敗的錯誤訊息
        /// </summary>
        public string Message { get; set; } = "";
        /// <summary>
        /// 呼叫此API所得到的其他內容
        /// </summary>
        public object Payload { get; set; }
    }
    public class UploadImageResponseDTO
    {
        public string ImageUrl { get; set; }
    }
}
