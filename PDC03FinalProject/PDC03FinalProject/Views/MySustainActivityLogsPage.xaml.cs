using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PDC03FinalProject.ViewModels;
using PDC03FinalProject.Models;

namespace PDC03FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MySustainActivityLogsPage : ContentPage
    {
        public MySustainActivityLogsPage()
        {
            InitializeComponent();
            BindingContext = new MySustainActivityLogsViewModel();
        }

        private async void OnUserActivityLogTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is UserActivityLog log)
            {
                await Navigation.PushAsync(new UserActivityDetailPage(log));
            }
            ((ListView)sender).SelectedItem = null;
        }
    }
}