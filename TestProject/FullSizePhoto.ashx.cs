using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.App_Code;
using TestProject.Content;
using TestProject.GalleryServiceReference;

namespace TestProject
{
    /// <summary>
    /// Returns the Image in Full size 
    /// </summary>
    public class FullSizePhoto : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int photoID = Convert.ToInt32(context.Request.QueryString["PhotoID"]);
            int albumID = Convert.ToInt32(context.Request.QueryString["AlbumID"]);
            
            context.Response.Buffer = true;
            context.Response.StatusCode = 200;
            context.Response.Charset = "";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "image/jpg"; 
            context.Response.BinaryWrite(Provider.GetPhoto(photoID));
            context.Response.Flush();
            context.Response.End();
            
            
            

            //var ms = new MemoryStream();
            //ms.Write(imageFromDb, 0, imageFromDb.Length);
            //Bitmap bmp = new Bitmap(ms);
            //Image thumb = bmp.GetThumbnailImage(150, 150, null, new System.IntPtr());
            //bmp.Dispose();
            //var thumMs = new MemoryStream();
            //thumb.Save(thumMs, System.Drawing.Imaging.ImageFormat.Gif);
            //imageFromDb = thumMs.ToArray();
            //context.Response.OutputStream.Write(imageFromDb, 0, imageFromDb.Length);
            //context.Response.Flush();
            
            //byte[] imageFromDb = null;
            //string nam = context.Request.QueryString["SrNo"].ToString();
            //List<ThumbNail> mylist = (List<ThumbNail>)HttpContext.Current.Session["file"];
            //var byt = mylist.Where(item => item.PhotoID == nam).Select(item => item.thumb);
            //var enumerator = byt.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    imageFromDb = (byte[])enumerator.Current;
            //}
            //var ms = new MemoryStream();
            //ms.Write(imageFromDb, 0, imageFromDb.Length);
            //Bitmap bmp = new Bitmap(ms);
            //Image thumb = bmp.GetThumbnailImage(150, 150, null, new System.IntPtr());
            //bmp.Dispose();
            //var thumMs = new MemoryStream();
            //thumb.Save(thumMs, System.Drawing.Imaging.ImageFormat.Gif);
            //imageFromDb = thumMs.ToArray();
            //context.Response.OutputStream.Write(imageFromDb, 0, imageFromDb.Length);
            //context.Response.Flush();
            // context flush responece to the provider base 

        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}