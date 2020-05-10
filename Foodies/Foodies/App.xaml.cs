using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Foodies.Services;
using Foodies.Views;

namespace Foodies
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            ResourcesController.LoadAll();

            DependencyService.Register<WebDataStorage>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
