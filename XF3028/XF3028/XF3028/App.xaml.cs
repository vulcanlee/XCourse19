using Prism;
using Prism.Ioc;
using XF3028.ViewModels;
using XF3028.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF3028
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Basic1Page, Basic1PageViewModel>();
            containerRegistry.RegisterForNavigation<BasicPage, BasicPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomButton1Page, CustomButton1PageViewModel>();
            containerRegistry.RegisterForNavigation<CustomButtonPage, CustomButtonPageViewModel>();
            containerRegistry.RegisterForNavigation<HeaderFooterPage, HeaderFooterPageViewModel>();
            containerRegistry.RegisterForNavigation<ItemClickPage, ItemClickPageViewModel>();
            containerRegistry.RegisterForNavigation<PullToRefreshPage, PullToRefreshPageViewModel>();
            containerRegistry.RegisterForNavigation<RowHeightPage, RowHeightPageViewModel>();
            containerRegistry.RegisterForNavigation<ScrollToPage, ScrollToPageViewModel>();
            containerRegistry.RegisterForNavigation<VariRowHeithtPage, VariRowHeithtPageViewModel>();
        }
    }
}
