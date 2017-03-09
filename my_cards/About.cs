
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using AndroidAboutPage;
using System;
//using Toolbar = Android.Support.V7.Widget.Toolbar;


namespace my_cards
{
    [Activity(Label = "About", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class About : AppCompatActivity
    {
        //LinearLayout mLinearLayout;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetContentView(Resource.Layout.about_page);
            //var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            //Toolbar will now take on default actionbar characteristics
            //SetSupportActionBar(toolbar);
            //SupportActionBar.Title = "ABOUT US";
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            //SupportActionBar.SetHomeButtonEnabled(true);
            //mLinearLayout = FindViewById<LinearLayout>(Resource.Id.aboutview);

            Element adsElement = new Element();
            adsElement.Title = "About US";
            View aboutPage = new AboutPage(this)
                .IsRTL(false)
                .SetImage(Resource.Drawable.splash_logo)
                .SetDescription("Here Is How To Contact The Dev Team")
                .AddItem(new Element() { Title = "Version 1.01" })
                .AddItem(adsElement)
                .AddGroup("Connect With Us")
                .AddEmail("hamisimickdad@gmail.com")
                .AddWebsite("http://hamsempirewindows.blogspot.com/2015/12/one-drive-bad-image-error-quick-fix.html")
                .AddFacebook("Hamsen Charles")
                .AddTwitter("Check out Hamisi Mickey (@hmickdad): https://twitter.com/hmickdad?s=09")
                .AddYoutube("UCUFuF-JxEaklT1StIBFMLEA")
                .AddPlayStore("com.hamsempire.bestpredictions")
                .AddInstagram("hmickdad")
                .AddGitHub("HamisiMickdad")
                .AddItem(CreateCopyright())
                .Create();


            //mLinearLayout.AddView(aboutView, 1);

            SetContentView(aboutPage);



        }

        private Element CreateCopyright()
        {
            Element copyright = new Element();
            string copyrightString = $"Copyright {DateTime.Now.Year} by HamSoft";
            copyright.Title = copyrightString;
            copyright.Icon = Resource.Drawable.copyright;
            return copyright;
        }
        //public override bool OnOptionsItemSelected(IMenuItem item)
        //{
        //    if (item.ItemId == Android.Resource.Id.Home)
        //        Finish();

        //    return base.OnOptionsItemSelected(item);
        //}

    }
}
