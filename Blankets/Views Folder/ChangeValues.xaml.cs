using Blankets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Blankets.Views_Folder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeValues : ContentPage
    {
        Utilizator user_curent;
        public ChangeValues(Utilizator utilizator)
        {
            user_curent = utilizator;
            InitializeComponent();
        }
        private async void Aa(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}