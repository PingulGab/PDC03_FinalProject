using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDC03FinalProject.Models
{
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public int ActivitySavedPerMinute { get; set; }
        public string ActivityMeasurement { get; set; }
        public int CategoryID { get; set; }
        public string ImageUrl { get; set; }
        public string ActivityPromptQuestion { get; set; }
    }
}