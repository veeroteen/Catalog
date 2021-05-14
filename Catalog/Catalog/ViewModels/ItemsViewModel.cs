﻿using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Catalog.Views;
using Catalog.Models;
using Xamarin.Forms;
using Catalog.Data;
using System.Net.Http;
using Newtonsoft.Json;

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
            HttpResponseMessage response = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //пример обращения используя get запрос
                    //response = await client.GetAsync("http://192.168.0.104:5000/weatherforecast");
                    //пример обращения используя post запрос с передачей переменной встроенного типа (int)
                    //response = await client.PostAsync("http://192.168.0.104:5000/weatherforecast", new StringContent("55", Encoding.UTF8,"application/json"));


                    //пример обращения используя post запрос с передачей переменной сложного типа (Order)
                    var order = new Order
                    {
                        ClientName = "Иванов Иван Иванович",
                        Items = new[]
                        {
                            new ItemsInBasket { Count = 4, Id = "1" },
                            new ItemsInBasket { Count = 1, Id = "2" },
                            new ItemsInBasket { Count = 2, Id = "3" },
                        }
                    };
                    var serializedData = JsonConvert.SerializeObject(order);
                    response = await client.PostAsync("http://192.168.0.104:5000/Basket", new StringContent(serializedData, Encoding.UTF8,"application/json"));
                }
            }
            catch (Exception ex)
            {
                //какая то обработка

                Debug.WriteLine(ex);
                return;
            }
            var messageContent = await response.Content.ReadAsStringAsync();

            //десерилизуем, если в ответе ожиаем json:
            var desearelizedOrder = JsonConvert.DeserializeObject<Order>(messageContent);
          

            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");

        }
    }
}
