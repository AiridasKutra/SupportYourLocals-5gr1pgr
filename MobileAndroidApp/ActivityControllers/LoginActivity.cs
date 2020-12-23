using Android.App;
using Android.OS;
using Android.Widget;
using MobileAndroidApp;
using System;

namespace localhost.ActivityControllers
{
    [Activity(Label = "Activity1")]
    public class LoginActivity : Activity
    {
        Button loginButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            // Create your application here
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += LogIn;
        }

        public void LogIn(object o, EventArgs e)
        {
            MainActivity.IsLoggedIn = true;
            Toast.MakeText(this,"Logged in", ToastLength.Short).Show();
            Finish();
        }
    }
}