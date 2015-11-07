namespace TestProject
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing;
    using System.Web.Configuration;

    using Model;

    public class Provider
    {

        static ProviderList _Providers;
        static MyGalleryProvider _Provider;
        static bool _initialized = false;

        static void Initialize()
        {
            ProviderFeatureSection MyGalleryConfig = null;

            // don't initialize providers more than once
            if (!_initialized)
            {

                // get the configuration section for the feature
                MyGalleryConfig = (ProviderFeatureSection)ConfigurationManager.GetSection("myGallery");

                if (MyGalleryConfig == null)
                    throw new Exception("MyGallery is not configured for this application");

                _Providers = new ProviderList();

                // use the ProvidersHelper class to call Initialize on each 
                // configured provider
                ProvidersHelper.InstantiateProviders(MyGalleryConfig.Providers, _Providers, typeof(MyGalleryProvider));

                // set a reference to the default provider
                _Provider = _Providers[MyGalleryConfig.DefaultProvider];

                // set this feature as initialized
                _initialized = true;

            }
        }

        static Provider()
        {
            Initialize();
        }

        public static List<Photo> ShowAlbum(int albumID, string userName)
        {
            return _Provider.ShowAlbum(albumID,userName);
        }

        public static List<Photo> ShowPublicAlbum(int albumID)
        {
            return _Provider.ShowPublicAlbum(albumID);
        }

        public static List<Album> ShowGallery(string userName)
        {
            return _Provider.ShowGallery( userName);
        }

        public static List<Album> ShowOnlyPublic()
        {
            return _Provider.ShowOnlyPublic();
        }

        public static bool CreateAlbum(string album, string description, string userName)
        {
            return _Provider.CreateAlbum(album,description,userName);
        }

        public static byte[] GetPhoto(int photoID)
        {
            return _Provider.GetPhoto(photoID);
        }

        public static byte[] GetThumbnail(int albumID, int photoID)
        {
            return _Provider.GetThumbnail(albumID,photoID);
        }

        public static bool ImageUpload(Model.UploadImage imageDetails)
        {
            return _Provider.ImageUpload(imageDetails);
        }

        public static bool DeleteAlbum(int albumID)
        {
            return _Provider.DeleteAlbum(albumID);
        }

        public static bool DeletePhoto(int photoID)
        {
            return _Provider.DeletePhoto(photoID);
        }

        public static bool PublishAlbum(int albumID)
        {
            return _Provider.PublishAlbum(albumID);
        }

        public static bool UnPublishAlbum(int albumID)
        {
            return _Provider.UnPublishAlbum(albumID);
        }

        public static int ActivateAcc(string activationGuid)
        {
            return _Provider.ActivateAcc(activationGuid);
        }

        public static void GenerateAndInsertThumbnail(Photo photo, Size thumbSize)
        {
             _Provider.GenerateAndInsertThumbnail(photo, thumbSize);
        }

        public static List<Photo> PhotosWithoutThumb()
        {
            return _Provider.PhotosWithoutThumb();
        }
    }
}