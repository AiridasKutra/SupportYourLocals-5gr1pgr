using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
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
    [Activity(Label = "Activity1")]
    public class DeleteAccountActivity : Activity
    {
        private static string confirmationWord;

        private EditText confirmationText;
        private Button deleteButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            confirmationWord = words[new Random().Next(0, 50)];

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.delete_account);

            confirmationText = FindViewById<EditText>(Resource.Id.editTextTextPersonName);
            confirmationText.Hint = $"Type the word: {confirmationWord}";

            deleteButton = FindViewById<Button>(Resource.Id.deleteButton);
            deleteButton.Click += DeleteAccount;

            DisplayMetrics dm = new DisplayMetrics();
            this.WindowManager.DefaultDisplay.GetMetrics(dm);
            int width = dm.WidthPixels;
            int height = dm.HeightPixels;

            var layout = Window.Attributes;
            layout.DimAmount = 0.5f;
            Window.AddFlags(WindowManagerFlags.DimBehind);
            Window.Attributes = layout;
            
            Window.SetLayout((int)(width * 0.8), (int)(height * 0.35));
        }

        private void DeleteAccount(object o, EventArgs e)
        {
            if(confirmationText.Text == confirmationWord)
            {   
                RequestSender.DeleteAccount(RequestSender.ThisAccount().Id);
                Toast.MakeText(this,"Successfully deleted account",ToastLength.Long).Show();
                MainActivity.IsLoggedIn = false;

                Intent intent = new Intent();
                intent.PutExtra("DELETED","data");
                SetResult(Result.Ok, intent);
                this.Finish();
            }
            else
            {
                Toast.MakeText(this, "Confirmation word doesn't match", ToastLength.Short).Show();
            }
        }

        private static List<string> words = new List<string>()
        {
"qualify",
"expenditure",
"cylinder",
"survival",
"conflict",
"unlikely",
"activity",
"address",
"relation",
"crosswalk",
"publicity",
"inflate",
"overcharge",
"regulation",
"private",
"concentration",
"demonstrator",
"waterfall",
"notebook",
"legislature",
"progressive",
"mourning",
"document",
"insight",
"presidency",
"theater",
"sequence",
"consolidate",
"convulsion",
"projection",
"literacy",
"password",
"monstrous",
"demonstrate",
"profile",
"institution",
"habitat",
"realize",
"pneumonia",
"flourish",
"interference",
"consciousness",
"nominate",
"migration",
"experienced",
"management",
"manufacturer",
"nomination",
"expansion",
"fastidious"
    };
}
}