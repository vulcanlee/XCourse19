using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(XF4029.MyEntry), typeof(XF4029.UWP.MyEntryRenderer))]
namespace XF4029.UWP
{
    /// <summary>
    /// 這個類別，將會透過 EntryRenderer ，客製 UWP 平台下的文字輸入盒
    /// </summary>
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new SolidColorBrush(Colors.Transparent);
                Control.BorderBrush = new SolidColorBrush(Colors.Transparent);
                //TextBox textBox = Control as TextBox;
                //textBox.BorderBrush = new SolidColorBrush(Colors.Transparent);
                //textBox.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
