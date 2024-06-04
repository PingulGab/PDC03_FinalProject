using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PDC03FinalProject.Models
{
    public class SustainabilityHandbook
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string ActionCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImpactLevel { get; set; }
        public string Frequency { get; set; }
        public bool IsUserCreated { get; set; }
        [Ignore]
        public string ImageSource => Category switch
        {
            "Water" => "Water_Icon.png",
            "Energy" => "Energy_Icon.png",
            "Gas" => "Gas_Icon.png",
            "Waste" => "Waste_Icon.png",
            _ => "Default_Icon.png"
        };
    }
}