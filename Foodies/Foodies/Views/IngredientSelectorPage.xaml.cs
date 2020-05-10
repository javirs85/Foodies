using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Foodies.Models;
using System.Collections.ObjectModel;
using Foodies.ViewModels;
using System.Linq;
using Foodies.Services;

namespace Foodies.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class IngredientSelectorPage : ContentPage
    {
        IngredientListViewModel viewModel;
        ImageSource clearIcon;
        ImageSource GlassIcon;

        public IngredientSelectorPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            BorderFrame.BackgroundColor = Foodies.Services.ResourcesController.CurrentAccentColor;
            BindingContext = viewModel = new IngredientListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Ingredients.Count == 0)
                viewModel.IsBusy = true;

            BorderFrame.BackgroundColor = Color.White;

            clearIcon = ImageSource.FromFile("clearButton.png");
            if(ResourcesController.CurrentSubSite == ResourcesController.SubSites.Caprabo)
            {
                GlassIcon = ImageSource.FromFile("searchCapraboblue.png");
                BorderFrame.BorderColor = (Color) Application.Current.Resources["CapraboBlue"];
            }
            else if(ResourcesController.CurrentSubSite == ResourcesController.SubSites.Lidl)
            {
                GlassIcon = ImageSource.FromFile("searchLidlblue.png");
                BorderFrame.BorderColor = (Color)Application.Current.Resources["LidlBlue"];
            }
            SearchIcon.Source = GlassIcon;
        }

        private void SearchBoxEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchBoxEntry.Text == "")
            {
                IngredientsView.ItemsSource = viewModel.Ingredients;
                SearchIcon.Source = GlassIcon;
            }
            else
            {
                var ingredientesMatching = viewModel.Ingredients.Where(c => c.Name.ToLower().Contains(SearchBoxEntry.Text.ToLower()));
                IngredientsView.ItemsSource = ingredientesMatching;
                SearchIcon.Source = clearIcon;
            }
            int count = 0;

            foreach (var item in IngredientsView.ItemsSource)
            {
                count++;
                if (count == 9)
                    break;
            }

            if (count < 9)
            {
                SearchPanel.HeightRequest = 60;
                IngredientsView.VerticalOptions = LayoutOptions.Start;
                RefreshViewControl.VerticalOptions = LayoutOptions.Start;
                int newHeigh = count * 63;
                IngredientsView.HeightRequest = newHeigh;
                RefreshViewControl.HeightRequest = newHeigh;
            }
            else
            {
                SearchPanel.HeightRequest = 60;
                IngredientsView.HeightRequest = -1;
                RefreshViewControl.HeightRequest = -1;
                IngredientsView.VerticalOptions = LayoutOptions.StartAndExpand;
                RefreshViewControl.VerticalOptions = LayoutOptions.StartAndExpand;
            }
        }

        private void AddIngredientButtonClicked(object sender, EventArgs e)
        {
        }

        private void CreateNewIngredientClicked(object sender, EventArgs e)
        {
        }

        private void IngredientsView_SizeChanged(object sender, EventArgs e)
        {
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SearchBoxEntry.Text = "";
        }
    }
}