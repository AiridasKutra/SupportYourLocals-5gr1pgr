using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Classes;

namespace localhost.ActivityControllers.Recycler_adapters
{
    class AccountListAdapterHolder : RecyclerView.ViewHolder
    {
        public TextView UserName { get; set; }
        public TextView Activity { get; set; }
        public TextView Banned { get; set; }
        public AccountListAdapterHolder(View itemView):base(itemView)
        {
            UserName = itemView.FindViewById<TextView>(Resource.Id.usernameLabel);
            Activity = itemView.FindViewById<TextView>(Resource.Id.activeLabel);
            Banned = itemView.FindViewById<TextView>(Resource.Id.bannedLabel);
        }
    }

    class AccountListAdapter : RecyclerView.Adapter
    {
        private List<Account> list = new List<Account>();

        public AccountListAdapter(List<Account> list)
        {
            this.list = list;
        }

        public override int ItemCount => list.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            AccountListAdapterHolder viewHolder = holder as AccountListAdapterHolder;
            viewHolder.UserName.Text = list[position].Username;
            
            if (list[position].Can((uint)Permissions.BANNED)){
                viewHolder.Banned.Text = "Banned";
            }
            if (!list[position].Can((uint)Permissions.SEND_CHAT_MESSAGES))
            {
                viewHolder.Activity.Text = "Silenced";
            }

            viewHolder.ItemView.Click += (o, e) =>
            {
                AdminPanelActivity.WhichSelected = list[position].Id;
                AdminPanelActivity.accountLabel.Text = list[position].Username;
                AdminPanelActivity.WhichSilencedTitle = viewHolder.Activity;
                AdminPanelActivity.WhichBannedTitle = viewHolder.Banned;
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.user_card,parent,false);
            return new AccountListAdapterHolder(itemView);
        }
    }
}