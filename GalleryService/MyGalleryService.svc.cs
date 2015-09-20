using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TestProject.Content;
using TestProject.App_Code;
using System.ServiceModel.Activation;
using TestProject.App_Code.Interfaces;
using System.Security.Permissions;

namespace GalleryService
{
    /// <summary>
    /// Wcf service that works with Database
    /// </summary>
    
    [ServiceBehavior(Namespace = "", InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]//, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MyGalleryService : IMyGalleryProvider
    {
        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public List<Photo> ShowAlbum(int albumID, string userName)
        {
            return DBGateway.MyGalleryProviderSqlManager.ShowAlbum(albumID, userName);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public List<Photo> ShowPublicAlbum(int albumID)
        {
            return DBGateway.MyGalleryProviderSqlManager.ShowPublicAlbum(albumID);
                 
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public List<Model.Album> ShowGallery(string userName)
        {
            return DBGateway.MyGalleryProviderSqlManager.ShowGallery(userName);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public List<Model.Album> ShowOnlyPublic()
        {
            return DBGateway.MyGalleryProviderSqlManager.ShowOnlyPublic();
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public bool CreateAlbum(string album, string description, string userName)
        {
            return DBGateway.MyGalleryProviderSqlManager.CreateAlbum(album, description, userName);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public byte[] GetPhoto(int photoID)
        {
            return DBGateway.MyGalleryProviderSqlManager.GetPhoto(photoID);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public byte[] GetThumbnail(int albumID, int photoID)
        {
            return DBGateway.MyGalleryProviderSqlManager.GetThumbnail(albumID, photoID);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public bool ImageUpload(Model.UploadImage imageToUpload)
        {
            return DBGateway.MyGalleryProviderSqlManager.ImageUpload(imageToUpload);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public bool DeleteAlbum(int albumID)
        {
            return DBGateway.MyGalleryProviderSqlManager.DeleteAlbum(albumID);

        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public bool DeletePhoto(int photoID)
        {
            return DBGateway.MyGalleryProviderSqlManager.DeletePhoto(photoID);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public bool PublishAlbum(int albumID)
        {
            return DBGateway.MyGalleryProviderSqlManager.PublishAlbum(albumID);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public bool UnPublishAlbum(int albumID)
        {
            return DBGateway.MyGalleryProviderSqlManager.UnPublishAlbum(albumID);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]

        public int ActivateAcc(string activationCode)
        {
            return DBGateway.MyGalleryProviderSqlManager.ActivateAcc(activationCode);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public void GenerateAndInsertThumbnail(Photo photo, System.Drawing.Size thumbSize)
        {
             DBGateway.MyGalleryProviderSqlManager.GenerateAndInsertThumbnail(photo, thumbSize);
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true)]
        public List<Photo> PhotosWithoutThumb()
        {
           return  DBGateway.MyGalleryProviderSqlManager.PhotosWithoutThumb();
        }
    }
}

