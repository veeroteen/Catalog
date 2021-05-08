using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Catalog.Views;
using Catalog.Data;
using Catalog.Services;

namespace Catalog
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ItemData>();
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
