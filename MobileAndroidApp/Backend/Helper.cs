using System;
using System.Collections.Generic;
using Android.Graphics;
using System.Text;

namespace localhost.Backend
{
    class Helper
    {
        public static Bitmap ScaleBitmap(Bitmap source, int width, int height)
        {
            float ratio;
            if (source.Width / (float)source.Height > width / (float)height)
            {
                ratio = height / (float)source.Height;
            }
            else
            {
                ratio = width / (float)source.Width;
            }

            int newWidth = (int)Math.Ceiling(source.Width * ratio);
            int newHeight = (int)Math.Ceiling(source.Height * ratio);
            int posX = Math.Abs(newWidth - width) / 2;
            int posY = Math.Abs(newHeight - height) / 2;

            var scaled = Bitmap.CreateScaledBitmap(source, newWidth, newHeight, true);
            return Bitmap.CreateBitmap(scaled, posX, posY, width, height);
        }
    }
}
