using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IRequestHandlerFilter
    {
        IRequestHandler Filter(HttpContext httpContext, IEnumerable<IRequestHandler> sequence);
    }
}
