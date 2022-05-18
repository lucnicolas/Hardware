using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Hardware.Converters
{
    public class BatteryStateConverter : IValueConverter
    {
        private Dictionary<BatteryState, string> fr = new Dictionary<BatteryState, string>()
        {
            {BatteryState.Charging, "Charge en cours"},
            {BatteryState.Full, "Pleine"},
            // etc...
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is BatteryState state))
                return "";

            // On utilise normalement la culture passée en paramètre pour déterminer la langue

            return
                fr.TryGetValue(state, out string text)
                ? text
                : "Valeur inconnue";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}