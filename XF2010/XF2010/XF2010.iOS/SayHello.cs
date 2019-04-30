using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using XF2010.Services;

[assembly: Xamarin.Forms.Dependency(typeof(XF2010.iOS.SayHello))]
namespace XF2010.iOS
{
    public class SayHello : ISayHello
    {
        public string Hello()
        {
            string fooRet = Foundation.NSBundle.MainBundle.InfoDictionary["CFBundleVersion"].ToString();
            return $"這是 iOS 系統 {fooRet}";
        }
    }
}