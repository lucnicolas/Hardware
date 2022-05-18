using System;
using Hardware.Models;
using Xamarin.Essentials;

namespace Hardware.Services
{
    public class AccelerometerService
    {
        public event EventHandler<AccelerometerEventArgs> Updated;

        private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            AccelerometerModel model = new AccelerometerModel()
            {
                X = e.Reading.Acceleration.X,
                Y = e.Reading.Acceleration.Y,
                Z = e.Reading.Acceleration.Z,
            };

            Updated?.Invoke(this, new AccelerometerEventArgs { Model = model });
        }

        public void Stop()
        {
            if (!Accelerometer.IsMonitoring)
                return;

            Accelerometer.Stop();
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
        }

        public void Start()
        {
            if (Accelerometer.IsMonitoring)
                return;

            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            Accelerometer.Start(SensorSpeed.UI);
        }
    }

    public class AccelerometerEventArgs : EventArgs
    {
        public AccelerometerModel Model { get; set; }
    }
}