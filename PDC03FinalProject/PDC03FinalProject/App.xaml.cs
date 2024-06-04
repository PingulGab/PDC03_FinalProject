using PDC03FinalProject.Services;
using PDC03FinalProject.Views;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC03FinalProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Register the DatabaseService as a singleton
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SustainActions.db3");
            DependencyService.RegisterSingleton(new DatabaseService(dbPath));

            MainPage = new NavigationPage(new MainPage());
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