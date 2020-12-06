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
    public partial class BigChat : ContentPage
    {
        Utilizator utilizator;
        string token;
        public IList<Message> mesaje { get; private set; }
        public BigChat(Utilizator utilizator, string token, Message[] messages)
        {
            this.utilizator = utilizator;
            InitializeComponent();
            Init();
            this.utilizator = utilizator;
            this.token = token;
            mesaje = new List<Message>();

            string debug = "";
            foreach (Message iterator in messages)
            {
                debug += iterator.message;
                mesaje.Add(iterator);
            }
            Console.WriteLine(debug);
            BindingContext = this;
        }
        public BigChat()
        {
            InitializeComponent();
        }
        public void Init()
        {
            ListView_Prieteni.BackgroundColor = Constants.BackgroundColor;
        }
        public async void Send_messageBigPage(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "https://iulia.rms-it.ro/api/auth/group";

            string content = String.Format("message={0}",
                        Uri.EscapeDataString(Entry_Big_Page.Text));
            HttpContent cont = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");


            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage response = null;
            response = await client.PostAsync(url, cont);

            if (response.IsSuccessStatusCode)
            {
                HttpClient client2 = new HttpClient();
                string url2 = "https://iulia.rms-it.ro/api/auth/group";
                client2.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                HttpResponseMessage response2 = null;
                response2 = await client.GetAsync(url);

                if (response2.IsSuccessStatusCode)
                {
                    string encoded = await response2.Content.ReadAsStringAsync();
                    Message[] messages = JsonConvert.DeserializeObject<Message[]>(encoded);

                    Application.Current.MainPage = new NavigationPage(new BigChat(utilizator, token, messages));
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
        public async void Send_refresh_BigPage(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string url = "https://iulia.rms-it.ro/api/auth/group";
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage response = null;
            response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string encoded = await response.Content.ReadAsStringAsync();
                Message[] messages = JsonConvert.DeserializeObject<Message[]>(encoded);

                Application.Current.MainPage = new NavigationPage(new BigChat(utilizator, token, messages));
            }
            else
            {
                await DisplayAlert("Didn't work", "Nope", "Ok");
            }
        }
        public async void Send_back_BigPage(object sender, EventArgs e)
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

                    Application.Current.MainPage = new NavigationPage(new Meniu(utilizator, token, utilizatori));
                }
                else
                {
                    await Navigation.PushAsync(new Meniu(utilizator, token, utilizatori));
                }
            }
            else
            {
                await DisplayAlert("Didn't work", "Nope", "Ok");
            }
        }
        public void Send_games_BigPage(object sender, EventArgs e)
        {
            //A nu se implementa!!!!
        }
    }
}