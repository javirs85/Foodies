using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Foodies.Models;
using Foodies.Views;
using Foodies.ViewModels;
using Foodies.Services;

namespace Foodies.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LidlPage : ContentPage
    {
        IngredientListViewModel viewModel;

        public LidlPage()
        {
            InitializeComponent();

            ResourcesController.CurrentSubSite = ResourcesController.SubSites.Lidl;
            BindingContext = viewModel = new IngredientListViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (FoodItem)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new IngredientSelectorPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Ingredients.Count == 0)
                viewModel.IsBusy = true;

            ((Application.Current.MainPage as MainPage).Detail as NavigationPage).BarBackgroundColor = ResourcesController.LidlBlue;
        }
    }
}