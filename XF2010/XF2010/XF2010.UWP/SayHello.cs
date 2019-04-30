using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using XF2010.Services;

[assembly: Xamarin.Forms.Dependency(typeof(XF2010.UWP.SayHello))]
namespace XF2010.UWP
{
    public class SayHello : ISayHello
    {
        public string Hello()
        {
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            var foo= string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
            return $"這是 UWP 系統 {foo}";
        }
    }
}
