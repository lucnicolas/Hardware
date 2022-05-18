using System;
using Hardware.Models;
using Xamarin.Essentials;

namespace Hardware.Services
{
    public class BatteryService
    {
        public event EventHandler<BatteryModel> Updated;

        public BatteryService()
        {
            Battery.BatteryInfoChanged += Battery_InfoChanged;
        }

        private void Battery_InfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            var model = new BatteryModel()
            {
                Level = e.ChargeLevel,
                State = e.State,
                Source = e.PowerSource,
            };

            Updated?.Invoke(this, model);
        }

        public BatteryModel Get()
        {
            return new BatteryModel()
            {
                Level = Battery.ChargeLevel,
                State = Battery.State,
                Source = Battery.PowerSource,
            };
        }
    }
}