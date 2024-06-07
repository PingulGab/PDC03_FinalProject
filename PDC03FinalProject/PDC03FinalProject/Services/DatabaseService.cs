using PDC03FinalProject.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PDC03FinalProject.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<SustainabilityHandbook>().Wait();
            _database.CreateTableAsync<ActivityCategory>().Wait();
            _database.CreateTableAsync<Activity>().Wait();
            _database.CreateTableAsync<UserActivity>().Wait();
            _database.CreateTableAsync<Achievement>().Wait();
        }


        // Sustainability Handbook Methods
        public Task<List<SustainabilityHandbook>> GetItemsAsync()
        {
            return _database.Table<SustainabilityHandbook>().ToListAsync();
        }

        public Task<List<SustainabilityHandbook>> GetItemsByCategoryAsync(string category)
        {
            return _database.Table<SustainabilityHandbook>().Where(i => i.Category == category).ToListAsync();
        }

        public Task<SustainabilityHandbook> GetItemAsync(int id)
        {
            return _database.Table<SustainabilityHandbook>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(SustainabilityHandbook item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(SustainabilityHandbook item)
        {
            return _database.DeleteAsync(item);
        }

        public async Task<string> GetNextActionCodeAsync(string category)
        {
            var lastItem = await _database.Table<SustainabilityHandbook>()
                                           .Where(i => i.Category == category)
                                           .OrderByDescending(i => i.ID)
                                           .FirstOrDefaultAsync();

            if (lastItem == null)
            {
                switch (category)
                {
                    case "Water": return "WTR001";
                    case "Energy": return "E001";
                    case "Gas": return "G001";
                    case "Waste": return "WST001";
                }
            }
            else
            {
                string prefix = category switch
                {
                    "Water" => "WTR",
                    "Energy" => "E",
                    "Gas" => "G",
                    "Waste" => "WST",
                    _ => throw new InvalidOperationException()
                };

                string lastCode = lastItem.ActionCode[prefix.Length..];
                int nextCode = int.Parse(lastCode) + 1;
                return $"{prefix}{nextCode:D3}";
            }

            throw new InvalidOperationException("Invalid category");
        }

        // Activity Category Methods
        public Task<List<ActivityCategory>> GetActivityCategoriesAsync()
        {
            return _database.Table<ActivityCategory>().ToListAsync();
        }

        public Task<int> SaveActivityCategoryAsync(ActivityCategory category)
        {
            if (category.Id != 0)
            {
                return _database.UpdateAsync(category);
            }
            else
            {
                return _database.InsertAsync(category);
            }
        }

        // Activity Methods
        public Task<List<Activity>> GetActivitiesAsync()
        {
            return _database.Table<Activity>().ToListAsync();
        }

        public Task<List<Activity>> GetActivitiesByCategoryAsync(int categoryId)
        {
            return _database.Table<Activity>().Where(a => a.CategoryID == categoryId).ToListAsync();
        }

        public Task<int> SaveActivityAsync(Activity activity)
        {
            if (activity.ActivityID != 0)
            {
                return _database.UpdateAsync(activity);
            }
            else
            {
                return _database.InsertAsync(activity);
            }
        }

        // User Activity Methods
        public Task<List<UserActivity>> GetUserActivitiesAsync()
        {
            return _database.Table<UserActivity>().ToListAsync();
        }

        public Task<int> SaveUserActivityAsync(UserActivity userActivity)
        {
            if (userActivity.UserActivityID != 0)
            {
                return _database.UpdateAsync(userActivity);
            }
            else
            {
                return _database.InsertAsync(userActivity);
            }
        }

        public async Task<UserActivity> GetUserActivityByIdAsync(int id)
        {
            return await _database.Table<UserActivity>().FirstOrDefaultAsync(ua => ua.UserActivityID == id);
        }

        public async Task<int> DeleteUserActivityAsync(UserActivity userActivity)
        {
            return await _database.DeleteAsync(userActivity);
        }

        // Achievement Methods
        public Task<List<Achievement>> GetAchievementsAsync()
        {
            return _database.Table<Achievement>().ToListAsync();
        }

        public Task<int> SaveAchievementAsync(Achievement achievement)
        {
            if (achievement.AchievementID != 0)
            {
                return _database.UpdateAsync(achievement);
            }
            else
            {
                return _database.InsertAsync(achievement);
            }
        }

        public Task<int> DeleteAchievementAsync(Achievement achievement)
        {
            return _database.DeleteAsync(achievement);
        }

        // Global Methods: Methods For All Tables
        public async Task InitializeDatabaseAsync()
        {
            // Predefined items for SustainabilityHandbook
            var predefinedHandbooks = new List<SustainabilityHandbook>
            {
                new SustainabilityHandbook { ActionCode = "WTR001", Title = "Water Conservation", Description = "Save water by using efficient appliances.", Category = "Water", ImpactLevel = "High", Frequency = "Daily" },
                new SustainabilityHandbook { ActionCode = "WTR002", Title = "Fix Leaks", Description = "Repair leaks in faucets and pipes to prevent water waste.", Category = "Water", ImpactLevel = "High", Frequency = "Monthly" },
                new SustainabilityHandbook { ActionCode = "WTR003", Title = "Shorter Showers", Description = "Take shorter showers to reduce water usage.", Category = "Water", ImpactLevel = "Medium", Frequency = "Daily" },
                new SustainabilityHandbook { ActionCode = "WTR004", Title = "Rainwater Harvesting", Description = "Collect and use rainwater for gardening and other non-potable uses.", Category = "Water", ImpactLevel = "High", Frequency = "Seasonal" },

                new SustainabilityHandbook { ActionCode = "E001", Title = "Energy Saving", Description = "Use energy-efficient lighting.", Category = "Energy", ImpactLevel = "Medium", Frequency = "Weekly" },
                new SustainabilityHandbook { ActionCode = "E002", Title = "Unplug Devices", Description = "Unplug electronic devices when not in use to save energy.", Category = "Energy", ImpactLevel = "Medium", Frequency = "Daily" },
                new SustainabilityHandbook { ActionCode = "E003", Title = "Smart Thermostat", Description = "Install a smart thermostat to optimize heating and cooling.", Category = "Energy", ImpactLevel = "High", Frequency = "One-Time" },
                new SustainabilityHandbook { ActionCode = "E004", Title = "Solar Panels", Description = "Use solar panels to generate renewable energy.", Category = "Energy", ImpactLevel = "High", Frequency = "One-Time" },

                new SustainabilityHandbook { ActionCode = "GAS001", Title = "Efficient Cooking", Description = "Use energy-efficient cooking appliances.", Category = "Gas", ImpactLevel = "Medium", Frequency = "Daily" },
                new SustainabilityHandbook { ActionCode = "GAS002", Title = "Proper Insulation", Description = "Ensure proper insulation to reduce heating and cooling needs.", Category = "Gas", ImpactLevel = "High", Frequency = "One-Time" },
                new SustainabilityHandbook { ActionCode = "GAS003", Title = "Regular Maintenance", Description = "Perform regular maintenance on heating systems to ensure efficiency.", Category = "Gas", ImpactLevel = "High", Frequency = "Annually" },

                new SustainabilityHandbook { ActionCode = "WST001", Title = "Composting", Description = "Compost organic waste to reduce landfill usage.", Category = "Waste", ImpactLevel = "High", Frequency = "Daily" },
                new SustainabilityHandbook { ActionCode = "WST002", Title = "Recycling", Description = "Recycle paper, plastic, glass, and metals to reduce waste.", Category = "Waste", ImpactLevel = "High", Frequency = "Weekly" },
                new SustainabilityHandbook { ActionCode = "WST003", Title = "Reusable Bags", Description = "Use reusable bags instead of single-use plastic bags.", Category = "Waste", ImpactLevel = "Medium", Frequency = "Daily" },
                new SustainabilityHandbook { ActionCode = "WST004", Title = "Donate Items", Description = "Donate old clothes and items instead of throwing them away.", Category = "Waste", ImpactLevel = "Medium", Frequency = "Monthly" }
            };

            foreach (var item in predefinedHandbooks)
            {
                var existingItem = await _database.Table<SustainabilityHandbook>().Where(i => i.ActionCode == item.ActionCode).FirstOrDefaultAsync();
                if (existingItem == null)
                {
                    await _database.InsertAsync(item);
                }
            }

            // Predefined categories for ActivityCategory
            var predefinedCategories = new List<ActivityCategory>
            {
                new ActivityCategory { Id = 1, CategoryName = "Water" },
                new ActivityCategory { Id = 2, CategoryName = "Energy" },
                new ActivityCategory { Id = 3, CategoryName = "Gas" },
                new ActivityCategory { Id = 4, CategoryName = "Waste" }
            };

            foreach (var category in predefinedCategories)
            {
                var existingCategory = await _database.Table<ActivityCategory>().Where(c => c.Id == category.Id).FirstOrDefaultAsync();
                if (existingCategory == null)
                {
                    await _database.InsertAsync(category);
                }
            }

            // Predefined activities for Activity
            var predefinedActivities = new List<Activity>
            {

                //WATER
                new Activity {
                    ActivityID = 1,
                    ActivityName = "Shorter Shower",
                    ActivityDescription = "Reducing your shower time by 1 minute can save 9 liters of water.",
                    ActivitySavedPerMinute = 9,
                    ActivityMeasurement = "Liters of Water.",
                    CategoryID = 1,
                    ImageUrl = "activity_shower.png",
                    ActivityPromptQuestion = "Enter the minutes you reduced from your usual shower time:"
                },

                new Activity {
                    ActivityID = 2,
                    ActivityName = "Tap Off Toothbrushing",
                    ActivityDescription = "Turning off the tap while brushing can save up to 6 liters per minute.",
                    ActivitySavedPerMinute = 6,
                    ActivityMeasurement = "Liters of Water.",
                    CategoryID = 1,
                    ImageUrl = "activity_toothbrush.png",
                    ActivityPromptQuestion = "Enter the time you spent brushing your teeth with the tap off in minutes:"
                },

                //WASTE
                new Activity {
                    ActivityID = 3,
                    ActivityName = "Reducing Food Waste",
                    ActivityDescription = "Reducing food waste can save about 1 kg of CO2 emissions per kilogram of food.",
                    ActivitySavedPerMinute = 1,
                    ActivityMeasurement = "kg of CO2.",
                    CategoryID = 2,
                    ImageUrl = "activity_foodwaste.png",
                    ActivityPromptQuestion = "Enter the amount of food waste reduced in kilograms:"
                },

                //GAS
                new Activity {
                    ActivityID = 4,
                    ActivityName = "Using Public Transport",
                    ActivityDescription = "Using public transport can save about 0.2 liters of gas per kilometer compared to driving a car.",
                    ActivitySavedPerMinute = 1,
                    ActivityMeasurement = "Liters of Gasoline.",
                    CategoryID = 3,
                    ImageUrl = "activity_publictransport.png",
                    ActivityPromptQuestion = "Enter the distance you traveled using public transport in kilometers:"
                },

                //ENERGY
                new Activity {
                    ActivityID = 5,
                    ActivityName = "Unplugging Devices",
                    ActivityDescription = "Unplugging devices can save about 1 watt per hour per device.",
                    ActivitySavedPerMinute = 1,  // Saving 1 watt per hour, approximately 1 watt per minute
                    ActivityMeasurement = "Watts.",
                    CategoryID = 4,
                    ImageUrl = "activity_unplug.png",
                    ActivityPromptQuestion = "Enter the number of devices you unplugged and the minutes they were unplugged:"
                },
            };

            foreach (var activity in predefinedActivities)
            {
                var existingActivity = await _database.Table<Activity>().Where(a => a.ActivityID == activity.ActivityID).FirstOrDefaultAsync();
                if (existingActivity == null)
                {
                    await _database.InsertAsync(activity);
                }
            }

            // Predefined achievements
            var predefinedAchievements = new List<Achievement>
            {
                new Achievement { AchievementTitle = "Beta Tester", AchievementDescription = "You are a beta tester of ATLAS.", AchievementImage = "achievement_betatester.png", AchievementStatus = true, CategoryID = 2 },
                new Achievement { AchievementTitle = "Shorter Shower Hero I", AchievementDescription = "Save 100 liters of water by taking shorter showers.", AchievementImage = "achievement_showeri.png", AchievementStatus = false, CategoryID = 1 },
                new Achievement { AchievementTitle = "Shorter Shower Hero II", AchievementDescription = "Save 5,000 liters of water by taking shorter showers.", AchievementImage = "achievement_showerii.png", AchievementStatus = false, CategoryID = 1 },
                new Achievement { AchievementTitle = "Shorter Shower Hero III", AchievementDescription = "Save 10,000 liters of water by taking shorter showers.", AchievementImage = "achievement_showeriii.png", AchievementStatus = false, CategoryID = 1 },
                new Achievement { AchievementTitle = "Toothbrush Saver", AchievementDescription = "Save 300 Liters of water by turning off the tap.", AchievementImage = "achievement_toothbrush.png", AchievementStatus = false, CategoryID = 1 },
                new Achievement { AchievementTitle = "Food Waste Fighter", AchievementDescription = "Reduce a total of 100 kilogram food waste.", AchievementImage = "achievement_foodwaste.png", AchievementStatus = false, CategoryID = 2 },
                new Achievement { AchievementTitle = "Public Transport Pro", AchievementDescription = "Save 200 liters of gasoline by using public transport.", AchievementImage = "achievement_publictranspo.png", AchievementStatus = false, CategoryID = 3 },
                new Achievement { AchievementTitle = "Unplugging Expert I", AchievementDescription = "Save 500 Watts by unplugging devices.", AchievementImage = "achievement_unplugi.png", AchievementStatus = false, CategoryID = 4 },
                new Achievement { AchievementTitle = "Unplugging Expert II", AchievementDescription = "Save 1,000 Watts by unplugging devices.", AchievementImage = "achievement_unplugii.png", AchievementStatus = false, CategoryID = 4 },
            };

            foreach (var achievement in predefinedAchievements)
            {
                var existingAchievement = await _database.Table<Achievement>().Where(a => a.AchievementTitle == achievement.AchievementTitle).FirstOrDefaultAsync();
                if (existingAchievement == null)
                {
                    await _database.InsertAsync(achievement);
                }
            }
        }
    }
}