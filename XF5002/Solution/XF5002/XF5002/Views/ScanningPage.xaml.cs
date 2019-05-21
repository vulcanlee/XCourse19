using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF5002.Views
{
    public partial class ScanningPage : ContentPage
    {
        bool needAutoFocus = true;
        public ScanningPage()
        {
            InitializeComponent();

            ScannerView.Options.PossibleFormats = new List<ZXing.BarcodeFormat>()
            {
                ZXing.BarcodeFormat.QR_CODE,
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            needAutoFocus = true;
            Task.Run(async () =>
            {
                while (needAutoFocus)
                {
                    await Task.Delay(2000);
                    //ScannerView.AutoFocus();
                }
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            needAutoFocus = false;
        }
    }
}
