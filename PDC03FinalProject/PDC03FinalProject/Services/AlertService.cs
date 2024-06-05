using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDC03FinalProject.Services
{
    public class AlertService : IAlertService
    {
        public Task ShowAlertAsync(string title, string message, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}