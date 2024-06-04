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
        }

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

        public async Task InitializeDatabaseAsync()
        {
            var predefinedItems = new List<SustainabilityHandbook>
        {
            new SustainabilityHandbook { ActionCode = "WTR001", Title = "Water Conservation", Description = "Save water by using efficient appliances.", Category = "Water", ImpactLevel = "High", Frequency = "Daily" },
            new SustainabilityHandbook { ActionCode = "E001", Title = "Energy Saving", Description = "Use energy-efficient lighting.", Category = "Energy", ImpactLevel = "Medium", Frequency = "Weekly" }
        };

            foreach (var item in predefinedItems)
            {
                var existingItem = await _database.Table<SustainabilityHandbook>().Where(i => i.ActionCode == item.ActionCode).FirstOrDefaultAsync();
                if (existingItem == null)
                {
                    await _database.InsertAsync(item);
                }
            }
        }
    }
}