using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.LEJ.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.LEJ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel )
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
            

            //hack to deselect the selected item (MVVM)
            ItemsListView.ItemSelected += (s, e) =>
            ItemsListView.SelectedItem = null;
        }
       
    }
}