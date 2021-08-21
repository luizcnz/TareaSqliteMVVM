using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaSqliteMVVM
{
    public partial class App : Application
    {
        public static string EmpleadosDB = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string DBlocal)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            EmpleadosDB = DBlocal;
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
