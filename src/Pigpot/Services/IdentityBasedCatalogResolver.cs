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

        public string GetCatalog(HttpContext context)
        {
            string catalog = null;

            if (context.User != null && context.User.Identity.IsAuthenticated)
            {
                catalog = context.User.Identity.Name;
            }

            return catalog ?? _fallback.GetCatalog(context);
        }
    }
}
