using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Provider;
using Android.Test.Suitebuilder;

namespace ir.XamarinPersian.ContactsAndCall
{
    [Activity(Label = "ContactsAndCall", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var btnCall = FindViewById<Button>(Resource.Id.buttonCall);
            btnCall.Click += BtnCall_Click;

            var contacts = GetContactsPhoneNumber();
            var listViewContact = FindViewById<ListView>(Resource.Id.listViewContacts);
            listViewContact.Adapter=new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1,contacts);
        }

        private List<string> GetContactsPhoneNumber()
        {
            var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
            string[] projection =
            {
                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Id,
                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.LookupKey,
                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.DisplayName,
                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.Starred,
                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.IsPrimary,
                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.HasPhoneNumber,
                ContactsContract.CommonDataKinds.Phone.Number,
                ContactsContract.CommonDataKinds.Phone.NormalizedNumber,
                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.PhotoUri,
            };
            var contactslist = new List<string>();

            var cursor = this.ContentResolver.Query(uri, projection, null, null, null);
            if (cursor.MoveToFirst())
            {
                do
                {
                    var name = cursor.GetString(2);
                    var number = cursor.GetString(6);
                    contactslist.Add(string.Format("{0} : {1}", name, number));
                } while (cursor.MoveToNext());
            }

            return contactslist;
        }

        private void BtnCall_Click(object sender, System.EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("tel:+989108802440");
            var intentCall = new Intent(Intent.ActionDial, uri);
            StartActivity(intentCall);
        }
    }
}

