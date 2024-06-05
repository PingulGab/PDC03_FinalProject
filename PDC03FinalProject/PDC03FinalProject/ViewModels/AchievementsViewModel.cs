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

        public ObservableCollection<Achievement> Achievements { get; }
        public string AchievementCounter => $"{Achievements.Count(a => a.AchievementStatus)} Unlocked / {Achievements.Count(a => !a.AchievementStatus)} Locked";
        public Command<Achievement> ShowAchievementDetailsCommand { get; }

        public AchievementsViewModel()
        {
            _databaseService = DependencyService.Get<DatabaseService>();
            _alertService = DependencyService.Get<IAlertService>();
            _imageService = DependencyService.Get<IImageService>();
            Achievements = new ObservableCollection<Achievement>();
            ShowAchievementDetailsCommand = new Command<Achievement>(ShowAchievementDetails);
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
            OnPropertyChanged(nameof(AchievementCounter));
        }

        private async void ShowAchievementDetails(Achievement achievement)
        {
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
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
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
