using Blankets.Models;
using Blankets.Views_Folder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blankets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        Utilizator user_current;
        string token;
        public Test(Utilizator utilizator, string token)
        {
            this.token = token;
            user_current = utilizator;
            InitializeComponent();
            ProfileName.Text = "Username: " + utilizator.username;
            Email.Text = "Email: " + utilizator.email;
            Work_Position.Text = "Position: CEO";
            ProfileCompany.Text = "Company: DB";
        }
        private async void ChangeAccountDetails(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChangeValues(user_current));
        }
        private async void ProcedureLogout(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                Application.Current.MainPage = new NavigationPage(new Page1());
            }
            else
            {
                await Navigation.PushAsync(new Page1());
            }
        }
        private async void ProcedureMenu(object sender, EventArgs e)
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
                    
                    Application.Current.MainPage = new NavigationPage(new Meniu(user_current, token, utilizatori));
                }
                else
                {
                    await Navigation.PushAsync(new Meniu(user_current, token, utilizatori));
                }
            }
            else
            {
                await DisplayAlert("Didn't work", "Nope", "Ok");
            }
            
        }
        private void ProcedureChangePhoto(object sender, EventArgs e)
        {
            //Aici teoretic schimbam poza
        }
    }
}