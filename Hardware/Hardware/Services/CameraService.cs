using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Hardware.Services
{
    public class CameraService
    {
        public async Task<Stream> TakePhotoAsync()
        {
            try
            {
                FileResult photo = await MediaPicker.CapturePhotoAsync();
                return await photo.OpenReadAsync();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                throw new CameraException(CameraError.FeatureNotSupported, fnsEx);
            }
            catch (PermissionException pEx)
            {
                throw new CameraException(CameraError.PermissionNotGranted, pEx);
            }
            catch (Exception ex)
            {
                throw new CameraException(CameraError.Unknown, ex);
            }
        }
    }

    public class CameraException : Exception
    {
        public CameraError Error { get; }

        public CameraException(CameraError error, Exception innerException)
            : base(error.ToString(), innerException)
        {
            Error = error;
        }
    }

    public enum CameraError
    {
        Unknown, FeatureNotSupported, PermissionNotGranted
    }
}