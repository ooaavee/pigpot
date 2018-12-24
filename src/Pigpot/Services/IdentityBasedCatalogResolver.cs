using Microsoft.AspNetCore.Http;

namespace Pigpot.Services
{
    /// <summary>
    /// Resolves catalogs by using the name of the current user.
    /// </summary>
    public class IdentityBasedCatalogResolver : ICatalogResolver
    {
        private readonly ICatalogResolver _fallback;

        public IdentityBasedCatalogResolver(string fallback)
        {
            _fallback = new FixedCatalogResolver(fallback);
        }

        public ICatalog Resolve(HttpContext context)
        {
            ICatalog catalog = null;

            if (context.User != null && context.User.Identity.IsAuthenticated)
            {
                catalog = new Catalog(context.User.Identity.Name);
            }

            return catalog ?? _fallback.Resolve(context);
        }
    }
}
