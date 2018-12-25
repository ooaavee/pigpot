using Microsoft.AspNetCore.Http;
using System;

namespace Pigpot.Services
{
    public class DefaultRequestContextFactory : IRequestContextFactory
    {
        private readonly ICatalogResolver _resolver;
        private readonly IHttpContextAccessor _accessor;

        public DefaultRequestContextFactory(ICatalogResolver resolver, IHttpContextAccessor accessor)
        {
            _resolver = resolver;
            _accessor = accessor;
        }

        public IRequestContext CreateRequestContext(string path)
        {
            HttpContext context = _accessor.HttpContext;

            string catalog = _resolver.GetCatalog(context);
            if (catalog == null)
            {
                throw new InvalidOperationException($"{nameof(ICatalogResolver)} did not found any suitable catalog.");
            }

            return new RequestContext(context, catalog, path);
        }

        public IRequestContext CreateRequestContext(string path, string catalog)
        {
            return new RequestContext(_accessor.HttpContext, catalog, path);
        }
    }
}
