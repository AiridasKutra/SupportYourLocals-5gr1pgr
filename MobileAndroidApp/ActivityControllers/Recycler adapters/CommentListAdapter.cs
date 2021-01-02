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
using WebApi;

namespace localhost.ActivityControllers.Recycler_adapters
{
    class CommentAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView CommentInfo { get; set; }
        public TextView CommentText { get; set; }
        public ImageButton SilenceButton { get; set; }
        public ImageButton BanButton { get; set; }
        public ImageButton DeleteButton { get; set; }
        public CommentAdapterViewHolder(View itemView) : base(itemView)
        {
            CommentInfo = itemView.FindViewById<TextView>(Resource.Id.txtCommnentInfo);
            CommentText = itemView.FindViewById<TextView>(Resource.Id.txtCommentText);
            SilenceButton = itemView.FindViewById<ImageButton>(Resource.Id.btnSilenceUser);
            BanButton = itemView.FindViewById<ImageButton>(Resource.Id.btnBanUser);
            DeleteButton = itemView.FindViewById<ImageButton>(Resource.Id.btnDeleteComment);
        }
    }
    class CommentListAdapter : RecyclerView.Adapter
    {
        private List<WebApi.Classes.Message> dataList = new List<WebApi.Classes.Message>();

        public CommentListAdapter(List<WebApi.Classes.Message> list)
        {
            this.dataList = list;
        }

        public override int ItemCount => dataList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CommentAdapterViewHolder viewHolder = holder as CommentAdapterViewHolder;
            viewHolder.CommentInfo.Text = "By " + RequestSender.GetAccountUsername(dataList[position].Sender) + " At " + dataList[position].SendTime.ToString();
            viewHolder.CommentText.Text = dataList[position].Content;

            // Show/hide buttons
            viewHolder.CommentText.LongClick += (o, e) => 
            {
                if (viewHolder.SilenceButton.Visibility == ViewStates.Visible)
                {
                    viewHolder.SilenceButton.Visibility = ViewStates.Gone;
                    viewHolder.BanButton.Visibility = ViewStates.Gone;
                    viewHolder.DeleteButton.Visibility = ViewStates.Gone;
                }
                else
                {
                    viewHolder.SilenceButton.Visibility = ViewStates.Visible;
                    viewHolder.BanButton.Visibility = ViewStates.Visible;
                    viewHolder.DeleteButton.Visibility = ViewStates.Visible;
                }
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.comment_card, parent, false);
            return new CommentAdapterViewHolder(itemView);
        }
    }
}