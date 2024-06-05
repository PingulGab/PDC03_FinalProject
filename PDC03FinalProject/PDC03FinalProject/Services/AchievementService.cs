// Services->AchievementService.cs
using PDC03FinalProject.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDC03FinalProject.Services
{
    public class AchievementService
    {
        private readonly DatabaseService _databaseService;

        public AchievementService()
        {
            _databaseService = DependencyService.Get<DatabaseService>();
        }

        public async Task CheckForAchievements(UserActivity userActivity)
        {
            var achievements = await _databaseService.GetAchievementsAsync();

            // Check for 1 week straight activity
            if (userActivity.UserActivityExecutedID == 1) // Assuming 1 is the ID for "Baths is to Water"
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var lastWeekActivities = userActivities.Where(ua => ua.UserActivityDate >= DateTime.Now.AddDays(-7) && ua.UserActivityExecutedID == 1);
                if (lastWeekActivities.Count() >= 7)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "1 Week Straight Bath");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: 1 Week Straight Bath", "OK");
                    }
                }
            }

            // Check for saving 10,000 liters of water
            if (userActivity.UserActivityExecutedID == 1)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalWaterSaved = userActivities.Where(ua => ua.UserActivityExecutedID == 1).Sum(ua => ua.UserActivitySaved);
                if (totalWaterSaved >= 10000)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Save 10,000 Liters of Water");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Save 10,000 Liters of Water", "OK");
                    }
                }
            }
        }
    }
}
