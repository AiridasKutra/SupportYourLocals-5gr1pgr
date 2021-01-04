using System;
using System.Collections.Generic;
using Android.Animation;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using localhost;
using localhost.ActivityControllers;
using localhost.ActivityControllers.Recycler_adapters;
using WebApi;
using Android.Content;
using localhost.Backend;
using WebApi.Classes;
using localhost.ActivityControllers.PinClick;
using Android.Locations;
using localhost.Backend.Location;
using Android.Runtime;
using System.Linq;
using Java.Interop;

namespace MobileAndroidApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback, ILocationListener
    {
        private static GoogleMap map;
        private static bool isFabOpen = false;
        private static FloatingActionButton fabMain, fabEvents, fabAccount, fabSettings, fabLogin;
        private  View bgFabMenu;
        private  RelativeLayout bottomSheet;
        private AutoCompleteTextView sportInput;
        private EditText searchDates;
        private DateTime lowerDate;
        private DateTime upperDate;
        private SeekBar maxPriceSlider;
        private SeekBar maxDistanceSlider;
        private TextView selectedPrice;
        private TextView selectedDistance;
        private EditText searchInput;
        private Button searchButton;
        private CoordinatorLayout mainPanel;


        private RecyclerView eventListView;
        private PulloutEventAdapter eventListAdapter;
        private RecyclerView.LayoutManager eventListLayout;

        private Button filtersButton;
        private LinearLayout filterView;
        private List<Event> eventList;

        private static Bitmap eventPin;
        private static Bitmap locationPin;
        private static List<Marker> eventMarkers = new List<Marker>();

        public static double currentLatitude;
        public static double currentLongitude;
        private LocationManager locationManager;

        public static MainActivity thisReference;
        public static bool IsLoggedIn { get; set; } = false;
        public static bool CanViewAccounts { get; set; } = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            thisReference = this;

            SetContentView(Resource.Layout.activity_main);

            mainPanel = FindViewById<CoordinatorLayout>(Resource.Id.mainPanel);

            fabMain = FindViewById<FloatingActionButton>(Resource.Id.fab_main);
            fabEvents = FindViewById<FloatingActionButton>(Resource.Id.fab_events);
            fabAccount = FindViewById<FloatingActionButton>(Resource.Id.fab_account_manager);
            fabSettings = FindViewById<FloatingActionButton>(Resource.Id.fab_settings);
            fabLogin = FindViewById<FloatingActionButton>(Resource.Id.fab_login);
            bgFabMenu = FindViewById<View>(Resource.Id.bg_fab_menu);

            filtersButton = FindViewById<Button>(Resource.Id.filtersButton);
            filtersButton.Click += ShowFilters;
            filterView = FindViewById<LinearLayout>(Resource.Id.filtersView);
            eventList = new List<Event>();

            bottomSheet = FindViewById<RelativeLayout>(Resource.Id.bottom_sheet);

            sportInput = FindViewById<AutoCompleteTextView>(Resource.Id.sportTextEdit);
            searchDates = FindViewById<EditText>(Resource.Id.searchDate);
            maxPriceSlider = FindViewById<SeekBar>(Resource.Id.maxPrice);
            maxPriceSlider.SetProgress(1000, true);
            maxDistanceSlider = FindViewById<SeekBar>(Resource.Id.maxDist);
            maxDistanceSlider.SetProgress(0, false);
            selectedPrice = FindViewById<TextView>(Resource.Id.lblSelectedPrice);
            selectedDistance = FindViewById<TextView>(Resource.Id.lblSelectedDist);
            searchInput = FindViewById<EditText>(Resource.Id.enterKeyword);
            searchButton = FindViewById<Button>(Resource.Id.searchButton);
            searchButton.Click += SearchClick;
            maxPriceSlider.ProgressChanged += (o, e) =>
            {
                selectedPrice.Text = $"{e.Progress / 10.0m:0.00}€";
            };
            maxDistanceSlider.ProgressChanged += (o, e) =>
            {
                double distance = e.Progress * 100.0;
                if (distance < 1000.0)
                {
                    selectedDistance.Text = $"{distance:0}m";
                }
                else
                {
                    selectedDistance.Text = $"{distance / 1000.0:0.0}km";
                }
            };

            eventPin = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BasePin), 84, 124, true);
            locationPin = Bitmap.CreateScaledBitmap(BitmapFactory.DecodeResource(Resources, Resource.Drawable.LocationPin), 64, 64, true);

            eventListView = FindViewById<RecyclerView>(Resource.Id.PulloutEventView);

            locationManager = (LocationManager)GetSystemService(Context.LocationService);
            locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 400, 1, this);

            SetUpMap();

            fabMain.Click += (o, e) =>
            {
                if (!isFabOpen) ShowFabMenu();
                else CloseFabMenu();
            };

            bgFabMenu.Click += (o, e) => CloseFabMenu();

            fabEvents.Click += (o, e) => GoToActivity(typeof(EventManagerActivity));
            fabSettings.Click += (o, e) =>
            {
                Intent intent = new Intent(this, typeof(SettingsActivity));
                StartActivityForResult(intent, 1);
            };
            fabAccount.Click += (o, e) => GoToActivity(typeof(AdminPanelActivity));
            fabLogin.Click += (o, e) => LogIn();


            // Try auto login
            string email = Xamarin.Essentials.Preferences.Get("saved_email", "");
            string passwordHash = Xamarin.Essentials.Preferences.Get("saved_password", "");
            if (email != "" || passwordHash != "")
            {
                if (email != "" && passwordHash != "")
                {
                    VFIDHolder.Value = RequestSender.Login(email, passwordHash);
                    if (VFIDHolder.Value > 0)
                    {
                        int id = RequestSender.GetLoggedInAccountId();
                        Account acc = new Account { Permissions = RequestSender.GetAccountPermissions(id) };
                        if (acc.Can((uint)Permissions.VIEW_ACCOUNTS))
                        {
                            CanViewAccounts = true;
                        }
                        IsLoggedIn = true;

                        Toast.MakeText(this, "Logged in", ToastLength.Long).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "Auto sign in failed", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Auto sign in failed", ToastLength.Long).Show();
                }
            }
            else
            {
                Xamarin.Essentials.Preferences.Set("saved_email", "");
                Xamarin.Essentials.Preferences.Set("saved_password", "");
            }

            SetUpBottomSheet(210);
            AskForLocationAsync();
            DraftManager.Load();
        }
        private void ShowFilters(object o, EventArgs e)
        {
            if(filterView.Visibility == ViewStates.Visible)
            {
                filterView.Animate().Alpha(0f);
                filterView.Visibility = ViewStates.Gone;
                filtersButton.Background = GetDrawable(Resource.Drawable.filter);
            }
            else
            {
                filterView.Visibility = ViewStates.Visible;
                filterView.Animate().Alpha(1f);
                filtersButton.Background = GetDrawable(Resource.Drawable.filter_off);
            }
        }

        private void SearchClick(object o, EventArgs e)
        {
            FilterAndSearchEvents();
            eventListAdapter.dataList = eventList;
            eventListAdapter.NotifyDataSetChanged();
        }

        private void FilterAndSearchEvents()
        {
            string sport = sportInput.Text;
            decimal maxPrice = maxPriceSlider.Progress / 10.0m;
            double maxDistance = maxDistanceSlider.Progress * 100.0;
            string[] keywords = searchInput.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Event> allEvents = RequestSender.GetBriefEvents();
            List<Event> filteredEvents = new List<Event>();
            List<int> scores = new List<int>();
            foreach (var @event in allEvents)
            {
                string evSport = @event.Sports.FirstOrDefault();

                if (filterView.Visibility == ViewStates.Visible)
                {
                    if (evSport == null) continue;
                    if (sport.Length > 0) if (!evSport.Contains(sport)) continue;
                    if (@event.StartDate < lowerDate) continue;
                    if (@event.StartDate > upperDate) continue;
                    if (@event.Price > maxPrice) continue;
                    if (maxDistance > 0)
                    {
                        double distance = MathSupplement.Distance(@event.Latitude, @event.Longitude, currentLatitude, currentLongitude);
                        if (distance > maxDistance)
                        {
                            continue;
                        }
                    }
                }

                int score = 0;
                if (keywords.Length > 0)
                {
                    foreach (var keyword in keywords)
                    {
                        foreach (var word in @event.Name.Split())
                        {
                            if (word.Contains(keyword))
                            {
                                score += 100;
                            }
                        }
                        if (evSport != null)
                        {
                            foreach (var word in evSport.Split())
                            {
                                if (word.Contains(keyword))
                                {
                                    score += 500;
                                }
                            }
                        }
                        foreach (var word in @event.Tags.Split())
                        {
                            if (word.Contains(keyword))
                            {
                                score += 200;
                            }
                        }
                        foreach (var word in @event.Address.ToStringNormal().Split())
                        {
                            if (word.Contains(keyword))
                            {
                                score += 200;
                            }
                        }
                    }
                    if (score == 0) continue;
                }

                scores.Add(score);
                filteredEvents.Add(@event);
            }

            if (keywords.Length > 0)
            {
                // Sort by score
                Event[] eventArray = filteredEvents.ToArray();
                int[] scoreArray = scores.ToArray();
                Array.Sort(scoreArray, eventArray);
                eventList = eventArray.ToList();
                scores = scoreArray.ToList();
                eventList.Reverse();
                scores.Reverse();
            }
            else
            {
                for (int i = 0; i < filteredEvents.Count - 1; i++)
                {
                    for (int j = i; j < filteredEvents.Count; j++)
                    {
                        if (filteredEvents[i].StartDate > filteredEvents[j].StartDate)
                        {
                            Event temp = filteredEvents[i];
                            filteredEvents[i] = filteredEvents[j];
                            filteredEvents[j] = temp;
                        }
                    }
                }
                eventList = filteredEvents;
            }
        }

        private void SetUpBottomSheet(int height)
        {
            // Set up bottom sheet
            BottomSheetBehavior bottomSheetBehavior = BottomSheetBehavior.From(bottomSheet);
            bottomSheetBehavior.PeekHeight = height;
            bottomSheetBehavior.SetBottomSheetCallback(new BSCallBack(bgFabMenu));

            // Add sport selections
            var sportList = RequestSender.GetSports().Select(item => item.Name).ToArray();
            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, sportList);
            sportInput.Adapter = adapter;

            // Date picker
            lowerDate = DateTime.Today.AddDays(-7);
            upperDate = DateTime.Today.AddMonths(1);
            searchDates.Text = $"{lowerDate:yyyy-MM-dd} to {upperDate:yyyy-MM-dd}";
            searchDates.Focusable = false;
            searchDates.Click += (sender, e) => {
                DateTime today = DateTime.Today;
                DatePickerDialog dialog = new DatePickerDialog(this, OnStartDateSet, today.Year, today.Month, today.Day);
                dialog.Show();
            };

            // Load events
            FilterAndSearchEvents();
            eventListView.HasFixedSize = true;
            eventListLayout = new LinearLayoutManager(this);
            eventListView.SetLayoutManager(eventListLayout);
            eventListAdapter = new PulloutEventAdapter(eventList);
            eventListView.SetAdapter(eventListAdapter);
            eventListView.SetItemViewCacheSize(0);
        }
        private void LogIn()
        {
            CloseFabMenu();
            if (!IsLoggedIn) GoToActivity(typeof(LoginActivity));
            else LogOut();
        }
        private void LogOut()
        {
            RequestSender.Logout();
            Xamarin.Essentials.Preferences.Set("saved_email", "");
            Xamarin.Essentials.Preferences.Set("saved_password", "");
            Toast.MakeText(this, "Logged out", ToastLength.Short).Show();
            IsLoggedIn = false;
        }
        private void GoToActivity(Type a)
        {
            StartActivity(a);
        }
        private void CloseFabMenu()
        {
            if (BottomSheetBehavior.From(bottomSheet).State != BottomSheetBehavior.StateExpanded)
            {
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
                    .Rotation(90f).SetListener(new FabAnimatorListener(bgFabMenu, fabEvents, fabAccount, fabSettings, fabLogin));
            }

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
                    foreach (var view in viewsToHide)
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



            LatLng location = new LatLng(currentLatitude, currentLongitude);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);
            builder.Bearing(155);
            builder.Tilt(65);


            
            MarkerOptions marker = new MarkerOptions();
            marker.SetPosition(new LatLng(currentLatitude, currentLongitude));
            marker.SetIcon(BitmapDescriptorFactory.FromBitmap(locationPin));
            marker.Flat(true);
            marker.Anchor(0.5f, 0.5f);
            map.AddMarker(marker);



            CameraPosition cameraPosition = builder.Build();
            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

            map.MoveCamera(cameraUpdate);

            // Set a marker
            ReloadMapEventMarkers();
        }

        protected override void OnResume()
        {
            base.OnResume();
            //locationManager.RemoveUpdates(this);
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
                mark.ZIndex = @event.Id;

               
                eventMarkers.Add(mark);
            }
            map.SetOnMarkerClickListener(new MarkerListener(this));
        }
        private void OnStartDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            searchDates.Text = e.Date.ToString("yyyy-MM-dd");
            lowerDate = e.Date;
            DatePickerDialog dialog = new DatePickerDialog(this, OnEndDateSet, e.Date.Year, e.Date.Month, e.Date.Day + 1);
            dialog.Show();
        }
        private void OnEndDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            searchDates.Text += " to " + e.Date.ToString("yyyy-MM-dd");
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
                if (slideOffset >= 0)
                {
                    fabMain.Visibility = ViewStates.Visible;
                    backgroundTint.Alpha = slideOffset;
                    fabMain.Alpha = 1 - slideOffset;
                    return;
                }

                if (slideOffset == 1)
                {
                    fabMain.Visibility = ViewStates.Gone;
                    return;
                }
            }

            public override void OnStateChanged(View bottomSheet, int newState)
            {
                //on state change
            }
        }
        private async System.Threading.Tasks.Task AskForLocationAsync()
        {
            await Xamarin.Essentials.Permissions.RequestAsync<Xamarin.Essentials.Permissions.LocationWhenInUse>();
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok || resultCode.Equals(Result.Ok))
            {
                CloseFabMenu();
            }
            ReloadMapEventMarkers();
        }

        public void OnLocationChanged(Location location)
        {
            currentLatitude = location.Latitude;
            currentLongitude = location.Longitude;
        }

        public void OnProviderDisabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            //throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            //throw new NotImplementedException();
        }
    }
}
