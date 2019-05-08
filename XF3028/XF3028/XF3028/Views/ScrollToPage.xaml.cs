using Xamarin.Forms;
using XF3028.ViewModels;

namespace XF3028.Views
{
    public partial class ScrollToPage : ContentPage
    {
        public ScrollToPageViewModel fooScrollToPageViewModel;
        public ScrollToPage()
        {
            InitializeComponent();

            fooScrollToPageViewModel = this.BindingContext as ScrollToPageViewModel;
            fooScrollToPageViewModel.自動捲動到 = this.自動捲動到;
        }

        public void 自動捲動到(PersonWithButtonViewModel personWithButtonViewModel)
        {
            listview.ScrollTo(personWithButtonViewModel, ScrollToPosition.Start, true);
        }
    }
}
