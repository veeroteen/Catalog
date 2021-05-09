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
        public Command<Item> ItemTapped { get; }

        public BasketViewModel()
        {

            ItemTapped = new Command<Item>(OnItemSelected);
        }

        
        public static void AddToBasket(Item item) 
        {
            var BasketItem = BasketItemList.FirstOrDefault(bi => bi.Id == item.Id);
            if(BasketItem != null) 
            {
                BasketItem.Count++;
            }
            else
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
        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");

        }
    }
}
