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
    class CommentData
    {
        public string CommentInfo { get; set; }
        public string CommentText { get; set; }
        public ImageButton DeleteComment { get; set; }
        public ImageButton SilenceUser { get; set; }
        public ImageButton BanUser { get; set; }
    }
}