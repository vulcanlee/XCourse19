using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using System;
using System.Threading;
using System.Threading.Tasks;
using XF5007.Services;

namespace XF5007.Droid
{
    [Activity(Label = "XF5007", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }
        protected override void OnStart()
        {
            base.OnStart();
             new AppLifeStatusService().WriteAsync($"     Android>OnStart - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        protected override void OnResume()
        {
            base.OnResume();
             new AppLifeStatusService().WriteAsync($"     Android>OnResume - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}"); 
        }
        protected override void OnPause()
        {
            base.OnPause();
             new AppLifeStatusService().WriteAsync($"     Android>OnPause - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}"); 
        }
        protected override void OnStop()
        {
            base.OnStop();
             new AppLifeStatusService().WriteAsync($"     Android>OnStop - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        protected override void OnRestart()
        {
            base.OnRestart();
             new AppLifeStatusService().WriteAsync($"     Android>OnRestart - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
             new AppLifeStatusService().WriteAsync($"     Android>OnDestroy - {DateTime.Now.Minute}:{DateTime.Now.Second} - 執行緒 {Thread.CurrentThread.ManagedThreadId}");
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

