using Hardware.Services;
using Xamarin.Forms;

namespace Hardware.ViewModels
{
    public class VibratorViewModel
    {
        private readonly VibratorService service = new VibratorService();

        public Command<double> VibrateCommand { get; set; }
        public Command CancelCommand { get; set; }

        public VibratorViewModel()
        {
            VibrateCommand = new Command<double>(
                (parameter) => service.Vibrate(parameter),
                (parameter) => !service.IsVibrating && parameter != 0.0);

            CancelCommand = new Command(
                () => service.Cancel(),
                () => service.IsVibrating);

            service.IsVibratingChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    VibrateCommand.ChangeCanExecute();
                    CancelCommand.ChangeCanExecute();
                });
            };
        }
    }
}