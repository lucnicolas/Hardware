using Hardware.Models;
using Hardware.Services;

namespace Hardware.ViewModels
{
    public class AppInfoViewModel
    {
        public AppInfoModel Model { get; set; }

        public AppInfoViewModel()
        {
            AppInfoService service = new AppInfoService();
            Model = service.Get();
        }
    }
}