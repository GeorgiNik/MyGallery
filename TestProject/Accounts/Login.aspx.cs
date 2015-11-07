namespace TestProject.Accounts
{
    using System;
    using System.Web.Security;

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
            user.UserName = this.UserField.Text.Trim();
            user.Password = this.PassField.Text.Trim();

            if (Membership.ValidateUser(user.UserName, user.Password))
            {


                FormsAuthentication.RedirectFromLoginPage(user.UserName, false);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + "Invalid username or password" + "');", true);

            }

        }

        protected void RememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(this.UserField.Text, true);
        }

        protected void RegisterRedirect_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Accounts/RegiterPage.aspx");
        }
    }
}