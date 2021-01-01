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
        Button changePasswordButton;
        Button deleteAccountButton;

        EditText changePasswordText;
        EditText changePasswordRepeatText;
        EditText deleteAccountText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settings);
            // Create your application here

            changePasswordButton = FindViewById<Button>(Resource.Id.settingsChangePasswordButton);
            changePasswordButton.Click += ChangePassword;
            deleteAccountButton = FindViewById<Button>(Resource.Id.settingsDeleteAccountButton);
            deleteAccountButton.Click += DeleteAccount;

            changePasswordText = FindViewById<EditText>(Resource.Id.settingsPasswordTextBox);
            changePasswordRepeatText = FindViewById<EditText>(Resource.Id.settingsRepeatPasswordTextBox);
            deleteAccountText = FindViewById<EditText>(Resource.Id.settingsDeleteAccountTextBox);
        }

        public void ChangePassword(object o, EventArgs e)
        {
            string newPassword = changePasswordText.Text;
            string newPasswordRepeat = changePasswordRepeatText.Text;

            var result = Validator.ValidatePassword(newPassword);
            if (!result.isValid)
            {
                Toast.MakeText(this, result.message, ToastLength.Long).Show();
                return;
            }

            if (newPassword != newPasswordRepeat)
            {
                Toast.MakeText(this, "Passwords don't match", ToastLength.Short).Show();
            }
            else
            {
                if (RequestSender.SetLoggedInAccountPassword(newPassword, false))
                {
                    Toast.MakeText(this, "Password changed successfully!", ToastLength.Short).Show();
                    changePasswordText.Text = "";
                    changePasswordRepeatText.Text = "";
                }
                else
                {
                    Toast.MakeText(this, "Password change failed", ToastLength.Short).Show();
                }
            }
        }

        public void DeleteAccount(object o, EventArgs e)
        {
            string confirmationText = deleteAccountText.Text;

            if (confirmationText == "delete")
            {
                int id = RequestSender.GetLoggedInAccountId();
                RequestSender.DeleteAccount(id);
                Toast.MakeText(this, "Account deleted successfully!", ToastLength.Short).Show();
                MainActivity.IsLoggedIn = false;
            }
            else
            {
                Toast.MakeText(this, "\"delete\" was entered incorrectly", ToastLength.Short).Show();
            }
        }
    }
}