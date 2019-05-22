using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF3020.CustomControls
{
    public class FontAwesomeLabel : Label
    {
        public FontAwesomeLabel()
        {
            // 這個用法已經過程，要改用 Switch 的方法
            //FontFamily = Device.OnPlatform(
            //    iOS:  "fontawesome", 
            //    Android: "fontawesome", 
            //    WinPhone:"fontawesome.ttf#FontAwesome");

            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    FontFamily = @"/fontawesome.ttf#FontAwesome";
                    break;
                case Device.iOS:
                    FontFamily = @"fontawesome";
                    break;
                case Device.Android:
                    FontFamily = @"fontawesome.ttf";
                    break;
                default:
                    FontFamily = "fontawesome";
                    break;
            }
        }
    }
}
