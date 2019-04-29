using Xamarin.Forms;

namespace XF2009.Views
{
    public partial class EditPage : ContentPage
    {
        public EditPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            //return base.OnBackButtonPressed();
            return true;
        }
    }
}
