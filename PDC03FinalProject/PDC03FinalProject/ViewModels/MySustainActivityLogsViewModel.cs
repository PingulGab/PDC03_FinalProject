using MvvmHelpers;
using PDC03FinalProject.Services;
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
    public class MySustainActivityLogsViewModel : BindableObject
    {
        private readonly DatabaseService _databaseService;
        public ObservableCollection<UserActivityLog> UserActivityLogs { get; set; }

        public MySustainActivityLogsViewModel()
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            UserActivityLogs = new ObservableCollection<UserActivityLog>();
            LoadUserActivitiesAsync().SafeFireAndForget(false);

            MessagingCenter.Subscribe<UserActivityDetailViewModel>(this, "UserActivityDeleted", async (sender) =>
            {
                await LoadUserActivitiesAsync();
            });

            MessagingCenter.Subscribe<UserActivityDetailViewModel>(this, "UserActivitySaved", async (sender) =>
            {
                await LoadUserActivitiesAsync();
            });
        }

        private async Task LoadUserActivitiesAsync()
        {
            var userActivities = await _databaseService.GetUserActivitiesAsync();
            var activities = await _databaseService.GetActivitiesAsync();

            var logs = from ua in userActivities
                       join a in activities on ua.UserActivityExecutedID equals a.ActivityID
                       select new UserActivityLog
                       {
                           UserActivityID = ua.UserActivityID,
                           ActivityName = a.ActivityName,
                           ActivityDescription = a.ActivityDescription,
                           UserActivityDate = ua.UserActivityDate,
                           UserActivityLength = ua.UserActivityLength,
                           UserActivitySaved = ua.UserActivitySaved,
                           ActivitySavedPerMinute = a.ActivitySavedPerMinute,
                           ActivityMeasurement = a.ActivityMeasurement,
                           ImageUrl = a.ImageUrl,
                           UserActivityImage = ua.UserActivityImage
                       };

            UserActivityLogs.Clear();
            foreach (var log in logs)
            {
                UserActivityLogs.Add(log);
            }
        }

        public async void EditUserActivity(UserActivityLog log, double newLength)
        {
            var userActivity = await _databaseService.GetUserActivityByIdAsync(log.UserActivityID);
            userActivity.UserActivityLength = newLength;
            userActivity.UserActivitySaved = newLength * log.ActivitySavedPerMinute;

            await _databaseService.SaveUserActivityAsync(userActivity);

            log.UserActivityLength = newLength;
            log.UserActivitySaved = userActivity.UserActivitySaved;

            OnPropertyChanged(nameof(UserActivityLogs));

        }

        public async void DeleteUserActivity(UserActivityLog log)
        {
            var userActivity = await _databaseService.GetUserActivityByIdAsync(log.UserActivityID);
            await _databaseService.DeleteUserActivityAsync(userActivity);

            UserActivityLogs.Remove(log);

            // Trigger refresh
            await LoadUserActivitiesAsync();
        }
    }

    public class UserActivityLog : BindableObject
    {
        public int UserActivityID { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public DateTime UserActivityDate { get; set; }
        public double UserActivityLength { get; set; }
        public double UserActivitySaved { get; set; }
        public double ActivitySavedPerMinute { get; set; }
        public string ActivityMeasurement { get; set; }
        public string ImageUrl { get; set; }
        public string UserActivityImage { get; set; }
        public string UserActivitySavedText => $"{UserActivitySaved} {ActivityMeasurement}";
    }
}
