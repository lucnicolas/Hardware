using Hardware.Models;
using Hardware.Services;

namespace Hardware.ViewModels
{
    public class BatteryViewModel : BaseViewModel
    {
        private BatteryModel model;

        public BatteryModel Model
        {
            get => model; // get {return model;} // Equivalent
            set { SetProperty(ref model, value); }
        }

        public BatteryViewModel()
        {
            BatteryService service = new BatteryService();
            Model = service.Get();

            service.Updated += (sender, e) => Model = e;
        }
    }
}