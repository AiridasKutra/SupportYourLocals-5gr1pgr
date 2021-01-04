using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
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
    public class ReportEventActivity : Activity
    {

        private EditText reasonTextBox;
        private EditText commentsTextBox;
        private Button reportButton;
        private int eventId;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.report_window_popout);

            eventId = Intent.GetIntExtra("eventID", 0);


            reasonTextBox = FindViewById<EditText>(Resource.Id.reportNameTextBox);
            commentsTextBox = FindViewById<EditText>(Resource.Id.reportContextTextBox);
            reportButton = FindViewById<Button>(Resource.Id.button);
            reportButton.Click += SubmitReport;

            DisplayMetrics dm = new DisplayMetrics();
            this.WindowManager.DefaultDisplay.GetMetrics(dm);
            int width = dm.WidthPixels;
            int height = dm.HeightPixels;

            var layout = Window.Attributes;
            layout.DimAmount = 0.5f;
            Window.AddFlags(WindowManagerFlags.DimBehind);
            Window.Attributes = layout;

            Window.SetLayout((int)(width * 0.8), (int)(height * 0.7));
        }

        private void SubmitReport(object sender, EventArgs e)
        {
            if(reasonTextBox.Text.Length < 4)
            {
                reasonTextBox.Error = "Too little information";
                return;
            }

            var report = new WebApi.Classes.Report();
            report.Type = reasonTextBox.Text;
            report.Comment = commentsTextBox.Text;
            RequestSender.CreateReport(report,eventId);
            Finish();
        }
    }
}