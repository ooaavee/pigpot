using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public class RequestContext : IRequestContext
    {
        public RequestContext(HttpContext httpContext, ICatalog catalog, PathString path)
        {
            HttpContext = httpContext;
            Catalog = catalog;
            Path = path;
        }

        public virtual HttpContext HttpContext { get; }

        public virtual ICatalog Catalog { get; }

        public virtual PathString Path { get; }
    }
}
