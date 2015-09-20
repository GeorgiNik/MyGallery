using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalleryService
{
    public class AuthorizationPolicyState
    {
        #region Private Member Variables

        private bool _ClaimsAdded;

        #endregion

        #region Constructors

        public AuthorizationPolicyState()
        {

        }

        #endregion

        #region Public Methods

        public bool ClaimsAdded
        {
            get
            {
                return _ClaimsAdded;
            }
            set
            {
                _ClaimsAdded = value;
            }
        }

        #endregion

    }
}