using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Catalog.Views;
using Catalog.Models;
using Xamarin.Forms;
using Catalog.Data;
namespace Catalog.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; }
        private Item _selectedItem;
        public Command<Item> ItemBuy { get; }
        public Command<Item> ItemTapped { get; }
        public ItemsViewModel()
        {
            Items = new ObservableCollection<Item>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);
            ItemBuy = new Command<Item>(OnItemBuy);

            ExecuteLoadItemsCommand();


        }
        public Item SelectedItem // Выбранный товар
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
                
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }
        async Task ExecuteLoadItemsCommand() //вызов на апдейт каталога
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        void OnItemBuy(Item item)
        {
            if (item == null)
                return;
            BasketViewModel.AddToBasket(item);

        }
        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");

        }
    }
}
