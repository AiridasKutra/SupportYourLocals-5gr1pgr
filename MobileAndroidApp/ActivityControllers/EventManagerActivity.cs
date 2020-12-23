using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using localhost;
using MobileAndroidApp;

namespace localhost.ActivityControllers
{
    [Activity(Label = "Event manager")]
    public class EventManagerActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.event_manager);
        }
    }
}