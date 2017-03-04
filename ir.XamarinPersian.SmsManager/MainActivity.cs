using Android.App;
using Android.Content;
using Android.Net;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace ir.XamarinPersian.SmsManager
{
    [Activity(Label = "ir.XamarinPersian.SmsManager", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

        }

       
    }
}

