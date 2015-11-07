using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace TestProject.WebUIService
{
    /// <summary>
    /// Summary description for MyGalleryWebService
    /// </summary>
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class MyGalleryWebService : System.Web.Services.WebService
    {

        [WebMethod]
    
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Model.Album> GetPublicAlbums()
        {
            var result = Provider.ShowOnlyPublic();
            return result;

        }


    }
}
