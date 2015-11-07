namespace TestProject
{
    using System;
    using System.Configuration.Provider;

    public class ProviderList : ProviderCollection
    {
        public override void Add(ProviderBase provider)
        {
            string providerTypeName;

            // make sure the provider supplied is not null
            if (provider == null)
                throw new ArgumentNullException("provider");

            if (provider as MyGalleryProvider == null)
            {
                providerTypeName = typeof(MyGalleryProvider).ToString();
                throw new ArgumentException("Provider must implement MyGalleryProvider type", providerTypeName);
            }
            base.Add(provider);
        }
        new public MyGalleryProvider this[string name]
        {
            get
            {
                return (MyGalleryProvider)base[name];
            }
        }

    }
}
