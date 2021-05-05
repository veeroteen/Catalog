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
        ItemsViewModel _viewModel;
        public ItemsView()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();



        }


    }
}