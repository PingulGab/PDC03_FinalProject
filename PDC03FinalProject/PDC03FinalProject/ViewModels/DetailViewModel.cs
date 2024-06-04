using PDC03FinalProject.Models;
using PDC03FinalProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PDC03FinalProject.ViewModels
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        public SustainabilityHandbook ActionItem { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public DetailViewModel(SustainabilityHandbook actionItem)
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            ActionItem = actionItem;

            SaveCommand = new Command(async () => await SaveItem());
            DeleteCommand = new Command(async () => await DeleteItem());
        }

        private async Task SaveItem()
        {
            await _databaseService.SaveItemAsync(ActionItem);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async Task DeleteItem()
        {
            await _databaseService.DeleteItemAsync(ActionItem);
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}