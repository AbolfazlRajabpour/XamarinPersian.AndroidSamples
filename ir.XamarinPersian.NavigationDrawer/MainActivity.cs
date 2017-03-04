using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ir.XamarinPersian.NavigationDrawer
{
    [Activity(Label = "NavigationDrawer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //if (Window.DecorView.LayoutDirection == LayoutDirection.Ltr)
            //{
            //    Window.DecorView.LayoutDirection = LayoutDirection.Rtl;
            //}

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Hello from Xamarin-persian.ir";
            //SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            //SupportActionBar.SetHomeAsUpIndicator(Android.Resource.Drawable.IcMenuView);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.navigation_view);

            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);
                //react to click here and swap fragments or navigate
                drawerLayout.CloseDrawers();
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Layout.main_menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int itemId = item.ItemId;

            drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.End);
            //drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);

            string btnName = null;
            switch (itemId)
            {
                case Resource.Id.menu_settings:
                    btnName = "Settings";
                    break;
                case Resource.Id.menu_compass:
                    btnName = "Compass";
                    break;
                case Resource.Id.menu_help:
                    btnName = "Help";

                    break;
            }

            var linearLayout = FindViewById<LinearLayout>(Resource.Id.main_content);
            Snackbar.Make(linearLayout, "click " + btnName, Snackbar.LengthLong)
                .SetAction("ok", (view) => { /*Undo message sending here.*/ })
                .Show(); // Don’t forget to show!

            return base.OnOptionsItemSelected(item);
        }
    }
}

