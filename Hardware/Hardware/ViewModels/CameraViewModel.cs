using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Hardware.Services;
using Xamarin.Forms;

namespace Hardware.ViewModels
{
    public class CameraViewModel : BaseViewModel
    {
        private ImageSource image;
        private string error;
        private readonly CameraService service;

        public string Error
        {
            get => error;
            set => SetProperty(ref error, value);
        }

        public ImageSource Image
        {
            get => image;
            set => SetProperty(ref image, value);
        }

        public ICommand CaptureCommand { get; set; }

        public CameraViewModel()
        {
            service = new CameraService();
            CaptureCommand = new Command(async () => await CaptureAsync());
        }

        private async Task CaptureAsync()
        {
            try
            {
                Stream photo = await service.TakePhotoAsync();
                Image = ImageSource.FromStream(() => photo);
                Error = "";
            }
            catch (CameraException ex)
            {
                Error = ex.Error.ToString(); //TODO Aller chercher la traduction dans les ressources
            }
        }
    }
}