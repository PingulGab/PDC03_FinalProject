using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDC03FinalProject.Models
{
    public class ActivityCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}