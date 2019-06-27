using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TurAgencijaRS2_Mobile1.Views;
using Windows.UI.ViewManagement;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TurAgencijaRS2_Mobile1
{
    public partial class App : Application
    {

      

        public App()
        {
            InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Windows.Foundation.Size(600,800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            MainPage = new LoginPage();
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
