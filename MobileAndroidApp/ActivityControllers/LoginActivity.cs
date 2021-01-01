﻿using Android.App;
using Android.OS;
using Android.Widget;
using localhost.Backend;
using MobileAndroidApp;
using System;
using WebApi;
using WebApi.Classes;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost")]
    public class LoginActivity : Activity
    {
        Button loginButton;
        Button signupButton;

        EditText emailEdit;
        EditText passwordEdit;
        CheckBox stayLoggedInCheckBox;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            loginButton.Click += LogIn;
            signupButton = FindViewById<Button>(Resource.Id.signUpButton);
            signupButton.Click += SignUp;

            emailEdit = FindViewById<EditText>(Resource.Id.emailTextBox);
            passwordEdit = FindViewById<EditText>(Resource.Id.passwordTextBox);
            stayLoggedInCheckBox = FindViewById<CheckBox>(Resource.Id.stayLoggedInCheckBox);
        }

        public void LogIn(object o, EventArgs e)
        {
            string email = emailEdit.Text;
            string password = passwordEdit.Text;
            bool stayLoggedIn = stayLoggedInCheckBox.Checked;

            VFIDHolder.Value = RequestSender.Login(email, password, false);

            if (VFIDHolder.Value > 0)
            {
                int id = RequestSender.GetLoggedInAccountId();
                Account acc = new Account { Permissions = RequestSender.GetAccountPermissions(id) };
                if (acc.Can((uint)Permissions.VIEW_ACCOUNTS))
                {
                    MainActivity.CanViewAccounts = true;
                }
                MainActivity.IsLoggedIn = true;
                Toast.MakeText(this, "Logged in", ToastLength.Short).Show();
                Finish();
                return;
            }

            Toast.MakeText(this, "Invalid credentials", ToastLength.Short).Show();
        }

        public void SignUp(object o, EventArgs e)
        {
            StartActivity(typeof(SignUpActivity));
            Finish();
        }
    }
}