using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestProject.App_Code;
using TestProject.GalleryServiceReference;

namespace TestProject.Content
{
    /// <summary>
    /// Page with user albums
    /// </summary>
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                var userName = HttpContext.Current.User.Identity.Name;
                ListView1.DataSource = Provider.ShowGallery(userName);
                ListView1.DataBind();
            
           
            
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AlbumImage_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "viewAlbum")
            {
                int AlbumID;
                if (int.TryParse(e.CommandArgument.ToString(), out AlbumID))
                {
                    Response.Redirect(string.Format("~/Content/Album.aspx?AlbumID={0}",AlbumID));
                }
            }
        }

        protected void AddAlbumBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/AddAlbum.aspx");
        }

        protected void btnShare_Command(object sender, CommandEventArgs e)
        {
            
            if (e.CommandName == "shareAlbum")
            {
                int AlbumID;
                if (int.TryParse(e.CommandArgument.ToString(), out AlbumID))
                {
                    if (Provider.PublishAlbum(AlbumID))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "id", "PopUp()", true);
                    }
                }
            }
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            
            if (e.CommandName == "deleteAlbum")
            {
                int AlbumID;
                if (int.TryParse(e.CommandArgument.ToString(), out AlbumID))
                {
                    if (Provider.DeleteAlbum(AlbumID))
                    {
                        var userName = HttpContext.Current.User.Identity.Name;
                        ListView1.DataSource = Provider.ShowGallery(userName);
                        ListView1.DataBind();
                        UpdatePanelAlbums.Update();

                        //Response.Redirect(Request.RawUrl);
                    }
                }
            }
        }
        protected void btnUnShare_Command(object sender, CommandEventArgs e)
        {
            
            if (e.CommandName == "UnPublish")
            {
                int AlbumID;
                if (int.TryParse(e.CommandArgument.ToString(), out AlbumID))
                {
                    if (!Provider.UnPublishAlbum(AlbumID))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "id", "PopUpUnpublish()", true);
                    }
                }
            }
        }

        

        
        
    }
}