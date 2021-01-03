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
        int eventID;

        public CommentListAdapter(int eventID)
        {
            this.eventID = eventID;
            this.dataList = RequestSender.GetComments(eventID);
        }

        public override int ItemCount => dataList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            CommentAdapterViewHolder viewHolder = holder as CommentAdapterViewHolder;
            // Enter comment data
            viewHolder.CommentInfo.Text = "By " + RequestSender.GetAccountUsername(dataList[position].Sender) + " At " + dataList[position].SendTime.ToString();
            viewHolder.CommentText.Text = dataList[position].Content;

            // Silence button check
            viewHolder.SilenceButton.Click += (o, e) =>
            {
                if (RequestSender.ThisAccount().Can((uint)WebApi.Classes.Permissions.SILENCE_ACCOUNTS))
                    RequestSender.SilenceAccount(dataList[position].Sender);
            };
            // Ban button check
            viewHolder.BanButton.Click += (o, e) =>
            {
                if (RequestSender.ThisAccount().Can((uint)WebApi.Classes.Permissions.BAN_ACCOUNTS))
                    RequestSender.BanAccount(dataList[position].Sender);
            };
            // Delete button check
            viewHolder.DeleteButton.Click += (o, e) =>
            {
                if (RequestSender.ThisAccount().Can((uint)WebApi.Classes.Permissions.DELETE_COMMENTS))
                {
                    RequestSender.DeleteComment(eventID, dataList[position].Id);
                    dataList.Remove(dataList[position]);
                    this.NotifyItemRemoved(position);
                }
            };

            // Show or hide buttons
            viewHolder.CommentText.LongClick += (o, e) => 
            {
                if (viewHolder.SilenceButton.Visibility == ViewStates.Gone && RequestSender.ThisAccount().Can((uint)WebApi.Classes.Permissions.SILENCE_ACCOUNTS))
                    viewHolder.SilenceButton.Visibility = ViewStates.Visible;
                else 
                    viewHolder.SilenceButton.Visibility = ViewStates.Gone;

                if (viewHolder.BanButton.Visibility == ViewStates.Gone && RequestSender.ThisAccount().Can((uint)WebApi.Classes.Permissions.BAN_ACCOUNTS))
                    viewHolder.BanButton.Visibility = ViewStates.Visible;
                else
                    viewHolder.BanButton.Visibility = ViewStates.Gone;

                if (viewHolder.DeleteButton.Visibility == ViewStates.Gone && RequestSender.ThisAccount().Can((uint)WebApi.Classes.Permissions.DELETE_COMMENTS))
                    viewHolder.DeleteButton.Visibility = ViewStates.Visible;
                else
                    viewHolder.DeleteButton.Visibility = ViewStates.Gone;
            };
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.comment_card, parent, false);
            return new CommentAdapterViewHolder(itemView);
        }

        private void ReloadComments(int pos)
        {
            this.NotifyItemRemoved(pos);
        }
    }
}