using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestProject
{
    /// <summary>
    /// Template for all pages
    /// </summary>
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isUserLogged = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (isUserLogged)
            {
                btnRegister.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Accounts/RegiterPage.aspx");
        }

        protected void LoginStatus1_LoggedOut(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}