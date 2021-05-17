using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Catalog.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Catalog.ViewModels;

namespace Catalog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }
        private async void RegisterClick(object sender, EventArgs e)
        {

            try
            {

                HttpResponseMessage response = null;
                using (HttpClient client = new HttpClient())
                {
                    Models.Register quest = new Models.Register();
                    quest.Login = LoginE.Text;
                    quest.Password = PasswordE.Text;
                    quest.MobilePhone = PhoneE.Text;
                    string s = NameE.Text;
                    string[] name = s.Split(new char[] { ' ' });
                    quest.SecondName = name[0];
                    quest.Name = name[1];
                    quest.FatherName = name[2];
                    var serializedData = JsonConvert.SerializeObject(quest);
                    response = await client.PostAsync("http://192.168.0.104:5000/register", new StringContent(serializedData, Encoding.UTF8, "application/json"));
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