using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using localhost.ActivityControllers.Recycler_adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi;

namespace localhost.ActivityControllers
{
    [Activity(Label = "ViewReportsActivity")]
    public class ViewReportsActivity : Activity
    {
        private RecyclerView ReportListView;
        private RecyclerView.Adapter reportViewAdapter;
        private RecyclerView.LayoutManager ReportListLayout;

        private int eventID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_reports);

            ReportListView = FindViewById<RecyclerView>(Resource.Id.reportRecyclerView);

            eventID = Intent.GetIntExtra("eventID", 0);

            DisplayMetrics dm = new DisplayMetrics();
            this.WindowManager.DefaultDisplay.GetMetrics(dm);
            int width = dm.WidthPixels;
            int height = dm.HeightPixels;

            var layout = Window.Attributes;
            layout.DimAmount = 0.5f;
            Window.AddFlags(WindowManagerFlags.DimBehind);
            Window.Attributes = layout;

            Window.SetLayout((int)(width * 0.8), (int)(height * 0.8));

            ReportListView.HasFixedSize = true;
            ReportListLayout = new LinearLayoutManager(this);
            ReportListView.SetLayoutManager(ReportListLayout);
            reportViewAdapter = new ReportViewAdapter(RequestSender.GetReports(eventID));
            ReportListView.SetAdapter(reportViewAdapter);
        }
    }
}