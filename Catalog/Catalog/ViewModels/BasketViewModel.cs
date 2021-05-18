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
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Catalog.ViewModels
{
    public class BasketViewModel : INotifyPropertyChanged
    {

      
        public static ObservableCollection<ItemsInBasket> Items { get; set; } = new ObservableCollection<ItemsInBasket>();
        public Command<Item> ItemTapped { get; }
        public Command PostOrder { get; }
        public BasketViewModel()
        {

            ItemTapped = new Command<Item>(OnItemSelected);
            PostOrder = new Command(OnOrderClick);
            LoadBasket();

        }

        
        public static async Task AddToBasket(Item item) 
        {
            /*
            var BasketItem = Items.FirstOrDefault(bi => bi.Id == item.Id);
            if (BasketItem == null)
            {
                Items.Add(new ItemsInBasket()
                {
                    
                    Count = 1

                });
            }
            else
            {
                Items.FirstOrDefault(bi => bi.Id == item.Id).Count++;

            }
            */
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //пример обращения используя get запрос
                    //response = await client.GetAsync("http://192.168.0.104:5000/weatherforecast");
                    //пример обращения используя post запрос с передачей переменной встроенного типа (int)
                    //response = await client.PostAsync("http://192.168.0.104:5000/weatherforecast", new StringContent("55", Encoding.UTF8,"application/json"));


                    //пример обращения используя post запрос с передачей переменной сложного типа (Order)
                    var quest = new Order
                    {
                        IDProduct = item.Id,
                        ClientID = User.ID,
                    };

                    var serializedData = JsonConvert.SerializeObject(quest);
                    await client.PostAsync("http://192.168.0.104:5000/basket", new StringContent(serializedData, Encoding.UTF8, "application/json"));
                }
            }
            catch (Exception ex)
            {
                //какая то обработка

                Debug.WriteLine(ex);
                return;
            }
            await LoadBasket();
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
        async void OnOrderClick()
        {

            await PostOrderAsync();

        }
        public static async Task PostOrderAsync() 
        {


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //пример обращения используя get запрос
                    //response = await client.GetAsync("http://192.168.0.104:5000/weatherforecast");
                    //пример обращения используя post запрос с передачей переменной встроенного типа (int)
                    //response = await client.PostAsync("http://192.168.0.104:5000/weatherforecast", new StringContent("55", Encoding.UTF8,"application/json"));


                    //пример обращения используя post запрос с передачей переменной сложного типа (Order)
                    
                    var serializedData = JsonConvert.SerializeObject(User.ID);
                    await client.PostAsync("http://192.168.0.104:5000/order", new StringContent(serializedData, Encoding.UTF8, "application/json"));
                }
            }
            catch (Exception ex)
            {
                //какая то обработка

                Debug.WriteLine(ex);
                return;
            }
            

            


        }

        public async static Task LoadBasket()
        {
            Items.Clear();
            HttpResponseMessage response = null;

            try
            {
                
                using (HttpClient client = new HttpClient())
                {

                    
                    var serializedData = JsonConvert.SerializeObject(User.ID);
                    response = await client.PostAsync("http://192.168.0.104:5000/basketload", new StringContent(serializedData, Encoding.UTF8, "application/json"));

                    var messageContent = await response.Content.ReadAsStringAsync();

                    string s = "1";
                    s = s + messageContent;
                    var f = JsonConvert.DeserializeObject<ItemsInBasket>(messageContent);
                    
                        Items.Add(f);

                    
                }
            }
            catch (Exception ex)
            {
                //какая то обработка

                Debug.WriteLine(ex);
                return;
            }


        }



    }
}
