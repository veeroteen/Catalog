using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Catalog.Views;
using Catalog.Models;
using Xamarin.Forms;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Catalog.ViewModels
{
    public class BasketViewModel : INotifyPropertyChanged
    {

        
        public static ObservableCollection<ItemsInBasket> BasketItemList { get; set; } = BasketItemList = new ObservableCollection<ItemsInBasket>();

        public BasketViewModel()
        {
            

        }

        
        public static void AddToBasket(Item item) 
        {
            bool b = true;

            var nn = from bitem in BasketItemList
                     where bitem.Id == item.Id
                     select bitem;
            foreach (ItemsInBasket bitem in nn)
            {
                bitem.Count++;
                b = false;
            }

            if (b)
            {
                BasketItemList.Add(new ItemsInBasket()
                {
                    Description = item.Description,
                    Id = item.Id,
                    Img = item.Img,
                    Text = item.Text,
                    Count = 1
                });
            }


        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
