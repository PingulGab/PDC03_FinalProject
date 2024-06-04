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
    public partial class UserActivityDetailPage : ContentPage
    {
        public UserActivityDetailPage(UserActivityLog log)
        {
            InitializeComponent();
            BindingContext = new UserActivityDetailViewModel(log);
        }
    }
}