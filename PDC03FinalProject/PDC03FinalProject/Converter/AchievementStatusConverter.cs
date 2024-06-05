using System;
using System.Globalization;
using Xamarin.Forms;
using PDC03FinalProject.Models;

namespace PDC03FinalProject.Converters
{
    public class AchievementStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Achievement achievement)
            {
                return achievement.AchievementStatus ? achievement.AchievementImage : "lock.png"; // Replace with actual locked image path
            }
            return "lock.png"; // Default locked image
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}