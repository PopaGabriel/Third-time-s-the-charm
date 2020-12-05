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
            c.username = "Andrei3";
            Users.Add(c);

            Utilizator d = new Utilizator();
            d.username = "Andrei";
            
            Users.Add(d);
            Utilizator e = new Utilizator(); 
            e.username = "Andrei2";

            Users.Add(e);
            Utilizator f = new Utilizator();
            f.username = "Andrei3";
            Users.Add(f);

            Utilizator g = new Utilizator();
            g.username = "Andrei";
            Users.Add(g);

            Utilizator h = new Utilizator();
            h.username = "Andrei2";
            Users.Add(h);

            Utilizator i = new Utilizator();
            i.username = "Andrei3";
            Users.Add(i);

            Utilizator j = new Utilizator();
            j.username = "Andrei";
            Users.Add(j);

            Utilizator k = new Utilizator();
            k.username = "Andrei2";
            Users.Add(k);

            Utilizator l = new Utilizator();
            l.username = "Andrei3";
            Users.Add(l);

            BindingContext = this;
        }
        public void Init()
        {
            ListView_Prieteni.BackgroundColor = Constants.BackgroundColor;
        }
    }
}