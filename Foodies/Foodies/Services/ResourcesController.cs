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
                if (CurrentSubSite == SubSites.Caprabo)
                {
                    var dp = DependencyService.Get<IStatusBarColor>();
                    dp?.MakeMe(Color.Blue.ToHex());
                }
                else if (CurrentSubSite == SubSites.Lidl)
                {
                    try
                    {
                        var statusBarColor = DependencyService.Get<IStatusBarColor>();
                        statusBarColor?.MakeMe(Color.Blue.ToHex());
                    }
                    catch (Exception e)
                    {
                        int a = 2;
                        a++;
                    }
                }
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
            }
            catch
            {
                throw;
            }
        }
    }
}
