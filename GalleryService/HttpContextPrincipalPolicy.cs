using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.ServiceModel.Web;

namespace GalleryService
{
    public class HttpContextPrincipalPolicy : IAuthorizationPolicy
    {
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            bool result = false;

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
                try
                {
                    IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
                    string token = request.Headers["JWT"];

                    if (ValidateToken(token))
                    {
                        evaluationContext.Properties["Principal"] = new User();
                        result = true;
                    }

                }
                catch (Exception exp)
                {

                }
            }
            else
            {
                result = true;
            }

            return result;
        }

        private bool ValidateToken(string token)
        {
            return  true;
        }

        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }

        public string Id
        {
            get { return "HttpContextPrincipalPolicy"; }
        }
    }
}
