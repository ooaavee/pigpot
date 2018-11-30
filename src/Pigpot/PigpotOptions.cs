namespace Pigpot
{
    public class PigpotOptions
    {
        public IContextFactory ContextFactory { get; set; } = new ContextFactory();

        public ICatalogResolver CatalogResover { get; set; } = new IdentityBasedCatalogResolver("__public__");

        public IRepositoryFilter RepositoryFilter { get; set; } = new RepositoryFilter();
    }
}
