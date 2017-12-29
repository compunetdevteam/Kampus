
using Android.App;
using Android.OS;

namespace Kampus.Droid
{
    [Activity(Label = "EBSU", MainLauncher = true, NoHistory = true, Icon = "@drawable/ebsuicon", Theme = "@style/Theme.Splash")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Threading.Thread.Sleep(500);
            StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}