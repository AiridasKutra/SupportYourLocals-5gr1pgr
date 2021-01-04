using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileAndroidApp;
using localhost.ActivityControllers.Recycler_helpers;
using Android.Graphics;
using Android.Content;
using System.Net;
using WebApi.Classes;

namespace localhost.ActivityControllers.Recycler_adapters
{

    class PulloutEventAdapterViewHolder : RecyclerView.ViewHolder
    {
        public ImageView thumbnail { get; set; }
        public TextView eventName { get; set; }
        public TextView eventDateAndTime { get; set; }
        public TextView eventDescription { get; set; }
        public PulloutEventAdapterViewHolder(View itemView) : base(itemView)
        {
            thumbnail = itemView.FindViewById<ImageView>(Resource.Id.MainEventImage);
            eventName = itemView.FindViewById<TextView>(Resource.Id.MainEventName);
            eventDateAndTime = itemView.FindViewById<TextView>(Resource.Id.MainEventDate);
            eventDescription = itemView.FindViewById<TextView>(Resource.Id.MainEventDescription);
        }
    }
    class PulloutEventAdapter : RecyclerView.Adapter
    {
        public List<Event> dataList = new List<Event>();
        private List<PulloutEventAdapterViewHolder> viewHolders = new List<PulloutEventAdapterViewHolder>();

        public PulloutEventAdapter(List<Event> list)
        {
            this.dataList = list;
        }

        public override int ItemCount => dataList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PulloutEventAdapterViewHolder viewHolder = holder as PulloutEventAdapterViewHolder;

            if (dataList[position].Images.Count > 0)
            {
                try
                {
                    using (var webClient = new WebClient())
                    {
                        var imageBytes = webClient.DownloadData(dataList[position].Images[0]);
                        if (imageBytes != null && imageBytes.Length > 0)
                        {
                            viewHolder.thumbnail.SetImageBitmap(BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length));
                        }
                    }
                }
                catch { }
            }

            viewHolder.eventName.Text = dataList[position].Name;
            viewHolder.eventDateAndTime.Text = $"{dataList[position].StartDate:yyyy-MM-dd} at {dataList[position].StartDate:HH:mm}";
            viewHolder.eventDescription.Text = dataList[position].Description;

            viewHolder.ItemView.Click += (o, e) =>
            {
                Intent intent = new Intent(viewHolder.ItemView.Context, typeof(EventViewActivity));
                intent.PutExtra("eventID", dataList[position].Id);
                viewHolder.ItemView.Context.StartActivity(intent);
            };
            viewHolders.Add(viewHolder);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.pullout_event_card, parent, false);
            return new PulloutEventAdapterViewHolder(itemView);
        }
    }
}