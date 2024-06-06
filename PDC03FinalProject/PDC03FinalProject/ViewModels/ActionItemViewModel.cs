using PDC03FinalProject.Models;
using PDC03FinalProject.Services;
using PDC03FinalProject.Views;
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
    public class ActionItemViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;
        private ObservableCollection<SustainabilityHandbook> _actionItems;
        private string _selectedCategory;
        private ObservableCollection<string> _categories;
        private bool _isNoResultsVisible;

        public bool IsNoResultsVisible
        {
            get => _isNoResultsVisible;
            set
            {
                _isNoResultsVisible = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SustainabilityHandbook> ActionItems
        {
            get => _actionItems;
            set
            {
                _actionItems = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                FilterItems();
            }
        }

        public ObservableCollection<string> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddNewItemCommand { get; }
        public ICommand ItemSelectedCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ActionItemViewModel()
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            LoadItems();
            LoadCategories();
            AddNewItemCommand = new Command(async () => await AddNewItem());
            ItemSelectedCommand = new Command<SustainabilityHandbook>(OnItemSelected);
        }

        private async void LoadItems()
        {
            var items = await _databaseService.GetItemsAsync();
            ActionItems = new ObservableCollection<SustainabilityHandbook>(items);
            IsNoResultsVisible = ActionItems.Count == 0;
        }

        private void LoadCategories()
        {
            Categories = new ObservableCollection<string> { "None", "Water", "Energy", "Gas", "Waste" };
        }

        private async void FilterItems()
        {
            if (SelectedCategory == "None")
            {
                LoadItems();
            }
            else
            {
                var items = await _databaseService.GetItemsByCategoryAsync(SelectedCategory);
                ActionItems = new ObservableCollection<SustainabilityHandbook>(items);
                IsNoResultsVisible = ActionItems.Count == 0;
            }
        }

        private async Task AddNewItem()
        {
            string category = await Application.Current.MainPage.DisplayActionSheet("Select Category", "Cancel", null, "Water", "Energy", "Gas", "Waste");
            if (category == "Cancel" || string.IsNullOrEmpty(category))
                return;

            string nextActionCode = await _databaseService.GetNextActionCodeAsync(category);

            string title = await Application.Current.MainPage.DisplayPromptAsync("Title", "Enter title for the new item:");
            if (title == null) // User clicked Cancel
                return;

            while (string.IsNullOrEmpty(title))
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "Title cannot be empty.", "OK");
                title = await Application.Current.MainPage.DisplayPromptAsync("Title", "Enter title for the new item:");
                if (title == null) // User clicked Cancel
                    return;
            }

            string description = await Application.Current.MainPage.DisplayPromptAsync("Description", "Enter description for the new item:");
            if (description == null) // User clicked Cancel
                return;

            while (string.IsNullOrEmpty(description))
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "Description cannot be empty.", "OK");
                description = await Application.Current.MainPage.DisplayPromptAsync("Description", "Enter description for the new item:");
                if (description == null) // User clicked Cancel
                    return;
            }

            string impactLevel = await Application.Current.MainPage.DisplayActionSheet("Select Impact Level", "Cancel", null, "Very Low", "Low", "Medium", "High", "Very High");
            if (impactLevel == "Cancel" || string.IsNullOrEmpty(impactLevel))
                return;

            string frequency = await Application.Current.MainPage.DisplayPromptAsync("Frequency", "Enter frequency for the new item:");
            if (frequency == null) // User clicked Cancel
                return;

            while (string.IsNullOrEmpty(frequency))
            {
                await Application.Current.MainPage.DisplayAlert("Validation Error", "Frequency cannot be empty.", "OK");
                frequency = await Application.Current.MainPage.DisplayPromptAsync("Frequency", "Enter frequency for the new item:");
                if (frequency == null) // User clicked Cancel
                    return;
            }

            var newItem = new SustainabilityHandbook
            {
                ActionCode = nextActionCode,
                Title = title,
                Description = description,
                Category = category,
                ImpactLevel = impactLevel,
                Frequency = frequency,
                IsUserCreated = true
            };

            await _databaseService.SaveItemAsync(newItem);
            LoadItems();

            // Reset the Picker value to "None"
            SelectedCategory = "None";
        }


        private void OnItemSelected(SustainabilityHandbook item)
        {
            if (item != null)
            {
                var detailPage = new DetailPage(item);
                Application.Current.MainPage.Navigation.PushAsync(detailPage);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}