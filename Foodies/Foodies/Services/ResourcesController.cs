using Foodies.Views.VisualEffects;
using Foodies.VisualEffects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Foodies.Services
{
    public static class ResourcesController
    {
        public enum SubSites { Caprabo, Lidl, Menu, Recipes};
        private static SubSites _currentSubsite;
        public static SubSites CurrentSubSite
        {
            get { return _currentSubsite;  }
            set
            {
                _currentSubsite = value;


                if (ResourcesController.CurrentSubSite == ResourcesController.SubSites.Caprabo)
                    DependencyService.Get<IStatusBarColor>()?.MakeMe(CapraboBlue.ToHex());
                else if (ResourcesController.CurrentSubSite == ResourcesController.SubSites.Lidl)
                    DependencyService.Get<IStatusBarColor>()?.MakeMe(LidlBlue.ToHex());
                else if (CurrentSubSite == SubSites.Menu)
                    DependencyService.Get<IStatusBarColor>()?.MakeMe(MenuRed.ToHex());
                else if (CurrentSubSite == SubSites.Recipes)
                    DependencyService.Get<IStatusBarColor>()?.MakeMe(RecipesGreen.ToHex());


            }
        }

        public static Color CurrentAccentColor
        {
            get
            {
                if (CurrentSubSite == SubSites.Caprabo)
                    return CapraboBlue;
                else if (CurrentSubSite == SubSites.Lidl)
                    return LidlBlue;
                else if (CurrentSubSite == SubSites.Menu)
                    return MenuRed;
                else if (CurrentSubSite == SubSites.Recipes)
                    return RecipesGreen;
                else
                    return CapraboBlue;
            }
        }

        public static Color CapraboBlue;
        public static Color LidlBlue;
        public static Color MenuRed;
        public static Color RecipesGreen;
        public static Color LightGray;
        public static Color MediumGray; 
        public static Color DarkGray;

        public static ImageSource IconMeat;
        public static ImageSource IconSugar;

        public static void LoadAll()
        {
            try
            {
                CapraboBlue = (Color)Xamarin.Forms.Application.Current.Resources["CapraboBlue"];
                LidlBlue = (Color)Xamarin.Forms.Application.Current.Resources["LidlBlue"];
                MenuRed = (Color)Xamarin.Forms.Application.Current.Resources["MenuRed"];
                RecipesGreen = (Color)Xamarin.Forms.Application.Current.Resources["RecetasGreen"];
                LightGray = (Color)Xamarin.Forms.Application.Current.Resources["LightGray"];
                MediumGray = (Color)Xamarin.Forms.Application.Current.Resources["MediumGray"];
                DarkGray = (Color)Xamarin.Forms.Application.Current.Resources["DarkGray"];

                IconMeat = ImageSource.FromFile("icon_meat.png");
                IconSugar = ImageSource.FromFile("icon_sugar.png"); 
            }
            catch
            {
                throw;
            }
        }
    }
}
