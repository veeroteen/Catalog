using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Views;
using Catalog.Models;
using Xamarin.Forms;
namespace Catalog.ViewModels
{
    static class BasketViewModel
    {

        public static StackLayout stack;
        public static List<Item> ItemList;

        public static void AddToBasket(Item item) 
        {
            ItemList = new List<Item>();
            ItemList.Add(item);

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

                        },



                    }
                    );
                stack.Children.Add(gg[i]);


            }








        }


    }
}
