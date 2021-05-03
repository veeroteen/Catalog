using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Catalog
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            List <Grid> gg = new List<Grid>();

            Image img = new Image();
            

            for (int i = 0; i < 10; i++)
            {

                gg.Add
                    (
                    new Grid()
                    {
                        BackgroundColor = Color.LightGray,
                        Children =
                        {
                            new Label() { Text = "123", Margin = new Thickness(150,10) },
                            new Button() { Text = "Buy", Margin = new Thickness(250, 50, 5, 5) },
                            new Label() { Text = "456 руб.", Margin = new Thickness(270, 5, 5, 5) },
                            new Image() { Scale=0.5, HorizontalOptions= LayoutOptions.Start, Source="ss.jpg", BackgroundColor = Color.Black, Margin= new Thickness(1,1)}
                        },



                    }
                    );
                stacklay.Children.Add(gg[i]);


            }
            
        }
    }
}
