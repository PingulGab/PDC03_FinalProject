using PDC03FinalProject.Services;
using PDC03FinalProject.Views;
using System;
using System.IO;
using Xamarin.Forms;

namespace PDC03FinalProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Register the DatabaseService as a singleton
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AtlasDB.db3");
            DependencyService.RegisterSingleton(new DatabaseService(dbPath));
            DependencyService.Register<AchievementService>();
            DependencyService.Register<IAlertService, AlertService>();

            MainPage = new NavigationPage(new LandingPage())
            {
                BarBackgroundColor = Color.FromHex("#04724D"),
            };
        }

        protected override async void OnStart()
        {
            var dbService = DependencyService.Get<DatabaseService>();
            await dbService.InitializeDatabaseAsync();
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
