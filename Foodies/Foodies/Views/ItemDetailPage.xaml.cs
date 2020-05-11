using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Foodies.Models;
using Foodies.ViewModels;

namespace Foodies.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        IngredientDetailViewModel viewModel;

        public ItemDetailPage(IngredientDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new FoodItem
            {
                Name = "Item 1",
                UnitsID = 22
            };

            viewModel = new IngredientDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}