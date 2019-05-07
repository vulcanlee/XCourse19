using Prism;
using Prism.Ioc;
using XF3021.ViewModels;
using XF3021.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF3021
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

            Plugin.Iconize.Iconize
    .With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
    .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
    .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule());

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
