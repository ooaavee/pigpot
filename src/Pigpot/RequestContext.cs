using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pigpot
{
    public class RequestContext
    {
        private readonly IRequestHandler _handler;

        public RequestContext(HttpContext httpContext, Catalog catalog, IRequestHandler handler)
        {
            HttpContext = httpContext;
            Catalog = catalog;
            _handler = handler;
        }

        /// <summary>
        /// The current HTTP context
        /// </summary>
        public HttpContext HttpContext { get; }

        /// <summary>
        /// The current catalog
        /// </summary>
        public Catalog Catalog { get; }

       

        ///// <summary>
        ///// The current content or null if not available
        ///// </summary>
        //public string Content => _content ?? (_content = ResolveContent(HttpContext));

        //private static string ResolvePath(HttpContext httpContext)
        //{
        //    throw new NotImplementedException();
        //}

        //private static string ResolveContent(HttpContext httpContext)
        //{
        //    throw new NotImplementedException();
        //}


        public async Task<object> HandleAsync()
        {
            return await _handler.HandleAsync(this);
        }
    }
}
