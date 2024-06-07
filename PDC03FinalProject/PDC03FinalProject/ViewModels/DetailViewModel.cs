using PDC03FinalProject.Models;
using PDC03FinalProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private SustainabilityHandbook _actionItem;
        public ObservableCollection<string> ImpactLevels { get; set; }
        public ObservableCollection<string> Categories { get; set; }

        public SustainabilityHandbook ActionItem
        {
            get => _actionItem;
            set
            {
                _actionItem = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Title)); // Notify that Title has changed
            }
        }

        public string Title => ActionItem?.Title;

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public DetailViewModel(SustainabilityHandbook actionItem)
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            ActionItem = actionItem;

            ImpactLevels = new ObservableCollection<string>
            {
                "Very Low", "Low", "Medium", "High", "Very High"
            };

            Categories = new ObservableCollection<string>
            {
                "Water", "Energy", "Gas", "Waste"
            };

            SaveCommand = new Command(async () => await SaveItem());
            DeleteCommand = new Command(async () => await DeleteItem());
        }

        private async Task SaveItem()
        {
            await _databaseService.SaveItemAsync(ActionItem);
            await Application.Current.MainPage.Navigation.PopAsync();

            MessagingCenter.Send(this, "HandbookEntrySaved");
        }

        private async Task DeleteItem()
        {
            await _databaseService.DeleteItemAsync(ActionItem);
            await Application.Current.MainPage.Navigation.PopAsync();

            MessagingCenter.Send(this, "HandbookEntryDeleted");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
