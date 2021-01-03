using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Text;
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

            bool success = true;

            if (passwordRepeat != password)
            {
                passwordRepeatEdit.Error = Html.FromHtml("<font color='red'>Passwords don't match</font>").ToString();
                success = false;
            }


            var emailRes = Validator.ValidateEmail(email);
            var usernameRes = Validator.ValidateUsername(username);
            var passwordRes = Validator.ValidatePassword(password);
            if (!emailRes.isValid)
            {
                emailEdit.Error = Html.FromHtml($"<font color='red'>{emailRes.message}</font>").ToString();
                success = false;
            }
            if (!usernameRes.isValid)
            {
                usernameEdit.Error = Html.FromHtml($"<font color='red'>{usernameRes.message}</font>").ToString();
                success = false;
            }
            if (!passwordRes.isValid)
            {
                passwordEdit.Error = Html.FromHtml($"<font color='red'>{passwordRes.message}</font>").ToString();
                success = false;
            }

            if (!success) return;

            
            string[] errorMsgs = RequestSender.CreateAccount(email, username, password, false).Split(';');

            if (errorMsgs[0].Length > 0)
            {
                usernameEdit.Error = Html.FromHtml($"<font color='red'>{errorMsgs[0]}</font>").ToString();
                success = false;
            }
            if (errorMsgs[1].Length > 0)
            {
                emailEdit.Error = Html.FromHtml($"<font color='red'>{errorMsgs[1]}</font>").ToString();
                success = false;
            }
            if (!success) return;

            Toast.MakeText(this, "Account created successfully!", ToastLength.Short).Show();
            Finish();
        }
    }
}