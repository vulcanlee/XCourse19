using Prism;
using Prism.Ioc;
using XF3006.ViewModels;
using XF3006.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF3006
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

            await NavigationService.NavigateAsync("MDPage/NaviPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NaviPage, NaviPageViewModel>();
            containerRegistry.RegisterForNavigation<MDPage, MDPageViewModel>();
            containerRegistry.RegisterForNavigation<NextPage, NextPageViewModel>();
            containerRegistry.RegisterForNavigation<Page1, Page1ViewModel>();
            containerRegistry.RegisterForNavigation<Page2, Page2ViewModel>();
        }
    }
}
