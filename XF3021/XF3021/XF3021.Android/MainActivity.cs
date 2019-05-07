using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;

namespace XF3021.Droid
{
    [Activity(Label = "XF3021", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            #region 進行 Iconize 套件的初始化
            //Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.tabs);
            Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);
            #endregion


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
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

