using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Pigpot
{
    public class ContextFactory : IContextFactory
    {
        public RequestContext CreateIfShould(HttpContext context)
        {
            RequestType requestType = GetRequestType(context);

            if (requestType == RequestType.None)
            {
                return null;
            }

            IRequestHandler handler = GetRequestHandler(requestType, context);

            if (handler == null)
            {
                return null;
            }

            IRequestKey key = GetKey(context);

            Catalog catalog = GetCatalog(context);

            RequestContext result = new RequestContext(context, handler, key, catalog);
            return result;
        }
       
        protected virtual RequestType GetRequestType(HttpContext context)
        {
            string method = context.Request.Method;

            if (method == HttpMethods.Get)
            {
                return HasKey(context) ? RequestType.GetSingle : RequestType.GetAll;
            }
            else if (method == HttpMethods.Post)
            {
                if (HasKey(context) || UseKeyGenerator(context))
                {
                    return RequestType.AddSingle;
                }
            }
            else if (method == HttpMethods.Put)
            {
                if (HasKey(context))
                {
                    return IsForceSave(context) ? RequestType.AddOrUpdateSingle : RequestType.UpdateSingle;
                }
            }
            else if (method == HttpMethods.Delete)
            {
                if (HasKey(context))
                {
                    return RequestType.DeleteSingle;
                }
            }

            return RequestType.None;
        }

        private const string Key = "key";

        private const string Force = "force";

        protected virtual IRequestKey GetKey(HttpContext context)
        {
            throw new NotImplementedException();
        }

        protected virtual bool HasKey(HttpContext context)
        {

            return false;
        }

        protected virtual bool IsForceSave(HttpContext context)
        {
            // force = true
            return false;
        }

        protected virtual bool UseKeyGenerator(HttpContext context)
        {
            return false;
        }

        protected virtual IRequestHandler GetRequestHandler(RequestType requestType, HttpContext context)
        {
            IRequestHandler result = null;

            foreach (IRequestHandler handler in context.RequestServices.GetServices<IRequestHandler>())
            {
                if (requestType == handler.RequestType && context.Request.Path.StartsWithSegments(handler.RootPath))
                {
                    // we won't exit after the next line, because the last match wins
                    result = handler;  
                }
            }

            return result;
        }

        protected virtual Catalog GetCatalog(HttpContext context)
        {
            ICatalogResolver resolver = context.RequestServices.GetRequiredService<ICatalogResolver>();
            Catalog catalog = resolver.Resolve(context);
            return catalog;
        }

    }
}
