using PDC03FinalProject.Models;
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
    public partial class DetailPage : ContentPage
    {
        public DetailPage(SustainabilityHandbook actionItem)
        {
            InitializeComponent();
            BindingContext = new DetailViewModel(actionItem);
        }
    }
}