using Blankets.Views_Folder;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Blankets
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Page1();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
    public class LoginData
    {
        [JsonProperty("Usercode")]
        public string Usercode { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }

    }
    public class Utilizator
    {
        public string username { get; set; }
        public string password { get; set; }
        public string IdWork { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public override string ToString()
        {
            return username;
        }
    }
    public class Root
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_at { get; set; }

    }
    public class Message
    {
        public string senderId { get; set; }
        public string message { get; set; }
    }
}
