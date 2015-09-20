using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace GalleryService
{
    public class AuthorizationManager : ServiceAuthorizationManager
    {
        #region Constructors

        /// <summary>
        /// Constructor of the <see cref="AuthorizationManager"/> class
        /// </summary>
        public AuthorizationManager()
            : base()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks authorization for the given operation context based on default policy evaluation.
        /// </summary>
        /// <param name="operationContext">The OperationContext for the current authorization request.</param>
        /// <returns><code>true</code> if access is granted; otherwise, <code>false</code>.</returns>
        protected override bool CheckAccessCore(OperationContext operationContext)
        {

//#if DEBUG
//            string a = operationContext.IncomingMessageHeaders.Action;
//            DispatchOperation operation = operationContext.EndpointDispatcher.DispatchRuntime.Operations.FirstOrDefault(o => o.Action == a);
//            if (operation != null)
//            {
//                XmlDocument doc = new XmlDocument();
//                doc.LoadXml(operationContext.RequestContext.RequestMessage.ToString());
//                XmlNodeList nodes = doc.GetElementsByTagName("s:Body");

//                if (nodes.Count > 0)
//                {
//                    Debug.WriteLine(nodes[0].InnerXml);
//                }
//                //Debug.WriteLine(String.Format("SERVICE METHOD CALL: {0}", operation.Name));
//                //Debug.WriteLine(String.Format("{0}", operationContext.RequestContext.RequestMessage));
//            }
//#endif

//            // Extract the action URI from the OperationContext. Match this against the claims
//            // in the AuthorizationContext.
//            string action = operationContext.RequestContext.RequestMessage.Headers.Action;


//            // Iterate through the various claim sets in the AuthorizationContext.
//            foreach (ClaimSet cs in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
//            {
//                // Examine only those claim sets issued by System.
//                if (cs.Issuer == ClaimSet.System)
//                {
//                    // Iterate through claims of type "http://www.contoso.com/claims/allowedoperation".
//                    foreach (Claim c in cs.FindClaims("http://www.contoso.com/claims/allowedoperation", Rights.PossessProperty))
//                    {
//                        // If the Claim resource matches the action URI then return true to allow access.
//                        if (action == c.Resource.ToString())
//                            return true;
//                    }
//                }
//            }

            // If this point is reached, return false to deny access.
            return true;
        }

        /// <summary>
        /// Checks authorization for the given operation context when access to a message is required.
        /// </summary>
        /// <param name="operationContext">The OperationContext for the current authorization request.</param>
        /// <param name="message">The Message to be examined to determine authorization.</param>
        /// <returns><code>true</code> if access is granted; otherwise, <code>false</code>.</returns>
        public override bool CheckAccess(OperationContext operationContext, ref System.ServiceModel.Channels.Message message)
        {
            bool baseAccess = base.CheckAccess(operationContext, ref message);
            return baseAccess;
        }

        /// <summary>
        /// Checks authorization for the given operation context when access to a message is required.
        /// </summary>
        /// <param name="operationContext">The OperationContext for the current authorization request.</param>
        /// <returns><code>true</code> if access is granted; otherwise, <code>false</code>.</returns>
        public override bool CheckAccess(OperationContext operationContext)
        {
            bool baseAccess = base.CheckAccess(operationContext);
            return baseAccess;
        }

        #endregion
    }
}