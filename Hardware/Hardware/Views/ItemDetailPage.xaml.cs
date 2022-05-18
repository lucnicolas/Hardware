using System.ComponentModel;
using Hardware.ViewModels;
using Xamarin.Forms;

namespace Hardware.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}