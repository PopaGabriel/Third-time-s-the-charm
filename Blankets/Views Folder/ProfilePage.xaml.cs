using Blankets.Models;
using Blankets.Views_Folder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blankets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test : ContentPage
    {
        User user_current;
        public Test(User user)
        {
            user_current = user;
            InitializeComponent();
            if(user_current.UserName1 != null)
                ProfileName.SetBinding(Label.TextProperty, user_current.UserName1);
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
            await Navigation.PushAsync(new Meniu());
        }
        private void ProcedureChangePhoto(object sender, EventArgs e)
        {
            //Aici teoretic schimbam poza
        }
    }
}