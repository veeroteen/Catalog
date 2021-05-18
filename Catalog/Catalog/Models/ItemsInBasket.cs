using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Models
{
    public class ItemsInBasket : Item
    {
        public int Count { get; set; }




        public ItemsInBasket() 
        {
            Count = 0;
        }


    }
}
