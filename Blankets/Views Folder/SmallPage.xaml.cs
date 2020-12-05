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
    public partial class SmallPage : ContentPage
    {
        public string de_folosit_ca_titlu { get; set; }
        public SmallPage(Utilizator utilizaoreanu)
        {
            InitializeComponent();
            de_folosit_ca_titlu = utilizaoreanu.username;
            this.BindingContext = this;
        }
        public SmallPage()
        {
            InitializeComponent();
        }
        public void Send_message_SmallPage(object sender, EventArgs e)
        {
            
        }
        public void Send_games_SmallPage(object sender, EventArgs e)
        {

        }
    }
}