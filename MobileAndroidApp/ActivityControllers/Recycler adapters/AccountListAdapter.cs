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
        public ImageView SilencedIcon { get; set; }
        public ImageView BannedIcon { get; set; }
        public AccountListAdapterHolder(View itemView):base(itemView)
        {
            UserName = itemView.FindViewById<TextView>(Resource.Id.usernameLabel);
            SilencedIcon = itemView.FindViewById<ImageView>(Resource.Id.accountCardSilencedIcon);
            BannedIcon = itemView.FindViewById<ImageView>(Resource.Id.accountCardBannedIcon);
        }
    }

    class AccountListAdapter : RecyclerView.Adapter
    {
        private List<Account> list = new List<Account>();
        private List<AccountListAdapterHolder> viewHolders = new List<AccountListAdapterHolder>();

        public AccountListAdapter(List<Account> list)
        {
            this.list = list;
        }

        public void SetData(List<Account> data)
        {
            list = data;
        }

        public override int ItemCount => list.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            AccountListAdapterHolder viewHolder = holder as AccountListAdapterHolder;
            viewHolder.UserName.Text = list[position].Username;

            if (!list[position].Can((uint)Permissions.SEND_CHAT_MESSAGES))
            {
                viewHolder.SilencedIcon.Visibility = ViewStates.Visible;
            }
            if (list[position].Can((uint)Permissions.BANNED)){
                viewHolder.BannedIcon.Visibility = ViewStates.Visible;
            }

            if (!viewHolders.Contains(viewHolder))
            {
                viewHolder.ItemView.Click += (o, e) =>
                {
                    AdminPanelActivity.WhichSelected = list[position].Id;
                    AdminPanelActivity.accountLabel.Text = list[position].Username;
                    AdminPanelActivity.WhichSilencedIcon = viewHolder.SilencedIcon;
                    AdminPanelActivity.WhichBannedIcon = viewHolder.BannedIcon;
                };
                viewHolders.Add(viewHolder);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.user_card,parent,false);
            return new AccountListAdapterHolder(itemView);
        }
    }
}