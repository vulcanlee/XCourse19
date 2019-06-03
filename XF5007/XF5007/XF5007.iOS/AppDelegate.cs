using Foundation;
using Prism;
using Prism.Ioc;
using System;
using System.Threading;
using UIKit;
using XF5007.Services;

namespace XF5007.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }
        public override void OnActivated(UIApplication application)
        {
            base.OnActivated(application);
            new AppLifeStatusService().WriteAsync($"     iOS>OnActivated - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        public override void WillEnterForeground(UIApplication application)
        {
            base.WillEnterForeground(application);
            new AppLifeStatusService().WriteAsync($"     iOS>WillEnterForeground - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        public override void OnResignActivation(UIApplication application)
        {
            base.OnResignActivation(application);
            new AppLifeStatusService().WriteAsync($"     iOS>OnResignActivation - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        public override void DidEnterBackground(UIApplication application)
        {
            base.DidEnterBackground(application);
            new AppLifeStatusService().WriteAsync($"     iOS>DidEnterBackground - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        // not guaranteed that this will run
        public override void WillTerminate(UIApplication application)
        {
            base.WillTerminate(application);
            new AppLifeStatusService().WriteAsync($"     iOS>WillTerminate - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}
