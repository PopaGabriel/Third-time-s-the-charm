using Blankets.Models;
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
        public void Init() {
            BackgroundColor = Constants.BackgroundColor;
            Label_Email.TextColor = Constants.MainTextColor;
            Entry_Email.TextColor = Constants.MainTextColor;
            Label_Password.TextColor = Constants.MainTextColor;
            Entry_Password.TextColor = Constants.MainTextColor;
        }
        private async void ProcedureSignIn(object sender, EventArgs e)
        {
            User user = new User(Entry_Email.Text, Entry_Password.Text);
            if (Device.RuntimePlatform == Device.Android)
            {
                if (Entry_Email.Text != null && Entry_Password.Text != null)
                {
                    // await DisplayAlert("Alert", Entry_Username.Text + " " + Entry_Password.Text, "OK");
                    HttpClient client = new HttpClient();
                    LoginData login_attempt = new LoginData();
                    login_attempt.Usercode = Entry_Email.Text;
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
                        await DisplayAlert("Worked", "Yes", "Ok");
                    }
                    else
                    {
                        await DisplayAlert("Didn't work", "Nope", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Alert", "Please insert both your Email and your password", "OK");
                }
                Application.Current.MainPage = new NavigationPage(new Test(user));
            }
            else
            {
                await Navigation.PushAsync(new Test(user));
            }
        }
        private async void ProcedureSignUp(object sender, EventArgs e)
        {
            User user = new User(Entry_Email.Text, Entry_Password.Text);
            if (Device.RuntimePlatform == Device.Android)
            {
                //De schimbat
                Application.Current.MainPage = new NavigationPage(new SignUpPage());
            }
            else
            {
                await Navigation.PushAsync(new Test(user));
            }
        }
    }
}