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
    public partial class BigChat : ContentPage
    {
        Utilizator user;
        public BigChat(Utilizator user)
        {
            this.user = user;
            InitializeComponent();

        }
        public BigChat()
        {
            InitializeComponent();
        }
        public void Send_messageBigPage(object sender, EventArgs e)
        {

        }
        public void Send_games_BigPage(object sender, EventArgs e)
        {
            //A nu se implementa!!!!
        }
    }
}