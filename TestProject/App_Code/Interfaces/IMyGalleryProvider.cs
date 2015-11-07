namespace TestProject.Interfaces
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.ServiceModel;

    using Model;

    /// <summary>
    /// The main interface for Providers
    /// </summary>
    [ServiceContract]
    public interface IMyGalleryProvider
    {
        [OperationContract]
        List<Photo> ShowAlbum(int albumID, string userName);
        [OperationContract]
        List<Photo> ShowPublicAlbum(int albumID);
        [OperationContract]
        List<Model.Album> ShowGallery(string userName);
        [OperationContract]
        List<Model.Album> ShowOnlyPublic();
        [OperationContract]
        bool CreateAlbum(string album, string description, string userName);
        [OperationContract]
        byte[] GetPhoto(int photoID);
        [OperationContract]
        byte[] GetThumbnail(int albumID, int photoID);
        [OperationContract]
        bool ImageUpload(Model.UploadImage imageToUpload);
        [OperationContract]
        bool DeleteAlbum(int albumID);
        [OperationContract]
        bool DeletePhoto(int photoID);
        [OperationContract]
        bool PublishAlbum(int albumID);
        [OperationContract]
        bool UnPublishAlbum(int albumID);
        [OperationContract]
        int ActivateAcc(string activationCode);
        [OperationContract]
        void GenerateAndInsertThumbnail(Photo photo, Size thumbSize);
        [OperationContract]
        List<Photo> PhotosWithoutThumb();
    }
}
