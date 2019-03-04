using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAssignment.Views;
using XamarinAssignment.Views.DetailPages;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinAssignment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new HomeMasterDetailPage();
            MainPage = new NavigationPage(new HomeMasterDetailPage());
        }

        public void SetHomeScreenAsMainScreen()
        {

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
