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
            new Photo { mPhotoID = Resource.Drawable.cd_arrow,
                        mCaption = "Arrow ->Thriller" },
             new Photo { mPhotoID = Resource.Drawable.cd_dv,
                        mCaption = "Davinci Deamons ->Midevil" },
             new Photo { mPhotoID = Resource.Drawable.cd_flash,
                        mCaption = "The Flash ->SciFi" },
              new Photo { mPhotoID = Resource.Drawable.cd_got1,
                        mCaption = "Missandei -> Game of Thrones" },
               new Photo { mPhotoID = Resource.Drawable.cd_got2,
                        mCaption = "Game Of Thrones -> Khaleese" },
                new Photo { mPhotoID = Resource.Drawable.cd_hg1,
                        mCaption = "Hunger Games -> That One" },
                new Photo { mPhotoID = Resource.Drawable.cd_hg2,
                        mCaption = "Hunger Games -> Another One" },
                new Photo { mPhotoID = Resource.Drawable.cd_thor,
                        mCaption = "Thor -> The Dark World" },
                 new Photo { mPhotoID = Resource.Drawable.cd_vd,
                        mCaption = "Vampire Dairies -> Nina Dobrev" },
                  new Photo { mPhotoID = Resource.Drawable.cd_viking,
                        mCaption = "Viking -> NorthMen" },
                  new Photo { mPhotoID = Resource.Drawable.cd_xmen,
                        mCaption = "XMEN -> Days of The Future Past" },
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