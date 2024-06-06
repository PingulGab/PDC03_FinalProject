using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC03FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Btn_Nav_ActionListPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionListPage());
        }

        private async void Btn_Nav_SustainActivityPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MySustainActivityPage());
        }

        private async void Btn_Nav_AchievementsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AchievementsPage());
        }
    }
}
