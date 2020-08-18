using System;
using System.IO;
using Test_API.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test__API
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
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
