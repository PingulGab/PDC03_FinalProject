using MvvmHelpers;
using PDC03FinalProject.Helpers;
using PDC03FinalProject.Models;
using PDC03FinalProject.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;
using System;

namespace PDC03FinalProject.ViewModels
{
    public class AchievementsViewModel : BaseViewModel
    {
        private readonly DatabaseService _databaseService;
        private readonly IAlertService _alertService;
        private readonly IImageService _imageService;
        private string _selectedCategory;

        public ObservableCollection<Achievement> Achievements { get; }
        public ObservableCollection<string> Categories { get; set; }
        public string AchievementCounter => $"{Achievements.Count(a => a.AchievementStatus)} Unlocked / {Achievements.Count(a => !a.AchievementStatus)} Locked";

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                LoadAchievements().SafeFireAndForget(false);
            }
        }

        public Command<Achievement> ShowAchievementDetailsCommand { get; }

        public AchievementsViewModel()
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            _alertService = DependencyService.Get<IAlertService>();
            _imageService = DependencyService.Get<IImageService>();

            Achievements = new ObservableCollection<Achievement>();
            Categories = new ObservableCollection<string> { "None", "Water", "Energy", "Gas", "Waste" };
            SelectedCategory = "None";

            ShowAchievementDetailsCommand = new Command<Achievement>(ShowAchievementDetails);
            LoadAchievements().SafeFireAndForget(false);
        }

        public async Task LoadAchievements()
        {
            var achievements = await _databaseService.GetAchievementsAsync();
            Achievements.Clear();

            if (SelectedCategory == "None")
            {
                foreach (var achievement in achievements)
                {
                    Achievements.Add(achievement);
                }
            }
            else
            {
                var categories = await _databaseService.GetActivityCategoriesAsync();
                var category = categories.FirstOrDefault(c => c.CategoryName == SelectedCategory);
                if (category != null)
                {
                    var filteredAchievements = achievements.Where(a => a.CategoryID == category.Id);
                    foreach (var achievement in filteredAchievements)
                    {
                        Achievements.Add(achievement);
                    }
                }
            }

            OnPropertyChanged(nameof(AchievementCounter));
        }

        private async void ShowAchievementDetails(Achievement achievement)
        {
            if (!achievement.AchievementStatus)
            {
                await Application.Current.MainPage.DisplayAlert(achievement.AchievementTitle, achievement.AchievementDescription, "OK");
                return;
            }

            bool download = await Application.Current.MainPage.DisplayAlert(achievement.AchievementTitle, achievement.AchievementDescription, "Download Image", "Cancel");
            if (download)
            {
                // Remove the file extension when passing to the image service
                var imageNameWithoutExtension = Path.GetFileNameWithoutExtension(achievement.AchievementImage);
                await DownloadImageAsync(imageNameWithoutExtension);
            }
        }

        private async Task DownloadImageAsync(string imageName)
        {
            try
            {
                var stream = await _imageService.GetImageStreamAsync(imageName);
                if (stream != null)
                {
                    using MemoryStream memoryStream = new MemoryStream();
                    await stream.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    var filePath = Path.Combine(FileSystem.AppDataDirectory, imageName);
                    File.WriteAllBytes(filePath, imageBytes);

                    await Share.RequestAsync(new ShareFileRequest
                    {
                        Title = "Download Achievement Image",
                        File = new ShareFile(filePath)
                    });
                }
                else
                {
                    await _alertService.ShowAlertAsync("Error", "Image not found", "OK");
                }
            }
            catch (Exception ex)
            {
                await _alertService.ShowAlertAsync("Error", ex.Message, "OK");
            }
        }
    }
}
