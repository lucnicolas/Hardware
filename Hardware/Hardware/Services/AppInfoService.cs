using Hardware.Models;
using Xamarin.Essentials;

namespace Hardware.Services
{
    public class AppInfoService
    {
        public AppInfoModel Get()
        {
            return new AppInfoModel()
            {
                Name = AppInfo.Name,
                Package = AppInfo.PackageName,
                Version = AppInfo.VersionString,
            };
        }
    }
}