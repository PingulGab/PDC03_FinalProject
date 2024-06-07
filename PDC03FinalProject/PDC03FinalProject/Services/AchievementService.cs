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

            // Shorter Shower Hero Achievement
            if (userActivity.UserActivityExecutedID == 1)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalMinutesSaved = userActivities.Where(ua => ua.UserActivityExecutedID == 1).Sum(ua => ua.UserActivitySaved);
                if (totalMinutesSaved >= 100)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Shorter Shower Hero I");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Shorter Shower Hero I", "OK");
                    }
                }
            }

            // Save 5,000 Liters of water by taking shorter showers
            if (userActivity.UserActivityExecutedID == 1)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalWaterSaved = userActivities.Where(ua => ua.UserActivityExecutedID == 1).Sum(ua => ua.UserActivitySaved);
                if (totalWaterSaved >= 5000)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Shorter Shower Hero II");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Shorter Shower Hero II", "OK");
                    }
                }
            }

            // Save 10,000 Liters of water by taking shorter showers
            if (userActivity.UserActivityExecutedID == 1)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalWaterSaved = userActivities.Where(ua => ua.UserActivityExecutedID == 1).Sum(ua => ua.UserActivitySaved);
                if (totalWaterSaved >= 10000)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Shorter Shower Hero III");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Shorter Shower Hero III", "OK");
                    }
                }
            }

            // Toothbrush Saver Achievement
            if (userActivity.UserActivityExecutedID == 2)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalWaterSaved = userActivities.Where(ua => ua.UserActivityExecutedID == 2).Sum(ua => ua.UserActivitySaved);
                if (totalWaterSaved >= 300)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Toothbrush Saver");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Toothbrush Saver I", "OK");
                    }
                }
            }

            // Food Waste Fighter Achievement
            if (userActivity.UserActivityExecutedID == 3)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalFoodWasteReduced = userActivities.Where(ua => ua.UserActivityExecutedID == 3).Sum(ua => ua.UserActivitySaved);
                if (totalFoodWasteReduced >= 100)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Food Waste Fighter");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Food Waste Fighter", "OK");
                    }
                }
            }

            // Public Transport Pro Achievement
            if (userActivity.UserActivityExecutedID == 4)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalGasSaved = userActivities.Where(ua => ua.UserActivityExecutedID == 4).Sum(ua => ua.UserActivitySaved);
                if (totalGasSaved >= 200)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Public Transport Pro");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Public Transport Pro I", "OK");
                    }
                }
            }

            // Unplugging Expert Achievement
            if (userActivity.UserActivityExecutedID == 5)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalWattsSaved = userActivities.Where(ua => ua.UserActivityExecutedID == 5).Sum(ua => ua.UserActivitySaved);
                if (totalWattsSaved >= 500)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Unplugging Expert I");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Unplugging Expert I", "OK");
                    }
                }
            }

            // Unplugging Expert II Achievement
            if (userActivity.UserActivityExecutedID == 5)
            {
                var userActivities = await _databaseService.GetUserActivitiesAsync();
                var totalWattsSaved = userActivities.Where(ua => ua.UserActivityExecutedID == 5).Sum(ua => ua.UserActivitySaved);
                if (totalWattsSaved >= 1000)
                {
                    var achievement = achievements.FirstOrDefault(a => a.AchievementTitle == "Unplugging Expert II");
                    if (achievement != null && !achievement.AchievementStatus) // Check if Locked (False)
                    {
                        achievement.AchievementStatus = true; // Unlock (True)
                        await _databaseService.SaveAchievementAsync(achievement);
                        await Application.Current.MainPage.DisplayAlert("Achievement Unlocked", "You have unlocked: Unplugging Expert II", "OK");
                    }
                }
            }
        }
    }
}
