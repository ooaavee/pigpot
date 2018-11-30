using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    /// <summary>
    /// Resolve catalogs by using the name of the current user.
    /// </summary>
    public class IdentityBasedCatalogResolver : ICatalogResolver
    {
        private readonly ICatalogResolver _fallback;

        public IdentityBasedCatalogResolver(ICatalogResolver fallback)
        {
            _fallback = fallback;
        }

        public IdentityBasedCatalogResolver(string fallback)
        {
            _fallback = new FixedCatalogResolver(fallback);
        }

        public Catalog Resolve(HttpContext context)
        {
            Catalog catalog = null;

            if (context.User != null && context.User.Identity.IsAuthenticated)
            {
                catalog = new Catalog(context.User.Identity.Name);
            }

            if (catalog == null)
            {
                catalog = _fallback.Resolve(context);
            }

            return catalog;
        }
    }
}
