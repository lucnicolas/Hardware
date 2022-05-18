using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hardware.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hardware.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccelerometerView : ContentPage
    {
        public AccelerometerView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Démarrer l'acc
            (BindingContext as AccelerometerViewModel).Start();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Arrêter l'acc
            (BindingContext as AccelerometerViewModel).Stop();
        }
    }
}