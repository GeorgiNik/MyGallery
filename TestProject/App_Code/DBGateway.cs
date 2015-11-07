namespace TestProject
{
    using TestProject.Content;

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