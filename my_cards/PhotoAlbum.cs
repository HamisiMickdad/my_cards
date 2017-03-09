using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using System.Collections.Generic;


namespace my_cards
{
    // Photo: contains image resource ID and caption:
    public class Photo
    {
        // Photo ID for this photo:
        public int mPhotoID;

        // Caption text for this photo:
        public string mCaption;

        // Return the ID of the photo:
        public int PhotoID
        {
            get { return mPhotoID; }
        }

        // Return the Caption of the photo:
        public string Caption
        {
            get { return mCaption; }
        }
    }

    public class PhotoAlbum
    {
        static Photo[] mBuiltInPhotos = {

             new Photo { mPhotoID = Resource.Drawable.ic_adibet,
                        mCaption = "Adi Bet Predictions" },
            new Photo { mPhotoID = Resource.Drawable.ic_forebet,
                        mCaption = "Forebet Predictions" },
             new Photo { mPhotoID = Resource.Drawable.ic_soccervista,
                        mCaption = "Soccer Vista Predictions" },
             new Photo { mPhotoID = Resource.Drawable.ic_windrawwin,
                        mCaption = "WinDrawWin Predictions" },
              new Photo { mPhotoID = Resource.Drawable.ic_zulubet,
                        mCaption = "Zulu Bet Predictions" },
               new Photo { mPhotoID = Resource.Drawable.ic_prosoccer,
                        mCaption = "Pro Soccer Predictions" },

                new Photo { mPhotoID = Resource.Drawable.ic_vitibet,
                        mCaption = "Viti Bet Predictions" },
                new Photo { mPhotoID = Resource.Drawable.ic_betshoot,
                        mCaption = "Bet Shoot Predictions" },
                 new Photo { mPhotoID = Resource.Drawable.ic_predictz,
                        mCaption = "Predictz Predictions" },
                  new Photo { mPhotoID = Resource.Drawable.ic_bestbettips,
                        mCaption = "Best Bet Tips Predictions" },
                  new Photo { mPhotoID = Resource.Drawable.ic_betsexplained,
                        mCaption = "Betting & live betting Tutorials" },
            };
        // Array of photos that make up the album:
        private Photo[] mPhotos;

        public PhotoAlbum()
        {
            mPhotos = mBuiltInPhotos;
        }

        // Return the number of photos in the photo album:
        public int NumPhotos
        {
            get { return mPhotos.Length; }
        }

        // Indexer (read only) for accessing a photo:
        public Photo this[int i]
        {
            get { return mPhotos[i]; }
        }

    }
}