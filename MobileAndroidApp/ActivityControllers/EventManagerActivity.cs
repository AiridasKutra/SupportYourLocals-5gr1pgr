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

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost", Theme = "@style/AppTheme")]
    public class EventManagerActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private Button addEventButton;

        private RecyclerView eventList;
        private RecyclerView.Adapter eventListAdapter;
        private RecyclerView.LayoutManager eventListLayout;

        private RecyclerView draftList;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.event_tabs);


            addEventButton = FindViewById<Button>(Resource.Id.addEventButton);
            eventList = FindViewById<RecyclerView>(Resource.Id.eventEditView);
            draftList = FindViewById<RecyclerView>(Resource.Id.draftView);
            
            //Navigation bar            
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);

            navigation.LayoutParameters.Width = ViewGroup.LayoutParams.FillParent;
            navigation.SetOnNavigationItemSelectedListener(this);



            list.Add(
                new EventData
                {
                    EventName = "Futbolas 5x5",
                    Activity = "Active",
                    DateTime = DateTime.Now
                }
                );
            list.Add(
                new EventData
                {
                    EventName = "Kašis kieme",
                    Activity = "Inactive",
                    DateTime = (DateTime.Now).AddDays(10).AddHours(5)
                }
                ); 
            list.Add(
                new EventData
                {
                    EventName = "Greitavaržis",
                    Activity = "Expired",
                    DateTime = (DateTime.Now).AddDays(5).AddHours(1.4)
                }
                );

            eventList.HasFixedSize = true;
            eventListLayout = new LinearLayoutManager(this);
            eventList.SetLayoutManager(eventListLayout);
            eventListAdapter = new EventListAdapter(list);
            eventList.SetAdapter(eventListAdapter);

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
                    addEventButton.Visibility = ViewStates.Visible;
                    eventList.Visibility = ViewStates.Visible;
                    addEventButton.Enabled = true;
                    draftList.Visibility = ViewStates.Gone;
                    return true;
                case Resource.Id.navigation_dashboard:
                    addEventButton.Visibility = ViewStates.Invisible;
                    addEventButton.Enabled = false;
                    eventList.Visibility = ViewStates.Gone;
                    draftList.Visibility = ViewStates.Visible;
                    return true;
            }
            return false;
        }

        private List<EventData> list = new List<EventData>();
    }
}