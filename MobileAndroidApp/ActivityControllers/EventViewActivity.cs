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
using localhost.Backend;
using System.Threading;
using Android.Support.V7.Widget;
using localhost.ActivityControllers.Recycler_adapters;

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
        ImageButton eventSubmitComment;

        private RecyclerView commentListView;
        private RecyclerView.Adapter commentListAdapter;
        private RecyclerView.LayoutManager commentListLayout;

        int eventID;
        double eventLatitude, eventLongitude;

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
            eventSubmitComment = FindViewById<ImageButton>(Resource.Id.btnSubmitComment);

            commentListView = FindViewById<RecyclerView>(Resource.Id.commentRecyclerView);

            // Get event info
            eventID = Intent.GetIntExtra("eventID", 0);
            var @event = RequestSender.GetFullEvent(eventID);

            // Setting the distance
            eventLatitude = @event.Latitude;
            eventLongitude = @event.Longitude;
            var userLocation = Geolocation.GetLastKnownLocationAsync();
            double distance = MathSupplement.Distance(eventLatitude, eventLongitude, userLocation.Result.Latitude, userLocation.Result.Longitude);
            if (userLocation != null)
            {
                if (distance < 1000.0) eventDistance.Text = $"{distance:0}m";
                else eventDistance.Text = $"{distance / 1000.0:0.0}km";
            }

            // Event name and address
            eventName.Text = @event.Name;
            eventAddress.Text = @event.Address.Address;

            // Images
            int imageWidth = 700;
            int imageHeight = 450;
            foreach (var item in @event.Images)
            {
                Bitmap img;
                Bitmap scaledImg = Bitmap.CreateBitmap(imageWidth, imageHeight, Bitmap.Config.Argb8888);

                ImageView imgView = new ImageView(this);
                imgView.SetImageBitmap(scaledImg);
                LinearLayout.LayoutParams imgViewParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent, 0.0f);
                imgViewParams.SetMargins(16, 16, 16, 16);
                imgView.LayoutParameters = imgViewParams;
                eventImages.AddView(imgView);

                Thread imageLoader = new Thread(new ThreadStart(() =>
                {
                    try
                    {
                        using var webClient = new WebClient();

                        var imageBytes = webClient.DownloadData(item);
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            img = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                            scaledImg = Helper.ScaleBitmap(img, imageWidth, imageHeight);
                            imgView.Alpha = 0.0f;
                            imgView.SetImageBitmap(scaledImg);
                            imgView.Animate().Alpha(1.0f);
                        }
                    }
                    catch { }
                }));
                imageLoader.Start();
            }

            // Event description
            eventDescription.Text = @event.Description;

            // Load comments
            commentListView.HasFixedSize = true;
            commentListLayout = new LinearLayoutManager(this);
            commentListView.SetLayoutManager(commentListLayout);
            commentListAdapter = new CommentListAdapter(eventID);
            commentListView.SetAdapter(commentListAdapter);

            // Check if eligible to comment
            if (!RequestSender.ThisAccount().Can((uint)WebApi.Classes.Permissions.SEND_CHAT_MESSAGES))
            {
                eventNewComment.Enabled = false;
                eventSubmitComment.Enabled = false;
            }
            else
            {
                eventNewComment.Enabled = true;
                eventSubmitComment.Enabled = true;
            }

            // Send comment button
            eventSubmitComment.Click += (o, e) =>
            {
                RequestSender.CreateComment(eventID, eventNewComment.Text);
                
                eventNewComment.Text = "";

                commentListView.HasFixedSize = true;
                commentListLayout = new LinearLayoutManager(this);
                commentListView.SetLayoutManager(commentListLayout);
                commentListAdapter = new CommentListAdapter(eventID);
                commentListView.SetAdapter(commentListAdapter);

                Toast.MakeText(this, "Comment submited!", ToastLength.Short).Show();
            };
        }
    }
}