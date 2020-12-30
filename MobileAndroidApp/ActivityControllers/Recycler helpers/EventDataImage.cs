using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace localhost.ActivityControllers.Recycler_helpers
{
    class EventDataImage
    {
        public Bitmap thumbnail { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime dateTime { get; set; }
    }
}