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
        private readonly IRequestKey _key;
        private string _path;
        private string _content;

        public RequestContext(HttpContext httpContext, IRequestHandler handler, IRequestKey key, Catalog catalog)
        {
            _handler = handler;
            Key = key.Value();
            Catalog = catalog;
            HttpContext = httpContext;  
        }

        /// <summary>
        /// The current HTTP context
        /// </summary>
        public HttpContext HttpContext { get; }

        /// <summary>
        /// The current key or null if not available
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// The current catalog
        /// </summary>
        public Catalog Catalog { get; }

        /// <summary>
        /// The current path
        /// </summary>
        public string Path => _path ?? (_path = ResolvePath(HttpContext));

        /// <summary>
        /// The current content or null if not available
        /// </summary>
        public string Content => _content ?? (_content = ResolveContent(HttpContext));
        
        private static string ResolvePath(HttpContext httpContext)
        {
            throw new NotImplementedException();
        }

        private static string ResolveContent(HttpContext httpContext)
        {
            throw new NotImplementedException();
        }


        public async Task OnRequestStartedAsync()
        {
            throw new NotImplementedException();

        }
    }
}
