using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TestProject.Content;
using TestProject.WebUIService;

namespace TestProject
{
    /// <summary>
    /// Home Page
    /// </summary>

    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                
            }

           

        }
       

        protected void Page_PreRender(object sender, EventArgs e)
        {
            
            //ListView1.DataSource = Provider.ShowOnlyPublic();
            //ListView1.DataBind();
            
            
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
                    Response.Redirect(string.Format("~/PublicAlbum.aspx?AlbumID={0}", AlbumID));
                }
            }
        }

        protected void AddAlbumBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/AddAlbum.aspx");
        }

        
        
        
    }
}