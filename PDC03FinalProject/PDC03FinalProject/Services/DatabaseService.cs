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

                string lastCode = lastItem.ActionCode.Substring(prefix.Length);
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

        // Global Methods: Methods For All Tables
        public async Task InitializeDatabaseAsync()
        {
            // Predefined items for SustainabilityHandbook
            var predefinedHandbooks = new List<SustainabilityHandbook>
            {
                new SustainabilityHandbook { ActionCode = "WTR001", Title = "Water Conservation", Description = "Save water by using efficient appliances.", Category = "Water", ImpactLevel = "High", Frequency = "Daily" },
                new SustainabilityHandbook { ActionCode = "E001", Title = "Energy Saving", Description = "Use energy-efficient lighting.", Category = "Energy", ImpactLevel = "Medium", Frequency = "Weekly" }
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
                new Activity { ActivityID = 1, ActivityName = "Baths is to Waters", ActivityDescription = "Each bath you consume water", ActivitySavedPerMinute = 9, ActivityMeasurement = "Liters", CategoryID = 1, ImageUrl = "water_bath.png" }
            };

            foreach (var activity in predefinedActivities)
            {
                var existingActivity = await _database.Table<Activity>().Where(a => a.ActivityID == activity.ActivityID).FirstOrDefaultAsync();
                if (existingActivity == null)
                {
                    await _database.InsertAsync(activity);
                }
            }
        }
    }
}