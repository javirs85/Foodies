using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Foodies.Models;
using Foodies.Services;

namespace Foodies.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            ResourcesController.CurrentSubSite = ResourcesController.SubSites.Caprabo;
            MenuPages.Add((int)ResourcesController.SubSites.Caprabo, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)ResourcesController.SubSites.Caprabo:
                        MenuPages.Add(id, new NavigationPage(new CapraboPage()));
                        break;
                    case (int)ResourcesController.SubSites.Lidl:
                        MenuPages.Add(id, new NavigationPage(new LidlPage()));
                        break;
                    case (int)ResourcesController.SubSites.Menu:
                        MenuPages.Add(id, new NavigationPage(new WeeklyMenuPage()));
                        break;
                    case (int)ResourcesController.SubSites.Recipes:
                        MenuPages.Add(id, new NavigationPage(new RecipesPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}