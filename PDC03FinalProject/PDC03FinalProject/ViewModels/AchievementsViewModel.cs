using MvvmHelpers;
using PDC03FinalProject.Helpers;
using PDC03FinalProject.Models;
using PDC03FinalProject.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PDC03FinalProject.ViewModels
{
    public class AchievementsViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;

        public ObservableCollection<Achievement> Achievements { get; }

        public AchievementsViewModel()
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            Achievements = new ObservableCollection<Achievement>();
            LoadAchievements().SafeFireAndForget(false);
        }

        private async Task LoadAchievements()
        {
            var achievements = await _databaseService.GetAchievementsAsync();
            Achievements.Clear();
            foreach (var achievement in achievements)
            {
                Achievements.Add(achievement);
            }
        }
    }
}
