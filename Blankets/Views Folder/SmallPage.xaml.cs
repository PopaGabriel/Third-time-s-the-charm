using Blankets.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blankets.Views_Folder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmallPage : ContentPage
    {
        Utilizator primitor, trimitor;
        string token;
        public string de_folosit_ca_titlu { get; set; }
        Message[] mesaje_array;
        public IList<Message> mesaje { get; private set; }
        public SmallPage(Utilizator primitor, Utilizator trimitor, string token, Message[] mesaje_array)
        {
            InitializeComponent();
            Init();
            this.primitor = primitor;
            this.trimitor = trimitor;
            this.token = token;
            de_folosit_ca_titlu = primitor.username;
            this.mesaje_array = mesaje_array;

            mesaje = new List<Message>();
            string debug = "";
            foreach (Message iterator in mesaje_array)
            {
                debug += iterator.message;
                mesaje.Add(iterator);
            }
            Console.WriteLine(debug);
            BindingContext = this;

        }
        public SmallPage()
        {
            InitializeComponent();
        }
        public void Init()
        {
            ListView_Prieteni.BackgroundColor = Constants.BackgroundColor;
        }
        public async void Send_message_SmallPage(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "https://iulia.rms-it.ro/api/auth/conversation/" + primitor.id;

            string content = String.Format("message={0}",
                        Uri.EscapeDataString(Entry_Small_Page.Text));
            HttpContent cont = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");


            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage response = null;
            response = await client.PostAsync(url, cont);

            if (response.IsSuccessStatusCode)
            {
                HttpClient client2 = new HttpClient();
                string url2 = "https://iulia.rms-it.ro/api/auth/conversation/" + primitor.id;
                client2.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response2 = null;
                response2 = await client.GetAsync(url);

                if (response2.IsSuccessStatusCode)
                {
                    string encoded = await response2.Content.ReadAsStringAsync();
                    Message[] messages = JsonConvert.DeserializeObject<Message[]>(encoded);

                    Application.Current.MainPage = new NavigationPage(new SmallPage(primitor, trimitor, token, messages));
                }
                else
                {
                    await DisplayAlert("Didn't work", "Nope", "Ok");
                }
            }
            else
            {
                await DisplayAlert("Didn't work", "Nope", "Ok");
            }
        }
        public void Send_games_SmallPage(object sender, EventArgs e)
        {

        }
        public async void Send_back_SmallPage(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "https://iulia.rms-it.ro/api/auth/all";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage response = null;
            response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string encoded = await response.Content.ReadAsStringAsync();
                Utilizator[] utilizatori = JsonConvert.DeserializeObject<Utilizator[]>(encoded);
                if (Device.RuntimePlatform == Device.Android)
                {

                    Application.Current.MainPage = new NavigationPage(new Meniu(trimitor, token, utilizatori));
                }
                else
                {
                    await Navigation.PushAsync(new Meniu(trimitor, token, utilizatori));
                }
            }
            else
            {
                await DisplayAlert("Didn't work", "Nope", "Ok");
            }
        }
        public async void Send_refresh_SmallPage(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "https://iulia.rms-it.ro/api/auth/conversation/" + primitor.id;
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage response = null;
            response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string encoded = await response.Content.ReadAsStringAsync();
                Message[] messages = JsonConvert.DeserializeObject<Message[]>(encoded);

                Application.Current.MainPage = new NavigationPage(new SmallPage(primitor, trimitor, token, messages));
            }
            else 
            {
                await DisplayAlert("Didn't work", "Nope", "Ok");
            }
        }
    }
}