using Android.App;
using Android.Content;
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
        private List<EventDataImage> dataList = new List<EventDataImage>();

        public PulloutEventAdapter(List<EventDataImage> list)
        {
            this.dataList = list;
        }

        public override int ItemCount => dataList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PulloutEventAdapterViewHolder viewHolder = holder as PulloutEventAdapterViewHolder;
            viewHolder.thumbnail.SetImageBitmap(dataList[position].thumbnail);
            viewHolder.eventName.Text = dataList[position].name;
            viewHolder.eventDateAndTime.Text = dataList[position].dateTime.ToString();
            viewHolder.eventDescription.Text = dataList[position].description;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.pullout_event_card, parent, false);
            itemView.Click += (o, e) =>
            {
                Toast.MakeText(parent.Context, "Clicked", ToastLength.Short).Show();
            };
            return new PulloutEventAdapterViewHolder(itemView);
        }
    }
}