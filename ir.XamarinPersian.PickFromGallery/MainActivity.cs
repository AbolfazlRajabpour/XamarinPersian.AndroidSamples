using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace ir.XamarinPersian.PickFromGallery
{
    [Activity(Label = "PickFromGallery", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        public static readonly int PickImageId = 1000;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var imageButton = FindViewById<Button>(Resource.Id.buttonSelectGallery);
            imageButton.Click += ImageButton_Click;

        }

        private void ImageButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select From Gallery"), PickImageId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                var image = FindViewById<ImageView>(Resource.Id.imageViewGallery);
                Android.Net.Uri uri = data.Data;
                image.SetImageURI(uri);
            }
        }
    }
}

