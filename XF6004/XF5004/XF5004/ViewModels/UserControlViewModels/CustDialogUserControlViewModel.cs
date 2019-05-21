using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XF5004.ViewModels
{
    public class CustDialogUserControlViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool 顯示客製化使用者對話窗 { get; set; }
        public string 對話窗主題 { get; set; }
        public string 對話窗訊息 { get; set; }
        public string 對話窗使用者帳號 { get; set; }
        public string 對話窗使使用者密碼 { get; set; }

        public CustDialogUserControlViewModel()
        {

        }

        public void 顯示客製化使用者對話窗控制項(string p對話窗主題, string p對話窗訊息)
        {
            對話窗主題 = p對話窗主題;
            對話窗訊息 = p對話窗訊息;
            對話窗使用者帳號 = "";
            對話窗使使用者密碼 = "";
            顯示客製化使用者對話窗 = true;
        }

        public void 關閉客製化使用者對話窗控制項()
        {
            顯示客製化使用者對話窗 = false;
        }

    }
}
