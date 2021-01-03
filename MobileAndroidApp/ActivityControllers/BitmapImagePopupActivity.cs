using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost", Theme = "@style/Theme.Transparent")]
    class BitmapImagePopupActivity : Activity
    {
        ImageView imageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.image_popup);

            string link = Intent.GetStringExtra("image_link");

            DisplayMetrics dm = new DisplayMetrics();
            this.WindowManager.DefaultDisplay.GetMetrics(dm);
            int width = dm.WidthPixels;
            int height = dm.HeightPixels;

            imageView = FindViewById<ImageView>(Resource.Id.bitmapImageView);
            imageView.SetScaleType(ImageView.ScaleType.FitCenter);

            RunOnUiThread(() =>
            {
                try
                {
                    using var webClient = new WebClient();

                    var imageBytes = webClient.DownloadData(link);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        Bitmap img = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                        imageView.Alpha = 0.0f;
                        imageView.SetImageBitmap(img);
                        imageView.Animate().Alpha(1.0f);
                    }
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "Unable to load image", ToastLength.Long).Show();
                }
            });

            Window.SetLayout(width, height);
        }
    }
}