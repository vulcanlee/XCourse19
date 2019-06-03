using Prism;
using Prism.Ioc;
using XF5007.ViewModels;
using XF5007.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using XF5007.Services;
using System;
using System.Threading;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XF5007
{
    public partial class App
    {
        public static bool IsAppInForeground { get; set; }
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

        // https://docs.microsoft.com/zh-tw/xamarin/xamarin-forms/app-fundamentals/app-lifecycle

        protected override async void OnStart()
        {
            IsAppInForeground = true;
            new AppLifeStatusService().WriteAsync($"Xamarin.Forms>OnStart - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
            //await new AppLifeStatusService().WriteAsync($"OnStart - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        protected override async void OnSleep()
        {
            IsAppInForeground = false;
            new AppLifeStatusService().WriteAsync($"Xamarin.Forms>OnSleep - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
            //await new AppLifeStatusService().WriteAsync($"OnSleep - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        protected override async void OnResume()
        {
            IsAppInForeground = true;
            new AppLifeStatusService().WriteAsync($"Xamarin.Forms>OnResume - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
            //await new AppLifeStatusService().WriteAsync($"OnResume - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
