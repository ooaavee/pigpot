namespace Pigpot.Services
{
    public class DefaultCatalogResolver : IdentityBasedCatalogResolver
    {
        public DefaultCatalogResolver() : base("__public__")
        {
        }
    }
}
