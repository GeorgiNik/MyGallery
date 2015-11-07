namespace TestProject.Accounts
{
    using System;

    /// <summary>
    /// Activation Page
    /// </summary>
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
                string activationCode = !string.IsNullOrEmpty(this.Request.QueryString["ActivationCode"]) ? this.Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
                var rowsAffected = Provider.ActivateAcc(activationCode);

                if (rowsAffected == 1)
                {
                    this.ltMessage.Text = "Activation successful.";
                }
                else
                {
                    this.ltMessage.Text = "Invalid Activation code.";
                }
            }
        }
    }
}