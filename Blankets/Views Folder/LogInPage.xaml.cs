using Blankets.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blankets.Views_Folder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Label_UserName.TextColor = Constants.MainTextColor;
            Entry_Username.TextColor = Constants.MainTextColor;
            Label_Password.TextColor = Constants.MainTextColor;
            Entry_Password.TextColor = Constants.MainTextColor;
        }
        public bool check_username(string username)
        {
            if (username.Contains("DROP DATABASE") || username.Contains("DROP TABLE") ||
                username.Contains("DELETE DATABASE") || username.Contains("DELETE TABLE"))
                return false;
            return true;
        }
        private async void ProcedureSignIn(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                if (Entry_Username.Text != null && Entry_Password.Text != null && check_username(Entry_Username.Text))
                {
                    // await DisplayAlert("Alert", Entry_Username.Text + " " + Entry_Password.Text, "OK");
                    HttpClient client = new HttpClient();
                    LoginData login_attempt = new LoginData();
                    login_attempt.Usercode = Entry_Username.Text;
                    login_attempt.Password = Entry_Password.Text;

                    // la adresa de login
                    string url = "https://iulia.rms-it.ro/api/auth/login";

                    // se formateaza sirurile pentru a putea fi folosite de server
                    string content = String.Format("email={0}&password={1}",
                        Uri.EscapeDataString(login_attempt.Usercode),
                        Uri.EscapeDataString(login_attempt.Password));

                    // se cripteaza
                    HttpContent cont = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");

                    // se adauga un header
                    cont.Headers.Add("x-requested-with", "XMLHttpRequest");
                    HttpResponseMessage response = null;

                    // se apeleaza propriu zis serverul
                    response = await client.PostAsync(url, cont);
                    if (response.IsSuccessStatusCode)
                    {
                        string encoded = await response.Content.ReadAsStringAsync();
                        Root decoded = JsonConvert.DeserializeObject<Root>(encoded);

                        HttpClient client2 = new HttpClient();
                        string url2 = "https://iulia.rms-it.ro/api/auth/user";
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + decoded.access_token);
                        HttpResponseMessage response2 = null;
                        response2 = await client.GetAsync(url2);

                        if (response2.IsSuccessStatusCode)
                        {
                            string encoded2 = await response2.Content.ReadAsStringAsync();
                            Utilizator utilizator = JsonConvert.DeserializeObject<Utilizator>(encoded2);
                            await DisplayAlert("Debug", utilizator.username + utilizator.email, "Ok");
                            Application.Current.MainPage = new NavigationPage(new Test(utilizator, decoded.access_token));
                        }
                        else
                        {
                            await DisplayAlert("Didn't work2", "Nope", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Didn't work1", "Nope", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Please insert both username and password", "OK");
                }

            }
            else
            {
                if (Entry_Username.Text != null && Entry_Password.Text != null && check_username(Entry_Username.Text))
                {
                    // await DisplayAlert("Alert", Entry_Username.Text + " " + Entry_Password.Text, "OK");
                    HttpClient client = new HttpClient();
                    LoginData login_attempt = new LoginData();
                    login_attempt.Usercode = Entry_Username.Text;
                    login_attempt.Password = Entry_Password.Text;

                    // la adresa de login
                    string url = "https://iulia.rms-it.ro/api/auth/login";

                    // se formateaza sirurile pentru a putea fi folosite de server
                    string content = String.Format("email={0}&password={1}",
                        Uri.EscapeDataString(login_attempt.Usercode),
                        Uri.EscapeDataString(login_attempt.Password));

                    // se cripteaza
                    HttpContent cont = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");

                    // se adauga un header
                    cont.Headers.Add("x-requested-with", "XMLHttpRequest");
                    HttpResponseMessage response = null;

                    // se apeleaza propriu zis serverul
                    response = await client.PostAsync(url, cont);
                    if (response.IsSuccessStatusCode)
                    {
                        string encoded = await response.Content.ReadAsStringAsync();
                        Root decoded = JsonConvert.DeserializeObject<Root>(encoded);

                        HttpClient client2 = new HttpClient();
                        string url2 = "https://iulia.rms-it.ro/api/auth/user";
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + decoded.access_token);
                        HttpResponseMessage response2 = null;
                        response2 = await client.GetAsync(url2);

                        if (response2.IsSuccessStatusCode)
                        {
                            string encoded2 = await response.Content.ReadAsStringAsync();
                            Utilizator utilizator = JsonConvert.DeserializeObject<Utilizator>(encoded2);
                            await Navigation.PushAsync(new Test(utilizator, decoded.access_token));
                        }
                        else
                        {
                            await DisplayAlert("Didn't work2", "Nope", "Ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Didn't work1", "Nope", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Please insert both username and password", "OK");
                }
            }
        }
        private async void ProcedureSignUp(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                //De schimbat
                Application.Current.MainPage = new NavigationPage(new SignUpPage());
            }
            else
            {
                await Navigation.PopAsync();
            }
        }
    }
}