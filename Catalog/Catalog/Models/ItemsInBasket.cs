using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Models
{
    public class ItemsInBasket
    {
        public int Count { get; set; }

        public Item item { get; set; }


        public ItemsInBasket() 
        {
            Count = 0;
        }


    }
}
