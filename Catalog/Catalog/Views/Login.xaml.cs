using Catalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Catalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void RegisterClick(object sender, EventArgs e)
        {
            Register register = new Register();
            await Navigation.PushAsync(register);
        }
        private async void LoginClick(object sender, EventArgs e)
        {

            try
            {
                
                HttpResponseMessage response = null;
                using (HttpClient client = new HttpClient())
                {
                    Models.Login quest = new Models.Login();
                    quest.login = LoginE.Text;
                    quest.password = PassordE.Text;

                    var serializedData = JsonConvert.SerializeObject(quest);
                    response = await client.PostAsync("http://192.168.0.104:5000/login", new StringContent(serializedData, Encoding.UTF8, "application/json"));
                    var messageContent = await response.Content.ReadAsStringAsync();
                    User.ID = JsonConvert.DeserializeObject<string>(messageContent);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
            if (User.ID != null)

            {
                ItemsViewModel.logged = true;
                await Shell.Current.GoToAsync($"//{nameof(ItemsView)}");
                return;
            }

        }
    }
}