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
using System.Text;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost")]
    class BitmapImagePopupActivity : Activity
    {
        ImageView imageView;

        public static Bitmap image;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.image_popup);

            DisplayMetrics dm = new DisplayMetrics();
            this.WindowManager.DefaultDisplay.GetMetrics(dm);
            int width = dm.WidthPixels;
            int height = dm.HeightPixels;

            imageView = FindViewById<ImageView>(Resource.Id.bitmapImageView);
            imageView.SetImageBitmap(image);

            Window.SetLayout((int)(width * 0.9), (int)(height * 0.8));
            
        }
    }
}