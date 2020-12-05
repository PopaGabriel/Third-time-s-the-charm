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
    public partial class Meniu : ContentPage
    {
        public IList<Utilizator> Users { get; private set; }
        public Meniu()
        {
            InitializeComponent();
            Init();
            Users = new List<Utilizator>();
            Utilizator a = new Utilizator();
            a.username = "Andrei";
            Users.Add(a);

            Utilizator b = new Utilizator();
            b.username = "Andrei2";
            Users.Add(b);

            Utilizator c = new Utilizator();
            c.username = "Andrei4";
            Users.Add(c);

            Utilizator d = new Utilizator();
            d.username = "Andrei5";
            
            Users.Add(d);
            Utilizator e = new Utilizator(); 
            e.username = "Andrei6";

            Users.Add(e);
            Utilizator f = new Utilizator();
            f.username = "Andrei7";
            Users.Add(f);

            Utilizator g = new Utilizator();
            g.username = "Andrei8";
            Users.Add(g);

            Utilizator h = new Utilizator();
            h.username = "Andrei9";
            Users.Add(h);

            Utilizator i = new Utilizator();
            i.username = "Andrei10";
            Users.Add(i);

            Utilizator j = new Utilizator();
            j.username = "Andrei11";
            Users.Add(j);

            Utilizator k = new Utilizator();
            k.username = "Andrei12";
            Users.Add(k);

            Utilizator l = new Utilizator();
            l.username = "Andrei Georgeta Mamu";
            Users.Add(l);

            Utilizator aa = new Utilizator();
            aa.username = "Andrei14";
            Users.Add(aa);

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
            await Navigation.PushAsync(new SmallPage(mydetail));
        }
    }
}