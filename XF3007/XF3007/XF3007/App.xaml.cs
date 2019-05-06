using Prism;
using Prism.Ioc;
using XF3007.ViewModels;
using XF3007.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF3007
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

            await NavigationService.NavigateAsync("MainTabbedPage?createTab=Page1&createTab=NavigationPage|Page2&createTab=Page3&createTab=Page4&selectedTab=Page3");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Page1, Page1ViewModel>();
            containerRegistry.RegisterForNavigation<Page2, Page2ViewModel>();
            containerRegistry.RegisterForNavigation<Page3, Page3ViewModel>();
            containerRegistry.RegisterForNavigation<Page4, Page4ViewModel>();
            containerRegistry.RegisterForNavigation<Page21, Page21ViewModel>();
            containerRegistry.RegisterForNavigation<MainTabbedPage, MainTabbedPageViewModel>();
        }
    }
}
