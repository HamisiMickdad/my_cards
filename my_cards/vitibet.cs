using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Webkit;
using Android.Graphics;
using Android.Support.V4.Widget;
using System;
using Android.Gms.Ads;

namespace my_cards
{
    [Activity(Label = "vitibet")]
    public class vitibet : forebet
    {
        private WebView myWebView;
        private WebClient myWebClient;
        private ProgressBar myProgressBar;
        private SwipeRefreshLayout myswipeRefreshLayout;
        AdView mAdView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.adiBet);
            mAdView = FindViewById<AdView>(Resource.Id.adView);
            var adRequest = new AdRequest.Builder().Build();
            mAdView.LoadAd(adRequest);

            myWebClient = new WebClient();
            myWebClient.myOnProgressChanged += (int state) =>
            {
                if (state == 0)
                {
                    //(sender as SwipeRefreshLayout).Refreshing = false;
                    myswipeRefreshLayout.Refreshing = false;

                    //page loaded no progress bar visible
                    //myProgressBar.Visibility = ViewStates.Invisible;
                }
                else
                {
                    //(sender as SwipeRefreshLayout).Refreshing = true;
                    myswipeRefreshLayout.Refreshing = true;
                    //myProgressBar.Visibility = ViewStates.Visible;
                }
            };







            myWebView = FindViewById<WebView>(Resource.Id.webView);
            myProgressBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            myswipeRefreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            myswipeRefreshLayout.SetColorScheme(Resource.Color.Red, Resource.Color.Orange,
                                                 Resource.Color.Yellow, Resource.Color.Green,
                                                 Resource.Color.Blue, Resource.Color.Indigo,
                                                 Resource.Color.Violet);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            myWebView.Settings.JavaScriptEnabled = true;
            myWebView.Settings.DisplayZoomControls = true;
            myWebView.Settings.BuiltInZoomControls = true;
            myWebView.LoadUrl("http://www.vitibet.com");
            myWebView.SetWebViewClient(myWebClient);



            //Toolbar will now take on default actionbar characteristics
            SetSupportActionBar(toolbar);

            SupportActionBar.Title = "VITIBET PREDICTIONS";

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            myWebView.SetWebViewClient(myWebClient);
            myswipeRefreshLayout.Refresh += MyswipeRefreshLayout_Refresh;


        }

        private void MyswipeRefreshLayout_Refresh(object sender, EventArgs e)
        {
            myWebView.LoadUrl(myWebView.Url);
        }


        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && myWebView.CanGoBack())
            {
                myWebView.GoBack();
                return true;
            }

            return base.OnKeyDown(keyCode, e);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();

            return base.OnOptionsItemSelected(item);
        }
    }

}

