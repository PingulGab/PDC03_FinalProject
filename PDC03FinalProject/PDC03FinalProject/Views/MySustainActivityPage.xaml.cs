using PDC03FinalProject.ViewModels;
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
    public partial class MySustainActivityPage : ContentPage
    {
        public MySustainActivityPage()
        {
            InitializeComponent();
            BindingContext = new MySustainActivityViewModel();
        }
    }
}