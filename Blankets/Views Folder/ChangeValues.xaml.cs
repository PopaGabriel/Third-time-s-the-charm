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
        User user;
        public ChangeValues(User Useras)
        {
            user = Useras;
            InitializeComponent();
        }
        private async void Aa(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}