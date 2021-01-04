using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using localhost.ActivityControllers.Recycler_adapters;
using localhost.ActivityControllers.Recycler_helpers;
using localhost.Backend;
using MobileAndroidApp;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi;
using WebApi.Classes;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost", Theme = "@style/AppTheme")]
    public class EventManagerActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private Button addEventButton;
        private TextView noEventsText;
        private TextView noDraftsText;

        private RecyclerView eventListView;
        private RecyclerView draftListView;
        private EventListAdapter eventListAdapter;
        private RecyclerView.LayoutManager eventListLayout;
        private DraftListAdapter draftListAdapter;
        private RecyclerView.LayoutManager draftListLayout;

        private List<Event> eventList = new List<Event>();
        private List<Event> draftList = new List<Event>();

        public static EventManagerActivity Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            EventEditorActivity.SetManagerReference(this);
            Instance = this;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.event_tabs);


            addEventButton = FindViewById<Button>(Resource.Id.addEventButton);
            noEventsText = FindViewById<TextView>(Resource.Id.eventManagerNoEventsText);
            noDraftsText = FindViewById<TextView>(Resource.Id.eventManagerNoDraftsText);
            eventListView = FindViewById<RecyclerView>(Resource.Id.eventEditView);
            draftListView = FindViewById<RecyclerView>(Resource.Id.draftView);

            addEventButton.Click += CreateNewEvent;
            
            //Navigation bar            
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.LayoutParameters.Width = ViewGroup.LayoutParams.FillParent;
            navigation.SetOnNavigationItemSelectedListener(this);

            eventListView.HasFixedSize = true;
            eventListView.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));
            eventListLayout = new LinearLayoutManager(this);
            eventListView.SetLayoutManager(eventListLayout);
            eventListAdapter = new EventListAdapter(eventList);
            eventListView.SetAdapter(eventListAdapter);

            draftListView.HasFixedSize = true;
            draftListView.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));
            draftListLayout = new LinearLayoutManager(this);
            draftListView.SetLayoutManager(draftListLayout);
            draftListAdapter = new DraftListAdapter(draftList);
            draftListView.SetAdapter(draftListAdapter);

            LoadEvents();
            LoadDrafts();

            noEventsText.Visibility = ViewStates.Gone;
            noDraftsText.Visibility = ViewStates.Gone;
            if (eventList.Count == 0) noEventsText.Visibility = ViewStates.Visible;
        }

        public void LoadEvents()
        {
            List<Event> fullEventList = RequestSender.GetBriefEvents();
            var accounts = RequestSender.GetAccounts();
            if (RequestSender.ThisAccount().Can((uint)Permissions.EDIT_OTHER_EVENTS))
            {
                eventList = fullEventList;
            }
            else
            {
                eventList = fullEventList.Where(item => item.Author == RequestSender.GetLoggedInAccountId()).ToList();
            }
            eventListAdapter.eventList = eventList;
            eventListAdapter.NotifyDataSetChanged();
        }

        public void LoadDrafts()
        {
            draftList = DraftManager.GetDrafts();
            draftListAdapter.draftList = draftList;
            draftListAdapter.NotifyDataSetChanged();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            noEventsText.Visibility = ViewStates.Gone;
            noDraftsText.Visibility = ViewStates.Gone;

            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    eventListView.Visibility = ViewStates.Visible;
                    draftListView.Visibility = ViewStates.Gone;
                    LoadEvents();
                    if (eventList.Count == 0) noEventsText.Visibility = ViewStates.Visible;
                    return true;
                case Resource.Id.navigation_dashboard:
                    eventListView.Visibility = ViewStates.Gone;
                    draftListView.Visibility = ViewStates.Visible;
                    LoadDrafts();
                    if (draftList.Count == 0) noDraftsText.Visibility = ViewStates.Visible;
                    return true;
            }
            return false;
        }

        public void CreateNewEvent(object o, EventArgs e)
        {
            EventEditorActivity.SetParams(null, false);
            StartActivity(typeof(EventEditorActivity));
        }

        protected override void OnResume()
        {
            base.OnResume();
            LoadEvents();
            LoadDrafts();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            MainActivity.thisReference.ReloadMapEventMarkers();
        }

        protected override void OnPause()
        {
            base.OnPause();
            MainActivity.thisReference.ReloadMapEventMarkers();
        }

        protected override void OnStop()
        {
            base.OnStop();
            MainActivity.thisReference.ReloadMapEventMarkers();
        }
    }
}