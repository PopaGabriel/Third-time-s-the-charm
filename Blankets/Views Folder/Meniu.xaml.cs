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
    public partial class Meniu : ContentPage
    {
        Utilizator utilizator;
        string token;
        Utilizator[] utilizators;
        public IList<Utilizator> Users { get; private set; }
        public Meniu(Utilizator utilizator, string token, Utilizator[] utilizators)
        {
            InitializeComponent();
            Init();
            this.utilizator = utilizator;
            this.token = token;
            this.utilizators = utilizators;



            Users = new List<Utilizator>();
            foreach (Utilizator iterator in utilizators)
            {
                if(utilizator != iterator)
                    Users.Add(iterator);
            }

            BindingContext = this;
        }
        public void Init()
        {
            ListView_Prieteni.BackgroundColor = Constants.BackgroundColor;
        }
        public async void ProcedureEnterChat(object sender, EventArgs e)
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
        public async void ProcedureProfilepage(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new Test(utilizator, token));
        }
        public async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            Utilizator mydetail = e.Item as Utilizator;
            //await DisplayAlert("Alert", mydetail.username, "OK");
            

            HttpClient client = new HttpClient();
            string url = "https://iulia.rms-it.ro/api/auth/conversation/" + mydetail.id;
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage response = null;
            response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string encoded = await response.Content.ReadAsStringAsync();
                
                Message[] messages = JsonConvert.DeserializeObject<Message[]>(encoded);
                Application.Current.MainPage = new NavigationPage(new SmallPage(mydetail, utilizator, token, messages));
            }
            else
            {
                await DisplayAlert("Didn't work", "Nope", "Ok");
            }
        }
    }
}