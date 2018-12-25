using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public class RequestContext : IRequestContext
    {
        public RequestContext(HttpContext httpContext, string catalog, string path)
        {           
            HttpContext = httpContext;
            Catalog = catalog;
            Path = path;
        }

        public virtual HttpContext HttpContext { get; }

        public virtual string Catalog { get; }

        public virtual string Path { get; }
    }
}
