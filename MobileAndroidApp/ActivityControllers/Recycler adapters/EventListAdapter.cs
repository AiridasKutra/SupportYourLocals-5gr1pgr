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
using WebApi.Classes;

namespace localhost.ActivityControllers.Recycler_adapters
{

    class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public TextView EventName { get; set; }
        public TextView Activity { get; set; }
        public TextView Date { get; set; }
        public TextView Time { get; set; }
        public RecyclerViewHolder(View itemView) : base(itemView)
        {
            EventName = itemView.FindViewById<TextView>(Resource.Id.eventNameLabel);
            Activity = itemView.FindViewById<TextView>(Resource.Id.activeLabel);
            Date = itemView.FindViewById<TextView>(Resource.Id.dateLabel);
            Time = itemView.FindViewById<TextView>(Resource.Id.timeLabel);
        }
    }
    class EventListAdapter : RecyclerView.Adapter
    {
        private List<Event> eventList = new List<Event>();
        
        public EventListAdapter(List<Event> list)
        {
            this.eventList = list;
        }

        public override int ItemCount => eventList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
            viewHolder.EventName.Text = eventList[position].Name;
            viewHolder.Activity.Text = "Active";
            viewHolder.Date.Text = eventList[position].StartDate.Date.ToString("yyyy-MM-dd");
            viewHolder.Time.Text = eventList[position].StartDate.ToString("t");
            viewHolder.ItemView.SetY(10);
            viewHolder.ItemView.Click += (o,e) => {
                Toast.MakeText(viewHolder.ItemView.Context, "Clicked " + position , ToastLength.Short).Show();
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.event_card, parent, false);
            /*itemView.Click += (o, e) =>
            {
                Toast.MakeText(parent.Context, "Clicked", ToastLength.Short).Show();
            };*/
            return new RecyclerViewHolder(itemView);

        }
    }
}