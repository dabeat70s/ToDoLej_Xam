using System;
using ToDo.LEJ.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.LEJ
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(Resolver.Resolve<MainView>()); //Autofac
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
