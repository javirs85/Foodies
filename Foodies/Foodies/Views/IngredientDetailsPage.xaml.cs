using Foodies.Models;
using Foodies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foodies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientDetailsPage : ContentPage
    {
        public IngredientDetailsPage(IngredientDetailViewModel viewModel)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            BindingContext = viewModel;
            SelectedUnits.SelectedIndex = 0;
        }
    }
}