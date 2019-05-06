using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace XF3007.Views
{
    public partial class MainTabbedPage : Xamarin.Forms.TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();
            //On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
