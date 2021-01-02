using System;
using System.Collections.Generic;
using System.Net;
using Android.Animation;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using GoogleMaps.LocationServices;
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
using WebApi;

namespace MobileAndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        private GoogleMap map;
        private static bool isFabOpen = false;
        private FloatingActionButton fabMain, fabEvents, fabAccount, fabSettings, fabLogin;
        private View bgFabMenu;
        private RelativeLayout bottomSheet;
        private Spinner sportSpinner;
        private EditText searchDates;
        private Button searchButton;
        private CoordinatorLayout mainPanel;

        private RecyclerView eventList;
        private RecyclerView.Adapter eventListAdapter;
        private RecyclerView.LayoutManager eventListLayout;

        private Bitmap eventPin;
        private List<Marker> eventMarkers = new List<Marker>();

        private List<EventDataImage> events = new List<EventDataImage>();

        public static bool IsLoggedIn { get; set; } = false;
        public static bool CanViewAccounts { get; set; } = true;

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

            bottomSheet = FindViewById<RelativeLayout>(Resource.Id.bottom_sheet);

            sportSpinner = FindViewById<Spinner>(Resource.Id.sportSpinner);
            searchDates = FindViewById<EditText>(Resource.Id.searchDate);
            searchButton = FindViewById<Button>(Resource.Id.searchButton);

            eventPin = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BasePin), 84, 124, true);

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

            var visibility = ViewStates.Visible;
            Console.WriteLine(visibility == ViewStates.Visible);
        }

        private void SetUpBottomSheet(int height)

        {
            // Set up bottom sheet
            BottomSheetBehavior bottomSheetBehavior = BottomSheetBehavior.From(bottomSheet);
            bottomSheetBehavior.PeekHeight = height;
            bottomSheetBehavior.SetBottomSheetCallback(new BSCallBack(bgFabMenu));

            // Fill sports list
            List<string> sportList = new List<string>();
            foreach (var sport in RequestSender.GetSports())
                sportList.Add(sport.Name);

            // Sport spinner
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, sportList);
            sportSpinner.Adapter = adapter;

            // Date picker
            searchDates.Focusable = false;
            searchDates.Click += (sender, e) => {
                DateTime today = DateTime.Today;
                DatePickerDialog dialog = new DatePickerDialog(this, OnStartDateSet, today.Year, today.Month, today.Day);
                dialog.DatePicker.MinDate = today.Millisecond;
                dialog.Show();
            };

            // Load events
            List<WebApi.Classes.Event> events = RequestSender.GetBriefEvents();
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
            RequestSender.Logout();
            Toast.MakeText(this, "Logged out", ToastLength.Short).Show();
            IsLoggedIn = false;
        }
        private void GoToActivity(Type a)
        {
            StartActivity(a);
        }
        private void CloseFabMenu()
        {
            ReloadMapEventMarkers();

            bottomSheet.Animate().TranslationY(0);
            
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

            bottomSheet.Animate().TranslationY(Resources.GetDimension(Resource.Dimension.hideSheet));
            isFabOpen = true;
            if (IsLoggedIn)
            {
                fabEvents.Visibility = ViewStates.Visible;
                fabSettings.Visibility = ViewStates.Visible;
                if (CanViewAccounts)
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
            if (map == null)
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
            ReloadMapEventMarkers();
        }
        public void ReloadMapEventMarkers()
        {
            // Clear markers
            foreach (var marker in eventMarkers)
            {
                marker.Remove();
            }
            eventMarkers.Clear();

            // Get events from API
            var events = RequestSender.GetBriefEvents();

            // Create markers
            foreach (var @event in events)
            {
                MarkerOptions marker = new MarkerOptions();
                marker.SetPosition(new LatLng(@event.Latitude, @event.Longitude));
                marker.SetTitle(@event.Name);
                marker.SetIcon(BitmapDescriptorFactory.FromBitmap(eventPin));
                var mark = map.AddMarker(marker);
                eventMarkers.Add(mark);
            }
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
        public class BSCallBack : BottomSheetBehavior.BottomSheetCallback
        {
            View backgroundTint;
            public BSCallBack(View bg)
            {
                this.backgroundTint = bg;
            }

            public override void OnSlide(View bottomSheet, float slideOffset)
            {
                backgroundTint.Visibility = ViewStates.Visible;
                if(slideOffset >= 0) backgroundTint.Alpha = slideOffset;
            }

            public override void OnStateChanged(View bottomSheet, int newState)
            {
                // on state changed
            }
        }
    }
}
