using System;
using System.Web;
using System.Web.UI;
using System.IO;
using TestProject.App_Code;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Drawing;

namespace TestProject
{
    /// <summary>
    /// Upload image page
    /// </summary>
    public partial class UploadImage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ViewState["ReferringURL"] = Request.UrlReferrer;
            

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string filePath = FileUpload1.PostedFile.FileName;

            string filename = Path.GetFileName(filePath);
            string imageDiscr = ImageDescriptionTxt.Text.Trim();
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
            int albumID = Convert.ToInt32(Request.QueryString["AlbumID"]);
            string userName = HttpContext.Current.User.Identity.Name;
            
            bool isUploaded = false;
            foreach (var file in FileUpload1.PostedFiles)
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
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "File Uploaded Successfully";
                lblMessage.Visible = true;
            }

            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Failed";
                lblMessage.Visible = true;
            }

        }

        protected void Redirect_Click(object sender, EventArgs e)
        {
            if (ViewState["ReferringURL"] != null)
                Response.Redirect(ViewState["ReferringURL"].ToString());

        }

    }
}
