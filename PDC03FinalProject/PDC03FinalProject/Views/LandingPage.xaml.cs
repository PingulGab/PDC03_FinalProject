using System;
using Xamarin.Forms;

namespace PDC03FinalProject.Views
{
    public partial class LandingPage : TabbedPage
    {
        public LandingPage()
        {
            InitializeComponent();
            UpdateTitle(); // Set the initial title
        }

        // Event handler with correct signature for CurrentPageChanged event
        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            UpdateTitle();
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
