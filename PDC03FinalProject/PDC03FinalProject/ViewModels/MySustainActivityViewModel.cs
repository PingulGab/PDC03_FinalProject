using MvvmHelpers;
using PDC03FinalProject.Models;
using PDC03FinalProject.Services;
using PDC03FinalProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PDC03FinalProject.Helpers;

namespace PDC03FinalProject.ViewModels
{
    public class MySustainActivityViewModel : BindableObject
    {
        private readonly DatabaseService _databaseService;
        private readonly AchievementService _achievementService;
        private string _selectedCategory;

        public ObservableCollection<Activity> Activities { get; set; }
        public ObservableCollection<string> Categories { get; set; }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                LoadActivitiesByCategoryAsync().SafeFireAndForget(false);
            }
        }

        public Command<Activity> ActivitySelectedCommand { get; }
        public Command NavigateToLogsCommand { get; }

        public MySustainActivityViewModel()
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            _achievementService = DependencyService.Get<AchievementService>();
            Activities = new ObservableCollection<Activity>();
            Categories = new ObservableCollection<string> { "None", "Water", "Energy", "Gas", "Waste" };
            ActivitySelectedCommand = new Command<Activity>(async (activity) => await OnActivitySelected(activity));
            NavigateToLogsCommand = new Command(async () => await OnNavigateToLogs());
            LoadActivitiesAsync().SafeFireAndForget(false);
        }

        private async Task LoadActivitiesAsync()
        {
            var activities = await _databaseService.GetActivitiesAsync();
            Activities.Clear();
            foreach (var activity in activities)
            {
                Activities.Add(activity);
            }
        }

        private async Task LoadActivitiesByCategoryAsync()
        {
            if (SelectedCategory == "None")
            {
                await LoadActivitiesAsync();
            }
            else
            {
                var categories = await _databaseService.GetActivityCategoriesAsync();
                var category = categories.FirstOrDefault(c => c.CategoryName == SelectedCategory);
                if (category != null)
                {
                    var activities = await _databaseService.GetActivitiesByCategoryAsync(category.Id);
                    Activities.Clear();
                    foreach (var activity in activities)
                    {
                        Activities.Add(activity);
                    }
                }
            }
        }

        private async Task OnActivitySelected(Activity activity)
        {
            var result = await App.Current.MainPage.DisplayPromptAsync("Enter Time", "Enter the time in minutes:", keyboard: Keyboard.Numeric);

            // Validate the entered time
            if (!double.TryParse(result, out double minutes))
            {
                await App.Current.MainPage.DisplayAlert("Invalid Input", "Please enter a valid number.", "OK");
                return;
            }

            var userActivity = new UserActivity
            {
                UserActivityExecutedID = activity.ActivityID,
                UserActivityLength = minutes,
                UserActivitySaved = minutes * activity.ActivitySavedPerMinute,
                UserActivityDate = DateTime.Now
            };

            await _databaseService.SaveUserActivityAsync(userActivity);

            // Check for achievements after saving the user activity
            await _achievementService.CheckForAchievements(userActivity);

            await App.Current.MainPage.DisplayAlert("Wonderful!", $"You have saved {userActivity.UserActivitySaved} {activity.ActivityMeasurement}", "OK");
        }
        private async Task OnNavigateToLogs()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MySustainActivityLogsPage());
        }
    }
}