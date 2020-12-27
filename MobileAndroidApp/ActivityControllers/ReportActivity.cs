using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using AndroidX.ConstraintLayout.Widget;
using System;
using localhost;
using Android.Widget;


namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost")]
    public class ReportActivity : Activity
    {
        private Button sumbitButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.report);
            var layout = FindViewById<ConstraintLayout>(Resource.Id.container);
            layout.Click += HideKeyboard;
            sumbitButton = FindViewById<Button>(Resource.Id.button1); //I dunno why but anything other than button1 doesnt work so please just let it be
            sumbitButton.Click += SumbitClick;
        }
    
    
        
        public void SumbitClick(object o, EventArgs e)
        {
            //Sumbit report here
            Toast.MakeText(this, "Report sumbited",ToastLength.Short).Show();
        }
        public void HideKeyboard(object o, EventArgs e)
        {
            View view = this.CurrentFocus;
            if (view != null)
            {
                InputMethodManager im = (InputMethodManager)GetSystemService(Context.InputMethodService);
                im.HideSoftInputFromWindow(view.WindowToken, 0);
            }
        }
    }
       
}