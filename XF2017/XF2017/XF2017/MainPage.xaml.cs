using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF2017
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void btn_Clicked(object sender, EventArgs e)
        {
            // 這裡不使用 await 會有甚麼情況
            string fooAnswer = await this.DisplayActionSheet("Information", "確定", null, "Option1", "Option2", "Option3", "Option4");
            YourAnswer.Text = fooAnswer;
        }
    }
}
