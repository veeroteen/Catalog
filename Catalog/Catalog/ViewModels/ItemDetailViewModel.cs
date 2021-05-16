using System;
using System.Collections.Generic;
using System.Text;
using Catalog.Models;
using Xamarin.Forms;
using System;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;

namespace Catalog.ViewModels
{

    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        public string Id { get; set; }
        public ItemDetail Item { get; set; }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                Item.item = await DataStore.GetItemAsync(itemId);
                HttpResponseMessage response = null;
                using (HttpClient client = new HttpClient())
                {
                        //пример обращения используя get запрос
                        //response = await client.GetAsync("http://192.168.0.104:5000/weatherforecast");
                        //пример обращения используя post запрос с передачей переменной встроенного типа (int)
                        //response = await client.PostAsync("http://192.168.0.104:5000/weatherforecast", new StringContent("55", Encoding.UTF8,"application/json"));


                        //пример обращения используя post запрос с передачей переменной сложного типа (Order)
                        
                        var serializedData = JsonConvert.SerializeObject(itemId);
                        response = await client.PostAsync("http://192.168.0.104:5000/basket", new StringContent(serializedData, Encoding.UTF8, "application/json"));
                        var messageContent = await response.Content.ReadAsStringAsync();
                    Item.Detail = JsonConvert.DeserializeObject<ItemDetailDescription>(messageContent);
                }
                
                
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
