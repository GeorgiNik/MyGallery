using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Linq;
using System.Web;

namespace GalleryService
{
    public class HttpContextIdentityPolicy : IAuthorizationPolicy
    {
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            bool result = true;

            AuthorizationPolicyState apState = null;

            // If state is null, then this method has not been called before, so set up a policy state.
            if (state == null)
            {
                apState = new AuthorizationPolicyState();
                state = apState;
            }
            else
            {
                apState = (AuthorizationPolicyState)state;
            }

            if (!apState.ClaimsAdded)
            {
                //string ticket = Utilities.GetTicketFromOperationContext(OperationContext.Current);
                //int? userIdValue = Utilities.GetUserIdFromTicket(ticket);


                //// set the identity (for PrimaryIdentity)
                //// evaluationContext.Properties.Keys.Contains(["Identities"]
                //List<IIdentity> identities = null;
                //if (evaluationContext.Properties.Keys.Contains("Identities"))
                //{
                //    identities = evaluationContext.Properties["Identities"] as List<IIdentity>;
                //}
                //if (identities == null)
                //{
                //    identities = new List<IIdentity>();
                //    evaluationContext.Properties["Identities"] = identities;
                //}

                //UserInfo user = null;

                ////IUser user = User.GetUser(context.User.Identity.Name);
                //// FormsIdentity formId = context.User.Identity as FormsIdentity;
                //if (userIdValue.HasValue)
                //{
                //    // int userId = int.Parse(formId.Ticket.UserData);
                //    // UserInfo user = DBGateway.UserDBManager.GetUser(context.User.Identity.Name);
                //    user = DBGateway.UserDBManager.GetUser(userIdValue.Value);
                //}

                ////if (null != user)
                ////{
                //if (null == user)
                //{
                //    user = new UserInfo();
                //}
                //identities.Add(user); //context.User.Identity

                //// add a claim set containing the client name
                //Claim name = Claim.CreateNameClaim(user.Identity.Name);
                //ClaimSet set = new DefaultClaimSet(name);
                //evaluationContext.AddClaimSet(this, set);


                //// Set CultureInfo
                //int requestCultureId = 0;

                //// UserInfo userInfo = System.Threading.Thread.CurrentPrincipal.Identity as UserInfo;

                //if ((null != user) && (user.IsAuthenticated))
                //{
                //    requestCultureId = user.CultureId;
                //}
                //else
                //{
                //    requestCultureId = DBGateway.NegometrixSystemDBManager.GetNegometrixSystem().DefaultCultureId;//NegometrixServiceProxy.Instance.GetNegometrixSystem().DefaultCultureId;
                //}

                //UserCultureInfo uci = DBGateway.CultureDBManager.GetCulture(requestCultureId);
                //CultureInfo newInfo = CultureInfo.GetCultureInfo(uci.Abbreviation);
                //Thread.CurrentThread.CurrentCulture = newInfo;
                //Thread.CurrentThread.CurrentUICulture = newInfo;



                ////}
                //result = true;




                //HttpContext context = HttpContext.Current;

                //if (context != null)
                //{
                //    // set the identity (for PrimaryIdentity)
                //    // evaluationContext.Properties.Keys.Contains(["Identities"]
                //    List<IIdentity> identities = null;
                //    if (evaluationContext.Properties.Keys.Contains("Identities"))
                //    {
                //        identities = evaluationContext.Properties["Identities"] as List<IIdentity>;
                //    }
                //    if (identities == null)
                //    {
                //        identities = new List<IIdentity>();
                //        evaluationContext.Properties["Identities"] = identities;
                //    }

                //    UserInfo user = null;

                //    //IUser user = User.GetUser(context.User.Identity.Name);
                //    FormsIdentity formId = context.User.Identity as FormsIdentity;
                //    if (formId != null)
                //    {
                //        int userId = int.Parse(formId.Ticket.UserData);
                //        // UserInfo user = DBGateway.UserDBManager.GetUser(context.User.Identity.Name);
                //        user = DBGateway.UserDBManager.GetUser(userId);
                //    }

                //    //if (null != user)
                //    //{
                //        if (null == user)
                //        {
                //            user = new UserInfo();
                //        }
                //        identities.Add(user); //context.User.Identity

                //        // add a claim set containing the client name
                //        Claim name = Claim.CreateNameClaim(user.Identity.Name);
                //        ClaimSet set = new DefaultClaimSet(name);
                //        evaluationContext.AddClaimSet(this, set);


                //    // Set CultureInfo
                //        int requestCultureId = 0;

                //        // UserInfo userInfo = System.Threading.Thread.CurrentPrincipal.Identity as UserInfo;

                //        if ((null != user) && (user.IsAuthenticated))
                //        {
                //            requestCultureId = user.CultureId;
                //        }
                //        else
                //        {
                //            bool parseResult = int.TryParse(ConfigurationManager.AppSettings["DefaultCultureInfoId"], NumberStyles.Integer, CultureInfo.InvariantCulture, out requestCultureId);
                //            if (!parseResult)
                //            {
                //                throw new NotSupportedException("Not Supported Culture ID");
                //            }
                //        }

                //        UserCultureInfo uci = DBGateway.CultureDBManager.GetCulture(requestCultureId);
                //        CultureInfo newInfo = CultureInfo.GetCultureInfo(uci.Abbreviation);
                //        Thread.CurrentThread.CurrentCulture = newInfo;
                //        Thread.CurrentThread.CurrentUICulture = newInfo; 



                //    //}
                //    result = true;
                //}
            }
            else
            {
                result = true;
            }

            return result;
        }

        public System.IdentityModel.Claims.ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }

        public string Id
        {
            get { return "HttpContextIdentityPolicy"; }
        }
    }
}