﻿namespace TestProject
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Configuration.Provider;
    using System.Data;
    using System.Data.SqlClient;
    using System.Net.Mail;
    using System.Web.Security;

    public class MyMembershipProvider : MembershipProvider
    {


        #region Private Fields
        private bool pEnablePasswordReset;
        private bool pEnablePasswordRetrieval;
        private bool pRequiresQuestionAndAnswer;
        private bool pRequiresUniqueEmail;
        private int pMaxInvalidPasswordAttempts;
        private int pPasswordAttemptWindow;
        private MembershipPasswordFormat pPasswordFormat;
        private int pMinLenght;
        
        #endregion

        #region Public Metods
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (String.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }

        public override void Initialize(string name, NameValueCollection config)
        {


            if (config == null)
                throw new ArgumentNullException("config");

            base.Initialize(name, config);

            this.pMaxInvalidPasswordAttempts = Convert.ToInt32(this.GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            this.pPasswordAttemptWindow = Convert.ToInt32(this.GetConfigValue(config["passwordAttemptWindow"], "10"));
            this.pEnablePasswordReset = Convert.ToBoolean(this.GetConfigValue(config["enablePasswordReset"], "true"));
            this.pEnablePasswordRetrieval = Convert.ToBoolean(this.GetConfigValue(config["enablePasswordRetrieval"], "true"));
            this.pRequiresQuestionAndAnswer = Convert.ToBoolean(this.GetConfigValue(config["requiresQuestionAndAnswer"], "false"));
            this.pRequiresUniqueEmail = Convert.ToBoolean(this.GetConfigValue(config["requiresUniqueEmail"], "true"));
            this.pMinLenght = Convert.ToInt32(this.GetConfigValue(config["minRequiredPasswordLength"], "6"));
            string temp_format = config["passwordFormat"];

            switch (temp_format)
            {
                case "Hashed":
                    this.pPasswordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    this.pPasswordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    this.pPasswordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("Password format not supported.");

            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { return this.pEnablePasswordReset; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return this.pEnablePasswordRetrieval; }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return this.pMaxInvalidPasswordAttempts; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return this.pMinLenght; }
        }

        public override int PasswordAttemptWindow
        {
            get { return this.pPasswordAttemptWindow; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return this.pPasswordFormat; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return this.pRequiresQuestionAndAnswer; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return this.pRequiresUniqueEmail; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            int userId = 0;
            bool userExists = true;
            string MyGalleryProviderSql = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            using (SqlConnection con = new SqlConnection(MyGalleryProviderSql))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
                if (userId == -1)
                {
                    userExists = false;
                }
                return userExists;
            }
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            MembershipUser newUser = null;
            try
            {
                string MyGalleryProviderSql = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
                int userId = 0;

                using (SqlConnection con = new SqlConnection(MyGalleryProviderSql))
                {
                    using (SqlCommand cmd = new SqlCommand("Insert_User"))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                    }
                }

                newUser = new MembershipUser(
                "MyMembershipProvider",
                username, null, email, String.Empty,
                String.Empty, true, false, DateTime.Now,
                DateTime.Now, DateTime.Now, DateTime.Now,
                DateTime.Now);

                if (userId == -1)
                {
                    status = MembershipCreateStatus.DuplicateUserName;
                }
                else if (userId == -2)
                {
                    status = MembershipCreateStatus.DuplicateEmail;
                }
                else
                {
                    status = MembershipCreateStatus.Success;
                    this.SendActivationEmail(userId, username, email);

                }

            }
            catch (Exception ex)
            {
                status = MembershipCreateStatus.ProviderError;
                newUser = null;
                throw ex;
            }

            return newUser;

        }

        private void SendActivationEmail(int userId, string username, string userEmail)
        {
            string MyGalleryProviderSql = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            string activationCode = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(MyGalleryProviderSql))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            string fromEMail = ConfigurationManager.AppSettings["fromEMail"];
            using (MailMessage mm = new MailMessage(fromEMail, userEmail))
            {
                string confirmationUrl = ConfigurationManager.AppSettings["userConfirmationUrl"];

                mm.From = new MailAddress(fromEMail);
                mm.To.Add(new MailAddress(userEmail));

                mm.Subject = "Account Activation";
                string body = "Hello " + username + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + string.Format(confirmationUrl, activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient();

                smtp.Send(mm);


            }
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        } 
        #endregion
    }
}