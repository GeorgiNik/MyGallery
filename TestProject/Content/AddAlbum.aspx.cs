using System;
using System.Web;
using TestProject.App_Code;

namespace TestProject.Content
{
    public partial class AddAlbum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateBtn_Click(object sender, EventArgs e)
        {
            var desc=txtDescr.Text.Trim() ;
            var album = txtAlbumName.Text.Trim();
            
            if (Provider.CreateAlbum(album, desc,HttpContext.Current.User.Identity.Name))
            {
                
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Album Created successfuly";
                lblMessage.Visible = true;
            }

            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Album not created";
                lblMessage.Visible = true;
            }
        }

        protected void BackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Content/Gallery.aspx");

        }
    }
}