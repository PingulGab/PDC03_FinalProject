using System;
using Xamarin.Forms;

namespace PDC03FinalProject.Views
{
    public partial class LandingPage : TabbedPage
    {
        public LandingPage()
        {
            InitializeComponent();
            UpdateTitle();
        }

        // Event handler with correct signature for CurrentPageChanged event
        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            UpdateTitle();

            // Check if the current page is AchievementsPage
            if (CurrentPage is AchievementsPage)
            {
                // Call a method to reload the data
                (CurrentPage as AchievementsPage)?.ReloadData();
            }
            else if (CurrentPage is MySustainActivityPage)
            {
                (CurrentPage as MySustainActivityPage)?.ReloadData();
            }
            else if (CurrentPage is ActionListPage)
            {
                (CurrentPage as ActionListPage)?.ReloadData();
            }
        }

        private void UpdateTitle()
        {
            var currentPage = CurrentPage;
            if (currentPage is NavigationPage navigationPage)
            {
                Title = navigationPage.CurrentPage.Title;
            }
            else
            {
                Title = currentPage.Title;
            }
        }
    }
}
