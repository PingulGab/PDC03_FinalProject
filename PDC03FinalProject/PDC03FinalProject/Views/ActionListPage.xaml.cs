using PDC03FinalProject.Helpers;
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
    public partial class ActionListPage : ContentPage
    {
        public ActionListPage()
        {
            InitializeComponent();
        }

        public void ReloadData()
        {
            if (BindingContext is ActionItemViewModel viewModel)
            {
                viewModel.LoadItems().SafeFireAndForget(false);
            }
        }
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && BindingContext is ActionItemViewModel viewModel)
            {
                viewModel.ItemSelectedCommand.Execute(e.Item);
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}