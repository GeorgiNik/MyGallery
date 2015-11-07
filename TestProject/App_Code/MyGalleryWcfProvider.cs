namespace TestProject
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    using Model;

    using TestProject.Service_References.GalleryServiceReference;

    public class MyGalleryWcfProvider:MyGalleryProvider
    {

        MyGalleryProviderClient client;

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
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.ShowAlbum(albumID, userName).ToList();
            }
        }

        public override List<Photo> ShowPublicAlbum(int albumID)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.ShowPublicAlbum(albumID).ToList();
            }
        }

        public override List<Album> ShowGallery(string userName)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.ShowGallery(userName).ToList();
            }
        }

        public override List<Album> ShowOnlyPublic()
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.ShowOnlyPublic().ToList();
            }
        }

        public override bool CreateAlbum(string album, string description, string userName)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.CreateAlbum(album, description, userName);
            }
        }

        public override byte[] GetPhoto(int photoID)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.GetPhoto(photoID);
            }
        }

        public override byte[] GetThumbnail(int albumID, int photoID)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.GetThumbnail(albumID, photoID);
            }
        }

        public override bool ImageUpload(Model.UploadImage imageDetails)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.ImageUpload(imageDetails);
            }
        }

        public override bool DeleteAlbum(int albumID)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.DeleteAlbum(albumID);
            }
        }

        public override bool DeletePhoto(int photoID)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.DeletePhoto(photoID);
            }
        }

        public override bool PublishAlbum(int albumID)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.PublishAlbum(albumID);
            }
        }

        public override bool UnPublishAlbum(int albumID)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.UnPublishAlbum(albumID);
            }
        }

        public override int ActivateAcc(string activationGuid)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.ActivateAcc(activationGuid);
            }
        }



        public override void GenerateAndInsertThumbnail(Photo photo, Size thumbSize)
        {
            using (this.client = new MyGalleryProviderClient())
            {
                this.client.GenerateAndInsertThumbnail(photo, thumbSize);
            }
        }



        public override List<Photo> PhotosWithoutThumb()
        {
            using (this.client = new MyGalleryProviderClient())
            {
                return this.client.PhotosWithoutThumb().ToList();
            }
        } 
        #endregion

        
    }
}