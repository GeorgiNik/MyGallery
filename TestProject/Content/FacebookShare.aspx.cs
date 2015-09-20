using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestProject.Content
{
    /// <summary>
    /// Facebook sharing 
    /// </summary>
    public partial class FacebookShare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var referer = Request.UrlReferrer.ToString();

            if (string.IsNullOrEmpty(referer))
            {
                // some error logic
                return;
            }

            Response.Clear();
            Response.Redirect("http://www.facebook.com/sharer/sharer.php?u=" + HttpUtility.UrlEncode(referer));
            Response.End();
        }
    }
}