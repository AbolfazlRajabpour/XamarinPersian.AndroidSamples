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

            var sendSMSViaBack = FindViewById<Button>(Resource.Id.buttonSendBack);
            sendSMSViaBack.Click += SendSMSViaBack_Click;

            var sendSmsViaInterface = FindViewById<Button>(Resource.Id.buttonSendViaIntent);
            sendSmsViaInterface.Click += SendSmsViaInterface_Click;
        }

        private void SendSmsViaInterface_Click(object sender, System.EventArgs e)
        {
            var smsUri = Android.Net.Uri.Parse("smsto:+989108802440");
            var smsIntent=new Intent(Intent.ActionSendto,smsUri);
            smsIntent.PutExtra("sms_body", "Welcome to Xamarin-persian.ir via Intent");
            StartActivity(smsIntent);
        }

        private void SendSMSViaBack_Click(object sender, System.EventArgs e)
        {
            var defaultSmsManager = Android.Telephony.SmsManager.Default;
            defaultSmsManager.SendTextMessage("+989108802440", null, "Welcome to Xamarin-persian.ir via Back", null, null);
        }
    }
}

