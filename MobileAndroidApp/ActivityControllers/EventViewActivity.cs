using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using GoogleMaps.LocationServices;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using WebApi;
using Xamarin.Essentials;
using localhost.Backend.Location;
using System.Threading.Tasks;

namespace localhost.ActivityControllers
{
    [Activity(Label = "EventViewActivity")]
    public class EventViewActivity : Activity
    {
        TextView eventName, eventDistance, eventAddress, eventDescription;
        ImageView eventLocate;
        HorizontalScrollView horizontalScroll;
        LinearLayout eventImages;
        EditText eventNewComment;
        Button eventSubmitComment;

        int eventID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.event_view);

            eventName = FindViewById<TextView>(Resource.Id.txtEventName);
            eventDistance = FindViewById<TextView>(Resource.Id.txtEventDistance);
            eventAddress = FindViewById<TextView>(Resource.Id.txtEventAddress);
            eventLocate = FindViewById<ImageView>(Resource.Id.imgLocate);
            eventImages = FindViewById<LinearLayout>(Resource.Id.lnlImages);
            eventDescription = FindViewById<TextView>(Resource.Id.txtDescription);
            horizontalScroll = FindViewById<HorizontalScrollView>(Resource.Id.scrIEventImages);
            eventNewComment = FindViewById<EditText>(Resource.Id.edtNewComment);
            eventSubmitComment = FindViewById<Button>(Resource.Id.btnSubmitComment);



            eventID = Intent.GetIntExtra("eventID", 0);
            var @event = RequestSender.GetFullEvent(eventID);
            var location = GetLocationAsync();

            eventName.Text = @event.Name;
            eventAddress.Text = @event.Address.Address;

            double distance = MathSupplement.Distance(@event.Latitude, @event.Longitude, location.Result.Latitude, location.Result.Longitude);
            if (distance < 1000.0)
            {
                eventDistance.Text = $"{distance:0}m";
            }
            else
            {
                eventDistance.Text = $"{distance / 1000.0:0.0}km";
            }


            ImageView imgView;
            Bitmap img, scaledImg;
            //double screenWidth = DeviceDisplay.MainDisplayInfo.Width;
            int imageHeight = 500;
            float aspect;
            foreach (var item in @event.Images)
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(item);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        img = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                        aspect = (float)img.Width / (float)img.Height;
                        scaledImg = Bitmap.CreateScaledBitmap(img, (int)(imageHeight*aspect), imageHeight, true);

                        imgView = new ImageView(this);
                        imgView.SetImageBitmap(scaledImg);
                        LinearLayout.LayoutParams imgViewParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent, 0.0f);
                        imgViewParams.SetMargins(32, 0, 32, 0);
                        imgView.LayoutParameters = imgViewParams;
                        eventImages.AddView(imgView);
                    }
                }
            }

            eventDescription.Text = @event.Description;
        }

        private async System.Threading.Tasks.Task<Location> GetLocationAsync()
        {
            return await Geolocation.GetLastKnownLocationAsync();
        }
    }
}