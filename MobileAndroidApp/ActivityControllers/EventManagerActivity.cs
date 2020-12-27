using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using localhost;
using MobileAndroidApp;

namespace localhost.ActivityControllers
{
    [Activity(Label = "localhost", Theme = "@style/AppTheme")]
    public class EventManagerActivity : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private Button addEventButton;
        private CardView eventList;
        private CardView draftList;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.event_tabs);
            addEventButton = FindViewById<Button>(Resource.Id.addEventButton);
            eventList = FindViewById<CardView>(Resource.Id.eventEditView);
            draftList = FindViewById<CardView>(Resource.Id.draftView);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.LayoutParameters.Width = ViewGroup.LayoutParams.FillParent;
            navigation.SetOnNavigationItemSelectedListener(this);
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
    }
}