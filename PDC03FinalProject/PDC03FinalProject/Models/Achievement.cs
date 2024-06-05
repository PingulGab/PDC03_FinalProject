using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDC03FinalProject.Models
{
    public class Achievement
    {
        [PrimaryKey, AutoIncrement]
        public int AchievementID { get; set; }
        public string AchievementTitle { get; set; }
        public string AchievementDescription { get; set; }
        public string AchievementImage { get; set; }
        public bool AchievementStatus { get; set; }
    }
}