using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Drawing;

namespace TestProject.App_Code
{
    public class MyGalleryWcfProvider:MyGalleryProvider
    {

        GalleryServiceReference.MyGalleryProviderClient client;

        private static MyGalleryWcfProvider _Instance;

        /// <summary>
        /// The single instance of the class
        /// </summary>
        public static MyGalleryWcfProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MyGalleryWcfProvider();
                }

                return _Instance;
            }
        }

        #region Public Metods
        public override List<Photo> ShowAlbum(int albumID, string userName)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.ShowAlbum(albumID, userName).ToList();
            }
        }

        public override List<Photo> ShowPublicAlbum(int albumID)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.ShowPublicAlbum(albumID).ToList();
            }
        }

        public override List<Album> ShowGallery(string userName)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.ShowGallery(userName).ToList();
            }
        }

        public override List<Album> ShowOnlyPublic()
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.ShowOnlyPublic().ToList();
            }
        }

        public override bool CreateAlbum(string album, string description, string userName)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.CreateAlbum(album, description, userName);
            }
        }

        public override byte[] GetPhoto(int photoID)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.GetPhoto(photoID);
            }
        }

        public override byte[] GetThumbnail(int albumID, int photoID)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.GetThumbnail(albumID, photoID);
            }
        }

        public override bool ImageUpload(Model.UploadImage imageDetails)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.ImageUpload(imageDetails);
            }
        }

        public override bool DeleteAlbum(int albumID)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.DeleteAlbum(albumID);
            }
        }

        public override bool DeletePhoto(int photoID)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.DeletePhoto(photoID);
            }
        }

        public override bool PublishAlbum(int albumID)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.PublishAlbum(albumID);
            }
        }

        public override bool UnPublishAlbum(int albumID)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.UnPublishAlbum(albumID);
            }
        }

        public override int ActivateAcc(string activationGuid)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.ActivateAcc(activationGuid);
            }
        }



        public override void GenerateAndInsertThumbnail(Photo photo, Size thumbSize)
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                client.GenerateAndInsertThumbnail(photo, thumbSize);
            }
        }



        public override List<Photo> PhotosWithoutThumb()
        {
            using (client = new GalleryServiceReference.MyGalleryProviderClient())
            {
                return client.PhotosWithoutThumb().ToList();
            }
        } 
        #endregion

        
    }
}