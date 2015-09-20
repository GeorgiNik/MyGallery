using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using TestProject.App_Code;

namespace TestProject
{
    /// <summary>
    /// Activation Page
    /// </summary>
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                
                string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
                var rowsAffected = Provider.ActivateAcc(activationCode);

                if (rowsAffected == 1)
                {
                    ltMessage.Text = "Activation successful.";
                }
                else
                {
                    ltMessage.Text = "Invalid Activation code.";
                }
            }
        }
    }
}