namespace Pigpot
{
    public class PigpotOptions
    {
        public IContextFactory ContextFactory { get; set; } 

        public ICatalogResolver CatalogResover { get; set; }
            
        public IRepositoryFilter RepositoryFilter { get; set; }

        public PigpotOptions()
        {
            ContextFactory = new DefaultContextFactory();
            CatalogResover = DefaultCatalogResolver.AsIdentityBasedCatalogResolver("__public__");
            RepositoryFilter = new DefaultRepositoryFilter();
        }
    }
}
