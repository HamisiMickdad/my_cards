using System;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using System.Threading.Tasks;
using Android.Support.V4.View;
using Android.Runtime;
using Android.Gms.Ads;

namespace my_cards
{
    [Activity(Label = "Best Predictions", MainLauncher = true,Theme = "@style/MyTheme", Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView mRecyclerView;
        SwipeRefreshLayout myswipeRefresh;
        FloatingActionButton myfab;
        AdView mAdView;
        InterstitialAd interstitialAds;
        // Layout manager that lays out each card in the RecyclerView:
        RecyclerView.LayoutManager mLayoutManager;

        // Adapter that accesses the data set (a photo album):
        PhotoAlbumAdapter mAdapter;

        // Photo album that is managed by the adapter:
        PhotoAlbum mPhotoAlbum;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Instantiate the photo album:
            mPhotoAlbum = new PhotoAlbum();

            // Set our view from the "main" layout resource:
            SetContentView(Resource.Layout.Main);
            interstitialAds = new InterstitialAd(this);
            mAdView = FindViewById<AdView>(Resource.Id.adView);
            var adRequest = new AdRequest.Builder().Build();
            mAdView.LoadAd(adRequest);

            interstitialAds.AdUnitId = "ca-app-pub-1120846610061033/5377390906";
            // loading test ad using adrequest
            interstitialAds.LoadAd(adRequest);

            interstitialAds.AdListener = new AdListener(this);


            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "TOP/BEST TIPSTARS";

            myfab = FindViewById<FloatingActionButton>(Resource.Id.fab);


            // Get our RecyclerView layout:
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            //............................................................
            // Layout Manager Setup:

            // Use the built-in linear layout manager:
            mLayoutManager = new LinearLayoutManager(this);


            // Or use the built-in grid layout manager (two horizontal rows):
            // mLayoutManager = new GridLayoutManager
            //        (this, 2, GridLayoutManager.Horizontal, false);

            // Plug the layout manager into the RecyclerView:
            mRecyclerView.SetLayoutManager(mLayoutManager);

            myswipeRefresh = FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            myswipeRefresh.SetColorScheme(Resource.Color.Red, Resource.Color.Orange,
                                                Resource.Color.Yellow, Resource.Color.Green,
                                                Resource.Color.Blue, Resource.Color.Indigo,
                                                Resource.Color.Violet);
            myswipeRefresh.Refresh += MyswipeRefresh_Refresh;

            //............................................................
            // Adapter Setup:

            // Create an adapter for the RecyclerView, and pass it the
            // data set (the photo album) to manage:
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);

            // Register the item click handler (below) with the adapter:
            mAdapter.ItemClick += OnItemClick;

            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(mAdapter);

            myfab.Click += async delegate (object sender, EventArgs e)
            {
                myswipeRefresh.Refreshing = true;
                await Task.Delay(5000);
                myswipeRefresh.Refreshing = false;
            };
        }
        class AdListener : Android.Gms.Ads.AdListener
        {
            MainActivity main;

            public AdListener(MainActivity innerMain)
            {
                main = innerMain;
            }

            public override void OnAdLoaded()
            {
                base.OnAdLoaded();
                main.interstitialAds.Show();
            }
        }
            Android.Support.V7.Widget.ShareActionProvider actionProvider;

        async void MyswipeRefresh_Refresh(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            (sender as SwipeRefreshLayout).Refreshing = false;
        }


        //public override bool OnCreateOptionsMenu(IMenu menu) {
        //    this.MenuInflater.Inflate(Resource.Menu.top_menus, menu);
        //    var shareItem = menu.FindItem(Resource.Id.menu_share);
        //    var provider = MenuItemCompat.GetActionProvider(shareItem);



        //   var intent = new Intent(Intent.ActionSend);
        //    intent.SetType("text/plain");
        //    intent.PutExtra(Intent.ExtraText, "https://play.google.com/store/apps/details?id=com.hamsempire.bestpredictions");

        //    StartActivity(Intent.CreateChooser(intent,"Share via....."));


        //    return base.OnCreateOptionsMenu(menu);
        //}
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Intent intent = null;
            switch (item.ItemId)
            {
                case
                    Resource.Id.menu_about:
                    intent = new Intent(this, typeof(About));
                    break;
                case
                    Resource.Id.menu_share:
                    intent = new Intent(Intent.ActionSend);
                    intent.SetType("text/plain");
                    intent.PutExtra(Intent.ExtraText, "https://play.google.com/store/apps/details?id=com.hamsempire.bestpredictions");

                   
                    break;
                case
                    Resource.Id.menu_shutdown:
                    //set alert for executing the task
                    Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
                    alert.SetTitle("Shutdown?");
                    alert.SetMessage("Do You Want To Shutdown The App?");
                    alert.SetPositiveButton("Yes", (senderAlert, args) => {
                        Java.Lang.JavaSystem.Exit(0);
                    });

                    alert.SetNegativeButton("No", (senderAlert, args) => {
                         Snackbar.Make(mRecyclerView, "Okay keep ejoying using HamSofts App", Snackbar.LengthShort)
                        .Show();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();
                    
                    break;
               
                default:
                    return base.OnOptionsItemSelected(item);
            }
            if (intent !=null)
            {
                StartActivity(intent);
            }
            return base.OnOptionsItemSelected(item);
           
        }
        public override void OnBackPressed()
        {
            //set alert for executing the task
            Android.Support.V7.App.AlertDialog.Builder alert = new Android.Support.V7.App.AlertDialog.Builder(this);
            alert.SetTitle("Shutdown?");
            alert.SetMessage("Do You Want To Shutdown The App?");
            alert.SetPositiveButton("Yes", (senderAlert, args) => {
                Java.Lang.JavaSystem.Exit(0);
            });

            alert.SetNegativeButton("No", (senderAlert, args) => {
                Snackbar.Make(mRecyclerView, "Okay keep ejoying using HamSofts App", Snackbar.LengthShort)
               .Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        // Handler for the item click event:
        void OnItemClick(object sender, int position)
        {
            Intent intent = null;
            int photoNum = position + 1;
            switch (photoNum)
            {
                case
                    1:
                    intent = new Intent(this, typeof(adibet));
                    break;
                case
                    2:
                    intent = new Intent(this, typeof(forebet));
                    break;
                case
                    3:
                    intent = new Intent(this, typeof(soccervista));
                    break;
                case
                    4:
                    intent = new Intent(this, typeof(windrawwin));
                    break;
                case
                    5:
                    intent = new Intent(this, typeof(zulubet));
                    break;
                case
                    6:
                    intent = new Intent(this, typeof(prosoccer));
                    break;
                case
                    7:
                    intent = new Intent(this, typeof(vitibet));
                    break;
                case
                    8:
                    intent = new Intent(this, typeof(betshoot));
                    break;
                case
                    9:
                    intent = new Intent(this, typeof(predictz));
                    break;
                case
                    10:
                    intent = new Intent(this, typeof(bestbet));
                    break;
                case
                    11:
                    intent = new Intent(this, typeof(betsexplained));
                    break;
                //default:
                    //int photoNum = position + 1;
                    //Snackbar.Make(mRecyclerView, "This is Series number : " + photoNum, Snackbar.LengthShort)
                    //.Show();

            }
            if(intent != null)
            {
                StartActivity(intent);
            }

            //var intent = new Intent(this, typeof(g_o_t));
            //intent.PutExtra("index", position = 1);
            //StartActivity(intent);
            // Display a toast that briefly shows the enumeration of the selected photo:
            //int photoNum = position + 1;
            //Snackbar.Make(mRecyclerView, "This is Series number : " + photoNum, Snackbar.LengthShort)
            //.Show();

        }
    }

    //----------------------------------------------------------------------
    // VIEW HOLDER

    // Implement the ViewHolder pattern: each ViewHolder holds references
    // to the UI components (ImageView and TextView) within the CardView 
    // that is displayed in a row of the RecyclerView:
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        // Get references to the views defined in the CardView layout.
        public PhotoViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);

            // Detect user clicks on the item view and report which item
            // was clicked (by position) to the listener:
            itemView.Click += (sender, e) => listener(base.Position);
        }
    }

    //----------------------------------------------------------------------
    // ADAPTER

    // Adapter to connect the data set (photo album) to the RecyclerView: 
    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        // Event handler for item clicks:
        public event EventHandler<int> ItemClick;

        // Underlying data set (a photo album):
        public PhotoAlbum mPhotoAlbum;

        // Load the adapter with the data set (photo album) at construction time:
        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }

        // Create a new photo CardView (invoked by the layout manager): 
        public override RecyclerView.ViewHolder
            OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.PhotoCardView, parent, false);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
            return vh;
        }

        // Fill in the contents of the photo card (invoked by the layout manager):
        public override void
            OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;

            // Set the ImageView and TextView in this ViewHolder's CardView 
            // from this position in the photo album:
            vh.Image.SetImageResource(mPhotoAlbum[position].PhotoID);
            vh.Caption.Text = mPhotoAlbum[position].Caption;
        }

        // Return the number of photos available in the photo album:
        public override int ItemCount
        {
            get { return mPhotoAlbum.NumPhotos; }
        }

        // Raise an event when the item-click takes place:
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }
}

