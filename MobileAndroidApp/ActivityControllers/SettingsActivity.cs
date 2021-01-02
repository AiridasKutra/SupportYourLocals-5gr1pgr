using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileAndroidApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost")]
    public class SettingsActivity : Activity
    {
        View changePasswordButton;
        View deleteAccountButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settings);
            // Create your application here

            changePasswordButton = FindViewById<View>(Resource.Id.changePasswordPlatform);
            changePasswordButton.Click += ChangePassword;
            deleteAccountButton = FindViewById<View>(Resource.Id.deleteAccountPlatform);
            deleteAccountButton.Click += DeleteAccount;

        }

        public void ChangePassword(object o, EventArgs e)
        {

            StartActivity(typeof(ChangePasswordActivity));

        }

        public void DeleteAccount(object o, EventArgs e)
        {
            
            Intent intent = new Intent(this, typeof(DeleteAccountActivity));
            StartActivityForResult(intent, 1);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if(resultCode == Result.Ok || resultCode.Equals(Result.Ok))
            {
                Intent intent = new Intent();
                intent.PutExtra("DELETED", "data");
                SetResult(Result.Ok, intent);
                this.Finish();
            }
        }

    }
}