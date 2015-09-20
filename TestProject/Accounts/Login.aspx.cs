using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestProject;
using Model;
namespace TestProject
{
    /// <summary>
    /// Login Page
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {

            var user = new Model.UserInfo();
            user.UserName = UserField.Text.Trim();
            user.Password = PassField.Text.Trim();

            if (Membership.ValidateUser(user.UserName, user.Password))
            {


                FormsAuthentication.RedirectFromLoginPage(user.UserName, false);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + "Invalid username or password" + "');", true);

            }

        }

        protected void RememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(UserField.Text, true);
        }

        protected void RegisterRedirect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Accounts/RegiterPage.aspx");
        }
    }
}