using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Views;
using Catalog.Model;
using Xamarin.Forms;

namespace Catalog.ViewModels
{
    class ItemsViewModel
    {
        public List<Item> ItemList { get; }


        public ItemsViewModel()
        {
            ItemList = new List<Item>();



            for (int i = 0; i < 10; i++)
            {
                ItemList.Add
                    (
                    new Item() { 
                        Id = $"{i}", 
                        Text = $"Товар {i}", 
                        Description = "asdhfath", 
                        Img = new Image() { Scale = 0.5, HorizontalOptions = LayoutOptions.Start, Source = "ss.jpg", BackgroundColor = Color.Black, Margin = new Thickness(1, 1) } }

                    );
            }

        }

        public void LoadList(StackLayout stack)
        {
            List<Grid> gg = new List<Grid>();



            for (int i = 0; i < ItemList.Count; i++)
            {

                gg.Add
                    (
                    new Grid()
                    {
                        BackgroundColor = Color.LightGray,
                        Children =
                        {
                            new Label() { Text = ItemList[i].Text, Margin = new Thickness(150,10) },
                            new Button() { Text = "Buy", Margin = new Thickness(250, 50, 5, 5) },
                            new Label() { Text = ItemList[i].Description, Margin = new Thickness(270, 5, 5, 5) },
                            ItemList[i].Img
                        },



                    }
                    );
                stack.Children.Add(gg[i]);


            }

        }


    }
}
