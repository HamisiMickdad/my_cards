
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using AndroidAboutPage;
using System;

namespace my_cards
{
    [Activity(Label = "About", Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class About : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        Element adsElement = new Element();
            adsElement.Title = "About US";
            View aboutPage = new AboutPage(this)
                .IsRTL(false)
                .SetImage(Resource.Drawable.splash_logo)
                .SetDescription("Here Is How To Contact The Dev Team")
                .AddItem(new Element() { Title = "Version 0.1" })
                .AddItem(adsElement)
                .AddGroup("Connect With Us")
                .AddEmail("hamisimickdad@gmail.com")
                .AddWebsite("http://lifeasy.azurewebsites.net")
                .AddFacebook("Hamisi Mickdad")
                .AddTwitter("@hmickdad")
                .AddYoutube("Hamisi Mickdad")
                .AddPlayStore("My Play")
                .AddInstagram("hmickdad")
                .AddGitHub("HamisiMickdad")
                .AddItem(CreateCopyright())
                .Create();

            SetContentView(aboutPage);

        }
        
        private Element CreateCopyright ()
        {
            Element copyright = new Element();
            string copyrightString = $"Copyright {DateTime.Now.Year} by HamSoft";
            copyright.Title = copyrightString;
            copyright.Icon = Resource.Drawable.ic_copyright;
            return copyright;
        }
    }
    }
