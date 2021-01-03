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
using static Android.Gms.Maps.GoogleMap;

namespace localhost.ActivityControllers.PinClick
{
    class MarkerListener : Java.Lang.Object, IOnMarkerClickListener
    {
        Context context;
        public MarkerListener(Context context)
        {
            this.context = context;
        }
        public bool OnMarkerClick(Marker marker)
        {
            Console.WriteLine("CLICKED");
            if (marker.Draggable)
            {
                try
                {
                    marker.Draggable = false;
                    Intent intent = new Intent(context, typeof(EventViewActivity));
                    intent.PutExtra("eventID", (int)marker.ZIndex);

                    context.StartActivity(intent);
                }
                catch
                {
                    Toast.MakeText(context, "Failed to open", ToastLength.Short);
                }
            }
            else
            {
                marker.Draggable = true;
            }
            
            return false;
        }
    }
}