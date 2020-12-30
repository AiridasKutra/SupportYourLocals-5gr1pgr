using System;
using System.Collections.Generic;
using System.Net;
using Android.Animation;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using localhost;
using localhost.ActivityControllers;
using localhost.ActivityControllers.Recycler_adapters;
using localhost.ActivityControllers.Recycler_helpers;

namespace MobileAndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        private GoogleMap map;
        private static bool isFabOpen = false;
        private FloatingActionButton fabMain, fabEvents, fabAccount, fabSettings, fabLogin;
        private View bgFabMenu;
        private LinearLayout sheet;
        private Spinner sportSpinner;
        private EditText searchDates;
        private Button searchButton;
        private CoordinatorLayout mainPanel;

        private RecyclerView eventList;
        private RecyclerView.Adapter eventListAdapter;
        private RecyclerView.LayoutManager eventListLayout;

        private List<EventDataImage> events = new List<EventDataImage>();

        public static bool IsLoggedIn { get; set; } = false;
        private bool isAdmin = true;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            mainPanel = FindViewById<CoordinatorLayout>(Resource.Id.mainPanel);

            fabMain = FindViewById<FloatingActionButton>(Resource.Id.fab_main);
            fabEvents = FindViewById<FloatingActionButton>(Resource.Id.fab_events);
            fabAccount = FindViewById<FloatingActionButton>(Resource.Id.fab_account_manager);
            fabSettings = FindViewById<FloatingActionButton>(Resource.Id.fab_settings);
            fabLogin = FindViewById<FloatingActionButton>(Resource.Id.fab_login);
            bgFabMenu = FindViewById<View>(Resource.Id.bg_fab_menu);

            EventLayout = FindViewById<LinearLayout>(Resource.Id.EventLayout);

            sheet = FindViewById<LinearLayout>(Resource.Id.bottom_sheet);
            sportSpinner = FindViewById<Spinner>(Resource.Id.sportSpinner);
            searchDates = FindViewById<EditText>(Resource.Id.searchDate);
            searchButton = FindViewById<Button>(Resource.Id.searchButton);

            eventList = FindViewById<RecyclerView>(Resource.Id.PulloutEventView);

            SetUpBottomSheet(210);
            SetUpMap();

            fabMain.Click += (o, e) =>
             {
                 if (!isFabOpen) ShowFabMenu();
                 else CloseFabMenu();
             };

            bgFabMenu.Click += (o, e) => CloseFabMenu();

            fabEvents.Click += (o, e) => GoToActivity(typeof(EventManagerActivity));
            fabSettings.Click += (o, e) => GoToActivity(typeof(SettingsActivity));
            fabAccount.Click += (o, e) => GoToActivity(typeof(AdminPanelActivity));
            fabLogin.Click += (o, e) => LogIn();

            searchDates.Focusable = false;
            searchDates.Click += (sender, e) => {
                DateTime today = DateTime.Today;
                DatePickerDialog dialog = new DatePickerDialog(this, OnStartDateSet, today.Year, today.Month, today.Day);
                dialog.DatePicker.MinDate = today.Millisecond;
                dialog.Show();
            };

            var visibility = ViewStates.Visible;
            Console.WriteLine(visibility == ViewStates.Visible);
        }

        private void SetUpBottomSheet(int height)

        {
            // Set up bottom sheet
            BottomSheetBehavior bottomSheetBehavior = BottomSheetBehavior.From(sheet);
            bottomSheetBehavior.PeekHeight = height;
            //bottomSheetBehavior.Hideable = true;

            // Fill sports list
            List<string> sportList = new List<string>();
            sportList.Add("Basketball");
            sportList.Add("Football");
            sportList.Add("Volleyball");

            // Sport spinner
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, sportList);
            sportSpinner.Adapter = adapter;

            // Load up events
            events.Add(
                new EventDataImage
                {
                    thumbnail = BitmapFactory.DecodeResource(Resources, Resource.Drawable.event1),
                    name = "vaxinacija",
                    description = "Badabing badaboom",
                    dateTime = (DateTime.Now).AddDays(1).AddHours(8)
                }
            ); ;
            events.Add(
                new EventDataImage
                {
                    thumbnail = BitmapFactory.DecodeResource(Resources, Resource.Drawable.event2),
                    name = "roskosmos",
                    description = "WHEEEEEEEEHWOOOWOH",
                    dateTime = (DateTime.Now).AddDays(7).AddHours(4)
                }
            );
            events.Add(
                new EventDataImage
                {
                    thumbnail = BitmapFactory.DecodeResource(Resources, Resource.Drawable.event3),
                    name = "Lyrical genius",
                    description = "Yuh, ooh, brr, brr Gucci gang, ooh (That's it right there, Gnealz) Yuh, Lil Pump, yuh Gucci gang, ooh (Ooh, Bi - Bighead on the beat) Yuh, br",
                    dateTime = (DateTime.Now).AddDays(11).AddHours(1)
                }
            );

            // Load events
            eventList.HasFixedSize = true;
            eventListLayout = new LinearLayoutManager(this);
            eventList.SetLayoutManager(eventListLayout);
            eventListAdapter = new PulloutEventAdapter(events);
            eventList.SetAdapter(eventListAdapter);
        }
        private void LogIn()
        {
            CloseFabMenu();
            if(!IsLoggedIn) GoToActivity(typeof(LoginActivity));
            else LogOut();
        }
        private void LogOut()
        {
            Toast.MakeText(this, "Logged out", ToastLength.Short).Show();
            IsLoggedIn = false;
        }
        private void GoToActivity(Type a)
        {
            StartActivity(a);
        }
        private void CloseFabMenu()
        {
            sheet.Animate().TranslationY(0);
            
            isFabOpen = false;
            fabMain.Animate().Rotation(0f);
            bgFabMenu.Animate().Alpha(0f);
            fabEvents.Animate()
                .TranslationY(0)
                .Rotation(90f);
            fabAccount.Animate()
                .TranslationY(0)
                .Rotation(90f);
            fabSettings.Animate()
                .TranslationY(0)
                .Rotation(90f);
            fabLogin.Animate()
                .TranslationY(0)
                .Rotation(90f).SetListener(new FabAnimatorListener(bgFabMenu,fabEvents,fabAccount,fabSettings,fabLogin));
        }
        private class FabAnimatorListener : Java.Lang.Object, Animator.IAnimatorListener
        {
            View[] viewsToHide;
            public FabAnimatorListener(params View[] viewsToHide)
            {
                this.viewsToHide = viewsToHide;
            }
            public void OnAnimationCancel(Animator animation)
            {

            }

            public void OnAnimationEnd(Animator animation)
            {
                if (!isFabOpen)
                {
                    foreach(var view in viewsToHide)
                    {
                        view.Visibility = ViewStates.Gone;
                    }
                }
            }

            public void OnAnimationRepeat(Animator animation)
            {

            }

            public void OnAnimationStart(Animator animation)
            {

            }
        }

        private void ShowFabMenu() { 

            sheet.Animate().TranslationY(Resources.GetDimension(Resource.Dimension.hideSheet));
            isFabOpen = true;
            if (IsLoggedIn)
            {
                fabEvents.Visibility = ViewStates.Visible;
                fabSettings.Visibility = ViewStates.Visible;
                if (isAdmin)
                {
                    fabAccount.Visibility = ViewStates.Visible;
                }
            }
            fabLogin.Visibility = ViewStates.Visible;
            bgFabMenu.Visibility = ViewStates.Visible;

            fabMain.Animate().Rotation(-90f);
            bgFabMenu.Animate().Alpha(1f);
            

            fabAccount.Animate()
                .TranslationY(Resources.GetDimension(Resource.Dimension.standart_170))
                .Rotation(0f);
            fabEvents.Animate()
                .TranslationY(Resources.GetDimension(Resource.Dimension.standart_130))
                .Rotation(0f);
            fabSettings.Animate()
                .TranslationY(Resources.GetDimension(Resource.Dimension.standart_90))
                .Rotation(0f);
            fabLogin.Animate()
                .TranslationY(Resources.GetDimension(Resource.Dimension.standart_50))
                .Rotation(0f);
        }
        private void SetUpMap()
        {
            if(map == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;

            // Set location focus
            LatLng location = new LatLng(54.729730, 25.263571);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);
            builder.Bearing(155);
            builder.Tilt(65);

            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            map.MoveCamera(cameraUpdate);

            // Set a marker
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(54.729729, 25.263571));
            marker.SetTitle("MIF'as");

            map.AddMarker(marker);
        }
        private void OnStartDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            searchDates.Text = e.Date.ToShortDateString();
            DateTime startDate = e.Date;
            DatePickerDialog dialog = new DatePickerDialog(this, OnEndDateSet, startDate.Year, startDate.Month, startDate.Day + 1);
            dialog.DatePicker.MinDate = startDate.Millisecond;
            dialog.Show();
        }
        private void OnEndDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            searchDates.Text += " - " + e.Date.ToShortDateString();
        }
    }
}
