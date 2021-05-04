using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Catalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsView : ContentPage
    {
        private ItemsViewModel mod;
        public ItemsView()
        {
            InitializeComponent();

            mod = new ItemsViewModel();
            mod.LoadList(stacklay);



        }


    }
}