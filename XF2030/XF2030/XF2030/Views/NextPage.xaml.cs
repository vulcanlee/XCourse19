using System.Diagnostics;
using Xamarin.Forms;

namespace XF2030.Views
{
    public partial class NextPage : ContentPage
    {
        public NextPage()
        {
            InitializeComponent();
            this.Appearing += (s, e) =>
            {
                Debug.WriteLine($"  _______>>>  NextPage     Appearing");
            };
            this.Disappearing += (s, e) =>
            {
                Debug.WriteLine($"  _______>>>  NextPage     Disappearing");
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine($"  _______>>>  NextPage     OnAppearing");
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Debug.WriteLine($"  _______>>>  NextPage     OnDisappearing");
        }
    }
}
