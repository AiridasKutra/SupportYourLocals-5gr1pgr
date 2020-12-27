using Android.App;
using Android.Content;
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
    class EventData
    {
        public string EventName { get; set; }
        public string Activity { get; set; }    
        public DateTime DateTime { get; set; }
    }
}