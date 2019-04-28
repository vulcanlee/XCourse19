using Prism;
using Prism.Ioc;
using XF1005.ViewModels;
using XF1005.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF1005.Helpers;
using Xamarin.Essentials;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF1005
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

            #region 裝置螢幕資訊初始化
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            AppGlobal.DisplayScaleFactor = mainDisplayInfo.Density;
            AppGlobal.DisplayScreenHeight = mainDisplayInfo.Height / mainDisplayInfo.Density;
            AppGlobal.DisplayScreenWidth = mainDisplayInfo.Width / mainDisplayInfo.Density;
            AppGlobal.PhysicalDisplayScreenHeight = mainDisplayInfo.Height;
            AppGlobal.PhysicalDisplayScreenWidth = mainDisplayInfo.Width;
            #endregion
            await NavigationService.NavigateAsync("MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
