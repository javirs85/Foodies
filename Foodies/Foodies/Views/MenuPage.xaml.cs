using Foodies.Models;
using Foodies.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Foodies.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        private ViewCell lastViewTapped;
       

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = ResourcesController.SubSites.Caprabo, Title="Caprabo list" },
                new HomeMenuItem {Id = ResourcesController.SubSites.Lidl, Title="LIDL LIST" },
                new HomeMenuItem {Id = ResourcesController.SubSites.Menu, Title = "menu"},
                new HomeMenuItem {Id = ResourcesController.SubSites.Recipes, Title = "recetas"}
            };

            menuItems.ForEach(x => x.Title = x.Title.ToUpper());

            ListViewMenu.ItemsSource = menuItems;

            //ListViewMenu.SelectedItem = menuItems[0];

            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var subsis = (e.SelectedItem as HomeMenuItem).Id;
                var id = (int)(subsis);
                ResourcesController.CurrentSubSite = subsis;
                await RootPage.NavigateFromMenu(id);
            };


        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var selectedItem = sender as ViewCell;

            Colorice(selectedItem);

            if (lastViewTapped != null)
            {
                lastViewTapped.View.BackgroundColor = Color.Transparent;
                var elem = (lastViewTapped.View as Grid).Children.ElementAt(0);
                (elem as Label).TextColor = Color.Gray;
            }

            lastViewTapped = selectedItem;
        }

        private static void Colorice(ViewCell selectedItem)
        {
            var ctx = selectedItem.BindingContext as HomeMenuItem;

            if (ctx.Id == ResourcesController.SubSites.Caprabo)
                selectedItem.View.BackgroundColor = ResourcesController.CapraboBlue;
            else if (ctx.Id == ResourcesController.SubSites.Lidl)
            {
                selectedItem.View.BackgroundColor = ResourcesController.LidlBlue;
                var elem = (selectedItem.View as Grid).Children.ElementAt(0);
                (elem as Label).TextColor = Color.White;
                //selectedItem.View.
            }
            else if (ctx.Id == ResourcesController.SubSites.Menu)
                selectedItem.View.BackgroundColor = ResourcesController.MenuRed;
            else if (ctx.Id == ResourcesController.SubSites.Recipes)
                selectedItem.View.BackgroundColor = ResourcesController.RecipesGreen;
        }
    }
}