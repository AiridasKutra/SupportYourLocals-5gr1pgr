using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost")]
    public class SignUpActivity : Activity
    {
        Button createAccountButton;

        EditText emailEdit;
        EditText usernameEdit;
        EditText passwordEdit;
        EditText passwordRepeatEdit;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.signup);

            createAccountButton = FindViewById<Button>(Resource.Id.signUpButton);
            createAccountButton.Click += CreateAccount;

            emailEdit = FindViewById<EditText>(Resource.Id.signupEmailTextBox);
            usernameEdit = FindViewById<EditText>(Resource.Id.signupUsernameTextBox);
            passwordEdit = FindViewById<EditText>(Resource.Id.signupPasswordTextBox);
            passwordRepeatEdit = FindViewById<EditText>(Resource.Id.signupPasswordRepeatTextBox);
        }

        public void CreateAccount(object o, EventArgs e)
        {
            string email = emailEdit.Text;
            string username = usernameEdit.Text;
            string password = passwordEdit.Text;
            string passwordRepeat = passwordRepeatEdit.Text;

            if (passwordRepeat != password)
            {
                Toast.MakeText(this, "Passwords don't match", ToastLength.Long).Show();
                return;
            }

            string errorMsg = RequestSender.CreateAccount(email, username, password, false);

            if (errorMsg.Length > 0)
            {
                Toast.MakeText(this, errorMsg, ToastLength.Long).Show();
                return;
            }

            Toast.MakeText(this, "Account created successfully!", ToastLength.Short).Show();
            Finish();
        }
    }
}