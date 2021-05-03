using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Catalog
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Bind : ContentPage
    {
        public Bind()
        {
            InitializeComponent();
            BindingContext = new VeiwModelM();
            
        }
    }
}