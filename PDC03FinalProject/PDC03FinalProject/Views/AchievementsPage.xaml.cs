using PDC03FinalProject.Helpers;
using PDC03FinalProject.Models;
using PDC03FinalProject.ViewModels;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC03FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AchievementsPage : ContentPage
    {
        public AchievementsPage()
        {
            InitializeComponent();
        }

        public void ReloadData()
        {
            if (BindingContext is AchievementsViewModel viewModel)
            {
                viewModel.LoadAchievements().SafeFireAndForget(false);
            }
        }
    }
}