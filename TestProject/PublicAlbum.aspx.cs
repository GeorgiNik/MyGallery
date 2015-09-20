using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestProject.App_Code;
using TestProject.Content;
using TestProject.GalleryServiceReference;

namespace TestProject
{
    /// <summary>
    /// Shows all published albums
    /// </summary>
    public partial class PublicAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["AlbumID"] != null)
            {
                int albumID = Convert.ToInt32(Request.QueryString["AlbumID"]);
                
                
                ListView1.DataSource = Provider.ShowPublicAlbum(albumID) ;
                ListView1.DataBind();
                

            }
            if (!Page.IsPostBack)
                ViewState["Album"] = Request.QueryString["AlbumID"];
           

        }

     
        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void FbShareBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/FacebookShare.aspx");
        }

        protected void downloadBtn_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                int picId;
                if (int.TryParse(e.CommandArgument.ToString(), out picId))
                {
                    
                    Response.Redirect(string.Format("~/FullSizePhoto.ashx?PhotoID={0}", picId));

                }
            }
        }

        //protected void UploadBtn_Command(object sender, CommandEventArgs e)
        //{


        //    if (e.CommandName == "upload")
        //    {
        //        if (ViewState["Album"] != null)
        //        {

        //            int AlbumID;
        //            if (int.TryParse(ViewState["Album"].ToString(), out AlbumID))
        //            {
        //                Response.Redirect(string.Format("~/Content/UploadImage.aspx?AlbumID={0}", AlbumID));
        //            }
        //        }
        //    }
        //}

       
    }
}