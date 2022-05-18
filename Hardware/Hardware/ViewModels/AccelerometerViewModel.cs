using System;
using Hardware.Models;
using Hardware.Services;

namespace Hardware.ViewModels
{
    public class AccelerometerViewModel : BaseViewModel
    {
        private AccelerometerModel model = new AccelerometerModel();
        private AccelerometerService service = new AccelerometerService();

        public AccelerometerModel Model
        {
            get => model;
            set { SetProperty(ref model, value); }
        }

        public AccelerometerViewModel()
        {
            service.Updated += (sender, e) => Model = e.Model;
        }

        public void Start()
        {
            service.Start();
        }

        public void Stop()
        {
            service.Stop();
        }
    }
}