using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDC03FinalProject.Models
{
    public class UserActivity
    {
        [PrimaryKey, AutoIncrement]
        public int UserActivityID { get; set; }
        public int UserActivityExecutedID { get; set; }
        public double UserActivityLength { get; set; }
        public double UserActivitySaved { get; set; }
        public string UserActivityImage { get; set; }
        public DateTime UserActivityDate { get; set; }
    }
}