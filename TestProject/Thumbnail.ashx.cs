using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.App_Code;
using TestProject.Content;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TestProject
{
    /// <summary>
    /// Returns  Thumbnail for the image from the database
    /// </summary>
    public class Thumbnail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            int photoID = Convert.ToInt32(context.Request.QueryString["PhotoID"]);
            int albumID = Convert.ToInt32(context.Request.QueryString["AlbumID"]);
            
            context.Response.Buffer = true;
            context.Response.StatusCode = 200;
            context.Response.Charset = "";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.ContentType = "image/bmp"; 
            context.Response.BinaryWrite(Provider.GetThumbnail(albumID, photoID));
            context.Response.Flush();
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}