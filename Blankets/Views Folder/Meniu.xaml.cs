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
            await Navigation.PushAsync(new BigChat());
        }
        public async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            Utilizator mydetail = e.Item as Utilizator;
            //await DisplayAlert("Alert", mydetail.username, "OK");
            await Navigation.PushAsync(new SmallPage(mydetail, utilizator, token));
        }
    }
}