using Android.App;
using Android.Content;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi;

namespace localhost.ActivityControllers
{
    [Activity(Label = "EventViewActivity")]
    public class EventViewActivity : Activity
    {
        TextView eventName;

        private int eventID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            eventName = FindViewById<TextView>(Resource.Id.txtEventName);

            SetContentView(Resource.Layout.event_view);

            //eventID = Intent.GetIntExtra("eventID", 0);

            //var @event = RequestSender.GetFullEvent(eventID);

            //Toast.MakeText(this, eventID, ToastLength.Long).Show();
            //eventName.Text = @event.Name;
        }
    }
}