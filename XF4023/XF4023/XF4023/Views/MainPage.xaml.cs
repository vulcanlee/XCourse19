using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF4023.ViewModels;

namespace XF4023.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel MainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel = this.BindingContext as MainPageViewModel;
        }

        private void OnPinch(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Scale > 1.0)
            {
                MainPageViewModel.Title = $"放大 {e.Scale}";
            }
            else
            {
                MainPageViewModel.Title = $"縮小 {e.Scale}";
            }
        }

        private void OnPan(object sender, PanUpdatedEventArgs e)
        {
            MainPageViewModel.Title = $"平移 X:{e.TotalX} Y:{e.TotalY}";
        }

        private void OnSwiped(object sender, SwipedEventArgs e)
        {
            MainPageViewModel.Title = $"滑動 {e.Direction}";            
        }
    }
}