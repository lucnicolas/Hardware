using System;
using System.Collections.Generic;
using System.ComponentModel;
using Hardware.Models;
using Hardware.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hardware.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}