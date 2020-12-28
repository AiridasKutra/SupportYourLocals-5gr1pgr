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

namespace localhost.ActivityControllers.Recycler_adapters
{

    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public TextView EventName { get; set; }
        public TextView Activity { get; set; }
        public TextView Date { get; set; }
        public TextView Time { get; set; }
        public RecyclerViewHolder(View itemView):base(itemView)
        {
            EventName = itemView.FindViewById<TextView>(Resource.Id.eventNameLabel);
            Activity = itemView.FindViewById<TextView>(Resource.Id.activeLabel);
            Date = itemView.FindViewById<TextView>(Resource.Id.dateLabel);
            Time = itemView.FindViewById<TextView>(Resource.Id.timeLabel);
        }
    }
    class EventListAdapter : RecyclerView.Adapter
    {
        private List<EventData> dataList = new List<EventData>();
        
        public EventListAdapter(List<EventData> list)
        {
            this.dataList = list;
        }

        public override int ItemCount => dataList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
            viewHolder.EventName.Text = dataList[position].EventName;
            viewHolder.Activity.Text = dataList[position].Activity;
            viewHolder.Date.Text = dataList[position].DateTime.Date.ToString("D");
            viewHolder.Time.Text = dataList[position].DateTime.ToString("t");
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.event_card, parent, false);
            itemView.Click += (o, e) =>
            {
                Toast.MakeText(parent.Context, "Clicked", ToastLength.Short).Show();
            };
            return new RecyclerViewHolder(itemView);

        }
    }
}