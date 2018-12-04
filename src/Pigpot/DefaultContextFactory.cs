using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Pigpot
{
    public class DefaultContextFactory : IContextFactory
    {
        public RequestContext CreateIfShould(HttpContext context)
        {
            RequestContext result = null;

            if (TryGetRequestHandler(context, out IRequestHandler handler))
            {
                if (TryResolveCatalog(context, out Catalog catalog))
                {
                    result = new RequestContext(context, catalog, handler);
                }
            }

            return result;
        }
       
        protected virtual bool TryGetRequestHandler(HttpContext context, out IRequestHandler result)
        {
            result = null;

            foreach (IRequestHandler handler in context.RequestServices.GetServices<IRequestHandler>().Reverse())
            {
                if (handler.CanHandle(context.Request))
                {
                    result = handler;
                    break;
                }
            }

            return result != null;
        }

        protected virtual bool TryResolveCatalog(HttpContext context, out Catalog result)
        {
            result = context.RequestServices.GetRequiredService<ICatalogResolver>().Resolve(context);
            return result != null;
        }
    }
}
