using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Pigpot.RequestHandlerFilters
{
    public class DefaultRequestHandlerFilter : IRequestHandlerFilter
    {
        public IRequestHandler Filter(HttpContext httpContext, IEnumerable<IRequestHandler> sequence)
        {
            return sequence.FirstOrDefault(handler => handler.CanHandle(httpContext));
        }
    }
}
