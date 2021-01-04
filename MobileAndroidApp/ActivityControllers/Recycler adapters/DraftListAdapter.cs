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
using WebApi;
using localhost.Backend;

namespace localhost.ActivityControllers.Recycler_adapters
{
    class DraftViewHolder : RecyclerView.ViewHolder
    {
        public TextView EventName { get; set; }
        public ImageButton DeleteDraftButton { get; set; }

        public DraftViewHolder(View itemView) : base(itemView)
        {
            EventName = itemView.FindViewById<TextView>(Resource.Id.draftCardNameTextView);
            DeleteDraftButton = itemView.FindViewById<ImageButton>(Resource.Id.draftCardRemoveButton);
        }
    }

    class DraftListAdapter : RecyclerView.Adapter
    {
        public List<Event> draftList = new List<Event>();
        private List<DraftViewHolder> viewHolders = new List<DraftViewHolder>();

        public DraftListAdapter(List<Event> list)
        {
            this.draftList = list;
        }

        public override int ItemCount => draftList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DraftViewHolder viewHolder = holder as DraftViewHolder;
            Event draft = draftList[position];
            viewHolder.EventName.Text = draft.Name;
            viewHolder.DeleteDraftButton.Click += (o, e) =>
            {
                var dialog = new AlertDialog.Builder(viewHolder.ItemView.Context).Create();
                dialog.SetTitle("Delete this draft?");
                dialog.SetButton("Delete", (o, e) =>
                {
                    DraftManager.RemoveDraft(draftList[position].Id);
                    DraftManager.Save();
                    EventManagerActivity.Instance.LoadDrafts();
                });
                dialog.SetButton2("Cancel", (o, e) =>
                {
                    return;
                });
                dialog.Show();
            };

            if (!viewHolders.Contains(viewHolder))
            {
                viewHolder.ItemView.Click += (o, e) => {
                    EventEditorActivity.SetParams(draft, true);
                    viewHolder.ItemView.Context.StartActivity(typeof(EventEditorActivity));
                };
                viewHolders.Add(viewHolder);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.draft_card, parent, false);
            return new DraftViewHolder(itemView);
        }
    }
}