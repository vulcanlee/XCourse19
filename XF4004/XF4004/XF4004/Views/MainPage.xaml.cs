using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF4004.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void btnDynamicRes_Clicked(object sender, System.EventArgs e)
        {
            this.Resources["DynamicResourceColor"] = Color.Red;
            this.Resources["DynamicResourcefontSize"] = 12;
        }

        private void btnStaticObject_Clicked(object sender, System.EventArgs e)
        {
            MyClass.StaticSize = 40;
            MyClass.StaticMember = Color.Orange;
        }
    }
}