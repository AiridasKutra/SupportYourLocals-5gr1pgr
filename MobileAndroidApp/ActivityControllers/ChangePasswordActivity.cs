using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using WebApi;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost")]
    public class ChangePasswordActivity : Activity
    {
        View changePasswordButton;

        EditText changePasswordText;
        EditText changePasswordRepeatText;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.change_password_popup);

            DisplayMetrics dm = new DisplayMetrics();
            this.WindowManager.DefaultDisplay.GetMetrics(dm);
            int width = dm.WidthPixels;
            int height = dm.HeightPixels;

            changePasswordText = FindViewById<EditText>(Resource.Id.newPasswordTextBox);
            changePasswordRepeatText = FindViewById<EditText>(Resource.Id.newPasswordRepeatTextBox);
            changePasswordButton = FindViewById<View>(Resource.Id.changePasswordButton);
            changePasswordButton.Click += ChangePassword; 

            Window.SetLayout((int)(width * 0.8), (int)(height*0.5));
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
    }

}