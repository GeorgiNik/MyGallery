using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Ionic.Zip;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections.Generic;
using Model;
using TestProject.App_Code.Interfaces;
using TestProject.App_Code;

namespace TestProject.Content
{
    /// <summary>
    /// Provider class which works with sql database
    /// </summary>
    public class MyGalleryProviderSql : MyGalleryProvider
    {

        #region Instance
        private static MyGalleryProviderSql _Instance;

        /// <summary>
        /// The single instance of the class
        /// </summary>
        public static MyGalleryProviderSql Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MyGalleryProviderSql();
                }

                return _Instance;
            }
        }
        #endregion

        #region Public Metods

        public override List<Photo> ShowAlbum(int albumID, string userName)
        {
            List<Photo> result = new List<Photo>();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand cmd = new SqlCommand("Album");
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@albumID", albumID);
            cmd.Parameters.AddWithValue("@username", userName);
            SqlConnection cn = new SqlConnection(strConnString);
            cmd.Connection = cn;
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            sda.Dispose();
            cn.Close();
            using (dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Photo photo = new Photo();
                    photo.AlbumID = (int)row["AlbumID"];
                    photo.Description = (string)row["Description"];
                    photo.Name = (string)row["Name"];
                    photo.PhotoID = (int)row["PhotoID"];
                    result.Add(photo);
                }
            }
            return result;

        }

        public override List<Photo> ShowPublicAlbum(int albumID)
        {
            List<Photo> result = new List<Photo>();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand cmd = new SqlCommand("PublicAlbum");
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@albumID", albumID);

            SqlConnection cn = new SqlConnection(strConnString);
            cmd.Connection = cn;
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            sda.Dispose();
            cn.Close();
            using (dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Photo photo = new Photo();
                    photo.AlbumID = (int)row["AlbumID"];
                    photo.Description = (string)row["Description"];
                    photo.Name = (string)row["Name"];
                    photo.PhotoID = (int)row["PhotoID"];


                    result.Add(photo);
                }
            }
            return result;


        }

        public override List<Model.Album> ShowGallery(string userName)
        {
            var result = new List<Model.Album>();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand cmd = new SqlCommand("Gallery");
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", userName);
            SqlConnection cn = new SqlConnection(strConnString);
            cmd.Connection = cn;
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            sda.Dispose();
            cn.Close();
            using (dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var album = new Model.Album();
                    album.AlbumName = (string)row["AlbumName"];
                    album.AlbumID = (int)row["AlbumID"];
                    album.Description = (string)row["Description"];
                    album.IsPublished = (bool)row["IsPublished"];
                    album.UserName = (string)row["UserName"];


                    result.Add(album);
                }
            }
            return result;
        }

        public override List<Model.Album> ShowOnlyPublic()
        {
            var result = new List<Model.Album>();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand cmd = new SqlCommand("PublicOnly");
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@published", true);
            SqlConnection cn = new SqlConnection(strConnString);
            cmd.Connection = cn;
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            sda.Dispose();
            cn.Close();

            foreach (DataRow row in dt.Rows)
            {
                var album = new Model.Album();
                album.AlbumName = (string)row["AlbumName"];
                album.AlbumID = (int)row["AlbumID"];
                album.Description = (string)row["Description"];
                album.IsPublished = (bool)row["IsPublished"];
                album.UserName = (string)row["UserName"];


                result.Add(album);
            }

            return result;
        }

        public override bool CreateAlbum(string album, string description, string userName)
        {

            SqlCommand cmd = new SqlCommand("CreateAlbum");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AlbumName", SqlDbType.VarChar).Value = album;
            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@DateCreated", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@public", false);
            cmd.Parameters.AddWithValue("@UserName", userName);
            if (InsertUpdateData(cmd))
            {
                return true;
            }
            else return false;
        }

        public override byte[] GetPhoto(int photoID)
        {
            Byte[] bytes = null;
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;

            SqlCommand cmd = new SqlCommand("SelectPhoto");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", photoID);
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();

            DataTable dt = new DataTable();
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;

                sda.Fill(dt);
                if (dt != null)
                {
                    bytes = (Byte[])dt.Rows[0]["Photo"];


                }

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
                dt = null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();

            }
            return bytes;

        }

        //public  byte[] GetPhotoByte(int albumID, int photoID)
        //{
        //    Byte[] bytes = null;



        //    string strQuery = "select Photo from Photos where AlbumID=@id";
        //    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
        //    SqlCommand cmd = new SqlCommand(strQuery);
        //    cmd.Parameters.Add("@id", SqlDbType.Int).Value = photoID;
        //    SqlConnection con = new SqlConnection(strConnString);
        //    SqlDataAdapter sda = new SqlDataAdapter();
        //    cmd.CommandType = CommandType.Text;
        //    DataTable dt = new DataTable();
        //    cmd.Connection = con;

        //    try
        //    {
        //        con.Open();
        //        sda.SelectCommand = cmd;

        //        sda.Fill(dt);
        //        if (dt != null)
        //        {
        //            bytes = (Byte[])dt.Rows[0]["Photo"];

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        dt = null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        sda.Dispose();
        //        con.Dispose();
        //    }



        //    return bytes;
        //}

        public override byte[] GetThumbnail(int albumID, int photoID)
        {
            Byte[] bytes = null;




            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand cmd = new SqlCommand("GetThumbnail");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = photoID;
            cmd.Parameters.AddWithValue("@albumID", albumID);
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cmd.Connection = con;

            try
            {
                con.Open();
                sda.SelectCommand = cmd;

                sda.Fill(dt);
                if (dt != null)
                {
                    bytes = (Byte[])dt.Rows[0]["Thumbnail"];


                }

            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
                dt = null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }



            return bytes;
        }

        public override bool ImageUpload(Model.UploadImage imageDetails)
        {
            bool IsUploaded = false;
            imageDetails.ext = imageDetails.ext.ToLower();
            switch (imageDetails.ext)
            {
                case ".jpeg":
                    imageDetails.contenttype = "image/jpeg";
                    break;

                case ".jpg":
                    imageDetails.contenttype = "image/jpg";
                    break;
                case ".png":
                    imageDetails.contenttype = "image/png";
                    break;
                case ".gif":
                    imageDetails.contenttype = "image/gif";
                    break;

            }
            if (imageDetails.contenttype != String.Empty)
            {

                SqlCommand cmd = new SqlCommand("UplodImage");
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AlbumID", SqlDbType.Int).Value = imageDetails.albumID;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = imageDetails.filename;
                cmd.Parameters.AddWithValue("@Description", imageDetails.imageDescrp);
                cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = imageDetails.contenttype;
                cmd.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = imageDetails.image;
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@username", imageDetails.userName);
                #region
                //byte[] thumbnail = null;
                //var ms = new MemoryStream();
                //ms.Write(bytes, 0, bytes.Length);
                //Bitmap bmp = new Bitmap(ms);

                //Image thumb = bmp.GetThumbnailImage( 200,200,null, new System.IntPtr());
                //bmp.Dispose();
                //var thumMs = new MemoryStream();

                //thumb.Save(thumMs, System.Drawing.Imaging.ImageFormat.Bmp);
                //thumbnail = thumMs.ToArray();
                //cmd.Parameters.Add("@Thumbnail", SqlDbType.VarBinary).Value = thumbnail;
                #endregion

                InsertUpdateData(cmd);

                IsUploaded = true;

            }
            return IsUploaded;

        }

        public override bool DeleteAlbum(int albumID)
        {
            bool isDeleted = false;
            SqlCommand cmd = new SqlCommand("DeleteAlbum");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = albumID;
            if (InsertUpdateData(cmd))
            {
                isDeleted = true;
            }
            return isDeleted;

        }

        public override bool DeletePhoto(int photoID)
        {
            bool isDeleted = false;
            SqlCommand cmd = new SqlCommand("DeletePhoto");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = photoID;
            if (InsertUpdateData(cmd))
            {
                isDeleted = true;
            }
            return isDeleted;
        }

        public override bool PublishAlbum(int albumID)
        {
            bool isPublished = false;
            SqlCommand cmd = new SqlCommand("PublishAlbum");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@publish", true);
            cmd.Parameters.AddWithValue("@id", albumID);
            if (InsertUpdateData(cmd))
            {
                isPublished = true;
            }
            return isPublished;

        }

        public override bool UnPublishAlbum(int albumID)
        {
            bool isPublished = false;
            SqlCommand cmd = new SqlCommand("UnPublishAlbum");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@publish", false);
            cmd.Parameters.AddWithValue("@id", albumID);
            if (InsertUpdateData(cmd))
            {
                isPublished = false;
            }
            return isPublished;
        }

        private bool InsertUpdateData(SqlCommand cmd)
        {
            String strConnString = System.Configuration.ConfigurationManager
            .ConnectionStrings["Sql"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);

            cmd.Connection = con;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex);
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public override int ActivateAcc(string activationGuid)
        {
            string constr = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM UserActivation WHERE ActivationCode = @ActivationCode"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ActivationCode", activationGuid);
                        cmd.Connection = con;
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        return rowsAffected;
                    }
                }
            }
        }

        public override void GenerateAndInsertThumbnail(Photo photo, Size thumbSize)
        {

            Byte[] bytes = photo.PhotoByte;



            SqlCommand cmd = new SqlCommand("InserThumbanil");
            cmd.CommandType = CommandType.StoredProcedure;


            byte[] thumbnail = null;
            var ms = new MemoryStream();
            ms.Write(bytes, 0, bytes.Length);
            Bitmap bmp = new Bitmap(ms);

            Image thumb = bmp.GetThumbnailImage(thumbSize.Width, thumbSize.Height, null, new System.IntPtr());
            bmp.Dispose();
            var thumMs = new MemoryStream();

            thumb.Save(thumMs, System.Drawing.Imaging.ImageFormat.Bmp);
            thumbnail = thumMs.ToArray();
            cmd.Parameters.Add("@Thumbnail", SqlDbType.VarBinary).Value = thumbnail;
            cmd.Parameters.AddWithValue("@PhotoID", photo.PhotoID);

            InsertUpdateData(cmd);




        }

        public override List<Photo> PhotosWithoutThumb()
        {
            var imagesToResize = new List<Photo>();
            string strConnString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand cmd = new SqlCommand("GetPhotosWithoutThumb");
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;

            SqlConnection cn = new SqlConnection(strConnString);
            cmd.Connection = cn;
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            sda.Dispose();
            cn.Close();


            foreach (DataRow row in dt.Rows)
            {
                var photo = new Photo();
                photo.PhotoByte = (byte[])row["Photo"];
                photo.PhotoID = (int)row["PhotoID"];
                imagesToResize.Add(photo);
            }
            dt.Dispose();

            return imagesToResize;
        } 
        #endregion

    }

}


//public  Stream DownloadAlbum(HttpContext context)
//{
//    int photoID = Convert.ToInt32(context.Request.QueryString["PhotoID"]);
//    int albumID = Convert.ToInt32(context.Request.QueryString["AlbumID"]);

//    string strQuery = "select Photo,Name from Photos where PhotoID=@id and AlbumID=@albumID";
//    string MyGalleryProviderSql = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;

//    String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
//    SqlCommand cmd = new SqlCommand(strQuery);
//    //SqlCommand cmd = new SqlCommand("SelectPhoto");
//    cmd.CommandType = CommandType.Text;
//    cmd.Parameters.AddWithValue("@id", photoID);
//    cmd.Parameters.AddWithValue("@albumID", albumID);
//    SqlConnection con = new SqlConnection(strConnString);
//    SqlDataAdapter sda = new SqlDataAdapter();

//    DataTable dt = new DataTable();
//    cmd.Connection = con;
//    try
//    {
//        con.Open();
//        sda.SelectCommand = cmd;

//        sda.Fill(dt);
//        using (ZipFile zip = new ZipFile())
//        {
//            zip.AlternateEncodingUsage = ZipOption.AsNecessary;
//            zip.AddDirectoryByName("Photos");
//            foreach (DataTable row in dt.Rows)
//            {

//                Byte[] bytes = (Byte[])row;
//                string name=dt.row
//                MemoryStream ms = new MemoryStream(bytes);
//                Image bigImage = Image.FromStream(ms);
//                zip.AddEntry(;


//            }
//            context.Response.Clear();
//            context.Response.BufferOutput = false;
//            string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
//            context.Response.ContentType = "application/zip";
//            context.Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
//            zip.Save(context.Response.OutputStream);
//            context.Response.End();
//        }
//    }
//}