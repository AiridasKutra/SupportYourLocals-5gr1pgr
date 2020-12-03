using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace localhostUI
{
    class Helper
    {
        public static Size CalculateLabelSize(Label label, int maxWidth)
        {
            return TextRenderer.MeasureText(label.Text, label.Font, new Size(maxWidth, 0), TextFormatFlags.WordBreak);
        }

        public static Bitmap ScaleBitmap(Bitmap source, int width, int height, float aspectRatio = 1.0f)
        {
            float ratio;
            if (source.Width / (float)source.Height > aspectRatio)
            {
                ratio = height / (float)source.Height;
            }
            else
            {
                ratio = width / (float)source.Width;
            }

            int newWidth = (int)(source.Width * ratio);
            int newHeight = (int)(source.Height * ratio);
            int posX = -Math.Abs(newWidth - width) / 2;
            int posY = -Math.Abs(newHeight - height) / 2;

            Bitmap scaledBitmap = new Bitmap(newWidth, newHeight);
            Graphics g = Graphics.FromImage(scaledBitmap);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(source, posX, posY, newWidth, newHeight);
            g.Dispose();

            return scaledBitmap;
        }
    }
}
