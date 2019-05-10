using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF4020.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;
    using XF4020.Models;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }
        public string 送出對話內容 { get; set; }
        public string Boy { get; set; } = "boy.png";
        public string Girl { get; set; } = "girl.png";
        public ObservableCollection<ChatContent> ChatContentCollection { get; set; } = new ObservableCollection<ChatContent>();
        public DelegateCommand 送出Command { get; set; }
        private readonly INavigationService navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            送出Command = new DelegateCommand(() =>
            {
                if (送出對話內容 == "1")
                {
                    ChatContentCollection.Add(new ChatContent
                    {
                        對話人圖片 = Boy,
                        對話內容 = "妳是小蕙嗎? 好久不見了",
                        對話類型 = 對話類型.自己,
                        對話文字顏色 = Color.Purple
                    });
                    ChatContentCollection.Add(new ChatContent
                    {
                        對話人圖片 = Girl,
                        對話內容 = "沒想到你還記得我",
                        對話類型 = 對話類型.他人,
                        對話文字顏色 = Color.Green
                    });
                }
                else if (送出對話內容 == "2")
                {
                    ChatContentCollection.Add(new ChatContent
                    {
                        對話人圖片 = Boy,
                        對話內容 = "明天出來喝咖啡吧",
                        對話類型 = 對話類型.自己,
                        對話文字顏色 = Color.Purple
                    });
                    ChatContentCollection.Add(new ChatContent
                    {
                        對話人圖片 = Girl,
                        對話內容 = "好呀 ~~",
                        對話類型 = 對話類型.他人,
                        對話文字顏色 = Color.Green
                    });
                }
                else
                {
                    ChatContentCollection.Add(new ChatContent
                    {
                        對話人圖片 = Boy,
                        對話內容 = 送出對話內容,
                        對話類型 = 對話類型.自己,
                        對話文字顏色 = Color.Purple
                    });
                }
                送出對話內容 = "";
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ChatContentCollection.Clear();
            ChatContentCollection.Add(new ChatContent
            {
                對話人圖片 = Girl,
                對話內容 = "我最近手機掉了，更換了電話號碼",
                對話類型 = 對話類型.他人,
                對話文字顏色 = Color.Green
            });

            ChatContentCollection.Add(new ChatContent
            {
                對話人圖片 = Girl,
                對話內容 = "這是我的新電話號碼 0987654321",
                對話類型 = 對話類型.他人,
                對話文字顏色 = Color.Green
            });
            ChatContentCollection.Add(new ChatContent
            {
                對話人圖片 = Boy,
                對話內容 = "妳現在在哪裡呀？",
                對話類型 = 對話類型.自己,
                對話文字顏色 = Color.Purple
            });
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }

    }
}
