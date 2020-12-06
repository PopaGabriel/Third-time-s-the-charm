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
        public IList<Message> mesaje { get; private set; }
        public SmallPage(Utilizator primitor, Utilizator trimitor, string token)
        {
            InitializeComponent();
            //Init();
            this.primitor = primitor;
            this.trimitor = trimitor;
            this.token = token;
            de_folosit_ca_titlu = primitor.username;
        }
        public SmallPage()
        {
            InitializeComponent();
        }
        //public void Init()
        //{
        //    ListView_Prieteni.BackgroundColor = Constants.BackgroundColor;
        //}
        public void Send_message_SmallPage(object sender, EventArgs e)
        {
            
        }
        public void Send_games_SmallPage(object sender, EventArgs e)
        {

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
                string str = "";
                Message[] messages = JsonConvert.DeserializeObject<Message[]>(encoded);

                mesaje = new List<Message>();
                
                foreach (Message iterator in messages)
                {
                    str += iterator.message;
                    mesaje.Add(iterator);
                }
                await DisplayAlert("Ceva", str, "Ok");
                BindingContext = this;
            }
            else 
            {
                await DisplayAlert("Didn't work", "Nope", "Ok");
            }
        }
    }
}