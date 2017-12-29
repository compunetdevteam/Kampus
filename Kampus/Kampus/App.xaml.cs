
using Kampus.Views;
using Xamarin.Forms;

namespace Kampus
{
    public partial class App : Application
    {
        private bool IsFirstTime;
        public App()
        {

            InitializeComponent();
            
           //MainPage = new NavigationPage(new Login());

            MainPage = new MainPage();
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
