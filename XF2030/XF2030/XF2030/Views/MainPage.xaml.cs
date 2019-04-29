using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF2030.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Appearing += (s, e) =>
            {
                Debug.WriteLine($"  _______>>>  MainPage     Appearing");
            };
            this.Disappearing += (s, e) =>
            {
                Debug.WriteLine($"  _______>>>  MainPage     Disappearing");
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine($"  _______>>>  MainPage     OnAppearing");
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Debug.WriteLine($"  _______>>>  MainPage     OnDisappearing");
        }
    }
}