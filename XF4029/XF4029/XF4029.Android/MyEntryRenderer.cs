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
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XF4029.MyEntry), typeof(XF4029.Droid.MyEntryRenderer))]
namespace XF4029.Droid
{
    /// <summary>
    /// 這個類別，將會透過 EntryRenderer ，客製 Android 平台下的文字輸入盒
    /// </summary>
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                //Control.SetBackgroundDrawable(null);
                Control.SetBackground(null);
            }
        }
    }
}