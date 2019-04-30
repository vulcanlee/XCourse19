using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XF2010.Services;

[assembly: Xamarin.Forms.Dependency(typeof(XF2010.Droid.SayHello))]
namespace XF2010.Droid
{
    public class SayHello : ISayHello
    {
        public string Hello()
        {
            Context context = Android.App.Application.Context;
            var fooVersionName = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
            var fooPackageName = context.PackageManager.GetPackageInfo(context.PackageName, 0).PackageName;
            return $"這是 Android 系統 ${fooPackageName}  {fooVersionName}";
        }
    }
}