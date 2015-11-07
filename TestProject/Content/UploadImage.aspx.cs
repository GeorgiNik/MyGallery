namespace TestProject.Content
{
    using System;
    using System.IO;
    using System.Web;

    /// <summary>
    /// Upload image page
    /// </summary>
    public partial class UploadImage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                this.ViewState["ReferringURL"] = this.Request.UrlReferrer;
            

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string filePath = this.FileUpload1.PostedFile.FileName;

            string filename = Path.GetFileName(filePath);
            string imageDiscr = this.ImageDescriptionTxt.Text.Trim();
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
            int albumID = Convert.ToInt32(this.Request.QueryString["AlbumID"]);
            string userName = HttpContext.Current.User.Identity.Name;
            
            bool isUploaded = false;
            foreach (var file in this.FileUpload1.PostedFiles)
            {
                Stream fileStream = file.InputStream;
                var memoryStream = new MemoryStream();

                fileStream.CopyTo(memoryStream);
                var photoInByteArr = memoryStream.ToArray();

                Model.UploadImage imageDetails = new Model.UploadImage();
                imageDetails.albumID = albumID;
                imageDetails.contenttype = contenttype;
                imageDetails.ext = ext;
                imageDetails.filename = filename;
                imageDetails.imageDescrp = imageDiscr;
                imageDetails.image = photoInByteArr;
                imageDetails.userName = userName;

                isUploaded = Provider.ImageUpload(imageDetails);
                
                if (!isUploaded)
                {
                    break;
                }

            }

            
            if (isUploaded)
            {
                this.lblMessage.ForeColor = System.Drawing.Color.Green;
                this.lblMessage.Text = "File Uploaded Successfully";
                this.lblMessage.Visible = true;
            }

            else
            {
                this.lblMessage.ForeColor = System.Drawing.Color.Red;
                this.lblMessage.Text = "Failed";
                this.lblMessage.Visible = true;
            }

        }

        protected void Redirect_Click(object sender, EventArgs e)
        {
            if (this.ViewState["ReferringURL"] != null)
                this.Response.Redirect(this.ViewState["ReferringURL"].ToString());

        }

    }
}
