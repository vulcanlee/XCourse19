using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF2016
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.btn.Clicked += async (s, e) =>
            {
                var fooNextPage = new NextPage();
                // 使用子頁面的公開屬性來設定要傳遞過去的值
                //fooNextPage.YourName = YourName.Text;
                // 使用子頁面的公開方法，來設定要傳遞過去的值
                fooNextPage.SetYourName(YourName.Text);

                await this.Navigation.PushAsync(fooNextPage);
            };
        }
    }
}
