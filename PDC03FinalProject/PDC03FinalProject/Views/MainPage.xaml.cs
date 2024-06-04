using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDC03FinalProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var button = new Button { Text = "Go to Action List" };
            button.Clicked += async (sender, e) => await Navigation.PushAsync(new ActionListPage());
            Content = new StackLayout
            {
                Children = { button }
            };
        }
    }
}
