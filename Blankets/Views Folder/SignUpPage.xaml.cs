using Blankets.Models;
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
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Label_UserName.TextColor = Constants.MainTextColor;
            Entry_Username.TextColor = Constants.MainTextColor;
            Label_Password.TextColor = Constants.MainTextColor;
            Entry_Password.TextColor = Constants.MainTextColor;
            Label_IdWork.TextColor = Constants.MainTextColor;
            Entry_IdWork.TextColor = Constants.MainTextColor;
            Label_Email.TextColor = Constants.MainTextColor;
            Entry_Email.TextColor = Constants.MainTextColor;
        }
        private async void ProcedureSignUp(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (Entry_Username.Text != null && Entry_Password.Text != null && Entry_IdWork.Text != null && Entry_Email.Text != null)
            {
                // await DisplayAlert("Alert", Entry_Username.Text + " " + Entry_Password.Text, "OK");
                HttpClient client = new HttpClient();
                Utilizator utilizator = new Utilizator();
                utilizator.username = Entry_Username.Text;
                utilizator.password = Entry_Password.Text;
                utilizator.IdWork = Entry_IdWork.Text;
                utilizator.email = Entry_Email.Text;

                // la adresa de login
                string url = "https://iulia.rms-it.ro/api/auth/login";

                // se formateaza sirurile pentru a putea fi folosite de server
                string content = String.Format("username={0}&password={1}&IdWork={3}&email={4}",
                    Uri.EscapeDataString(utilizator.username),
                    Uri.EscapeDataString(utilizator.password),
                    Uri.EscapeDataString(utilizator.IdWork),
                    Uri.EscapeDataString(utilizator.email));

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
                await DisplayAlert("Alert", "Please insert both username and password", "OK");
            }
            Application.Current.MainPage = new NavigationPage(new Test(user));
        }
        private async void ProcedureSignUpGoBack(object sender, EventArgs e)
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
    }
}