using MvvmHelpers;
using PDC03FinalProject.Models;
using PDC03FinalProject.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDC03FinalProject.ViewModels
{
    public class UserActivityDetailViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        private readonly AchievementService _achievementService;
        private double _userActivityLength;

        public UserActivityLog UserActivity { get; set; }

        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }

        public double UserActivityLength
        {
            get => _userActivityLength;
            set
            {
                if (_userActivityLength != value)
                {
                    _userActivityLength = value;
                    UserActivity.UserActivityLength = value;
                    UserActivity.UserActivitySaved = value * UserActivity.ActivitySavedPerMinute;
                    OnPropertyChanged(nameof(UserActivityLength));
                    OnPropertyChanged(nameof(UserActivitySaved));
                    OnPropertyChanged(nameof(UserActivity.UserActivitySavedText));
                }
            }
        }

        public double UserActivitySaved => UserActivity.UserActivitySaved;

        public UserActivityDetailViewModel(UserActivityLog userActivity)
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            _achievementService = DependencyService.Get<AchievementService>();
            UserActivity = userActivity;
            _userActivityLength = userActivity.UserActivityLength;

            SaveCommand = new Command(async () => await OnSave());
            DeleteCommand = new Command(OnDelete);
        }

        private async Task OnSave()
        {
            var userActivity = await _databaseService.GetUserActivityByIdAsync(UserActivity.UserActivityID);
            userActivity.UserActivityLength = UserActivity.UserActivityLength;
            userActivity.UserActivitySaved = UserActivity.UserActivityLength * UserActivity.ActivitySavedPerMinute;

            await _databaseService.SaveUserActivityAsync(userActivity);

            UserActivity.UserActivitySaved = userActivity.UserActivitySaved;

            OnPropertyChanged(nameof(UserActivity));
            OnPropertyChanged(nameof(UserActivity.UserActivitySavedText));

            // Check for achievements after saving the user activity
            await _achievementService.CheckForAchievements(userActivity);

            MessagingCenter.Send(this, "UserActivitySaved");

            await Application.Current.MainPage.DisplayAlert("Saved", "The activity has been updated.", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnDelete()
        {
            var userActivity = await _databaseService.GetUserActivityByIdAsync(UserActivity.UserActivityID);
            await _databaseService.DeleteUserActivityAsync(userActivity);

            await Application.Current.MainPage.DisplayAlert("Deleted", "The activity has been deleted.", "OK");

            // Trigger the refresh of the MySustainActivityLogsPage
            MessagingCenter.Send(this, "UserActivityDeleted");

            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
