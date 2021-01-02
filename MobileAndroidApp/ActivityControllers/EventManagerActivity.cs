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

        private RecyclerView eventListView;
        private RecyclerView draftListView;
        private RecyclerView.Adapter eventListAdapter;
        private RecyclerView.LayoutManager eventListLayout;

        private List<Event> eventList = new List<Event>();
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.event_tabs);


            addEventButton = FindViewById<Button>(Resource.Id.addEventButton);
            eventListView = FindViewById<RecyclerView>(Resource.Id.eventEditView);
            draftListView = FindViewById<RecyclerView>(Resource.Id.draftView);
            
            //Navigation bar            
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);

            navigation.LayoutParameters.Width = ViewGroup.LayoutParams.FillParent;
            navigation.SetOnNavigationItemSelectedListener(this);

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

            eventListView.HasFixedSize = true;
            eventListView.AddItemDecoration(new DividerItemDecoration(this, DividerItemDecoration.Vertical));
            eventListLayout = new LinearLayoutManager(this);
            eventListView.SetLayoutManager(eventListLayout);
            eventListAdapter = new EventListAdapter(eventList);
            eventListView.SetAdapter(eventListAdapter);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    eventListView.Visibility = ViewStates.Visible;
                    draftListView.Visibility = ViewStates.Gone;
                    return true;
                case Resource.Id.navigation_dashboard:
                    eventListView.Visibility = ViewStates.Gone;
                    draftListView.Visibility = ViewStates.Visible;
                    return true;
            }
            return false;
        }

        
    }
}