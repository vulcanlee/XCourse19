using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XF5004.ViewModels
{
    public class ProcessingUserControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool 顯示處理中遮罩 { get; set; }
        public bool 忙碌中控制項使用中 { get; set; }
        public string 處理中訊息 { get; set; }
        public string 處理中狀態文字 { get; set; }

        public ProcessingUserControlViewModel()
        {

        }

        public void 顯示忙碌中使用者控制項(string p處理中訊息, string p處理中狀態文字)
        {
            處理中訊息 = p處理中訊息;
            處理中狀態文字 = p處理中狀態文字;
            顯示處理中遮罩 = true;
            忙碌中控制項使用中 = true;
        }

        public void 關閉忙碌中使用者控制項()
        {
            處理中訊息 = "";
            處理中狀態文字 = "";
            顯示處理中遮罩 = false;
            忙碌中控制項使用中 = false;
        }
    }
}
