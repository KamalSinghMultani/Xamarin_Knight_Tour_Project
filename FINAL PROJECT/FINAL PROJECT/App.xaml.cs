using FINAL_PROJECT.Services;
using FINAL_PROJECT.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FINAL_PROJECT
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new Authentication());
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
