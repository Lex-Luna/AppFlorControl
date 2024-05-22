
using AppFlorControl.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppFlorControl
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new NavigationPage(new Menuprincipal());
            //MainPage = new NavigationPage(new Asignaciones());

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
