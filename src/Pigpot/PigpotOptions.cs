using Pigpot.CatalogResolvers;
using Pigpot.RepositoryFilters;
using Pigpot.RequestHandlerFilters;

namespace Pigpot
{
    public class PigpotOptions
    {
        public PigpotOptions()
        {
            CatalogResover = new IdentityBasedCatalogResolver("__public__");

            RepositoryFilter = new DefaultRepositoryFilter();

            RequestHandlerFilter = new DefaultRequestHandlerFilter();
        }

        public IRequestHandlerFilter RequestHandlerFilter { get; set; }

        public ICatalogResolver CatalogResover { get; set; }

        public IRepositoryFilter RepositoryFilter { get; set; }
    }
}
