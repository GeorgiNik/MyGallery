using Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Drawing;
using System.Web.Configuration;
using TestProject.App_Code.Interfaces;

namespace TestProject.App_Code
{
    public abstract class MyGalleryProvider : System.Configuration.Provider.ProviderBase, IMyGalleryProvider
    {
        public abstract List<Photo> ShowAlbum(int albumID, string userName);
        public abstract List<Photo> ShowPublicAlbum(int albumID);
        public abstract List<Album> ShowGallery(string userName);
        public abstract List<Album> ShowOnlyPublic();
        public abstract bool CreateAlbum(string album, string description, string userName);
        public abstract byte[] GetPhoto(int photoID);
        public abstract byte[] GetThumbnail(int albumID, int photoID);
        public abstract bool ImageUpload(Model.UploadImage imageDetails);
        public abstract bool DeleteAlbum(int albumID);
        public abstract bool DeletePhoto(int photoID);
        public abstract bool PublishAlbum(int albumID);
        public abstract bool UnPublishAlbum(int albumID);
        public abstract int ActivateAcc(string activationGuid);
        public abstract void GenerateAndInsertThumbnail(Photo photo, Size thumbSize);
        public abstract List<Photo> PhotosWithoutThumb();
        
    }
}