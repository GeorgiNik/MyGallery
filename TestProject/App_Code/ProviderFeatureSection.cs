namespace TestProject
{
    using System.Configuration;

    public class ProviderFeatureSection : System.Configuration.ConfigurationSection
    {
        private readonly ConfigurationProperty defaultProvider = new ConfigurationProperty("defaultProvider", typeof(string), null);
        private readonly ConfigurationProperty providers = new ConfigurationProperty("providers", typeof(ProviderSettingsCollection), null);
        private ConfigurationPropertyCollection properties = new ConfigurationPropertyCollection();
        public ProviderFeatureSection()
        {
            this.properties.Add(this.providers);
            this.properties.Add(this.defaultProvider);
        }
        [ConfigurationProperty("defaultProvider")]
        public string DefaultProvider
        {
            get { return (string)base[this.defaultProvider]; }
            set { base[this.defaultProvider] = value; }
        }
        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get { return (ProviderSettingsCollection)base[this.providers]; }
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get { return this.properties; }
        }
    }
}
