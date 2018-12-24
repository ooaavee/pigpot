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

        public IRequestContext ForPath(string path)
        {
            return ForPath(new PathString(path));
        }

        public IRequestContext ForPath(PathString path)
        {
            ICatalog catalog = _resolver.Resolve(_accessor.HttpContext);
            if (catalog == null)
            {
                throw new InvalidOperationException($"{nameof(ICatalogResolver)} did not found any suitable catalog.");
            }
            return new RequestContext(_accessor.HttpContext, catalog, path);
        }

        public IRequestContext ForPathAndCatalog(string path, string catalog)
        {
            return ForPathAndCatalog(new PathString(path), new Catalog(catalog));
        }

        public IRequestContext ForPathAndCatalog(PathString path, Catalog catalog)
        {
            return new RequestContext(_accessor.HttpContext, catalog, path);
        }
    }
}
