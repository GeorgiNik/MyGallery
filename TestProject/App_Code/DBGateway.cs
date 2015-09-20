using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Content;


namespace TestProject.App_Code
{
    public static class DBGateway
    {
        /// <summary>
        /// Instance of MyGallerySqlProvider
        /// </summary>
        
        public static MyGalleryProviderSql MyGalleryProviderSqlManager
        {
            get
            {
                return MyGalleryProviderSql.Instance;
            }
        }

        /// <summary>
        /// Instance of MyGalleryWcfProvider
        /// </summary>
        public static MyGalleryWcfProvider MyGalleryProviderWcfManager
        {
            get
            {
                return MyGalleryWcfProvider.Instance;
            }
        }
    }
}