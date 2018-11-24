using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pigpot.RequestHandlers
{
    public abstract class RequestHandlerBase : IRequestHandler
    {
        public bool CanHandle(HttpContext httpContext)
        {
            return false;
        }

        public Task HandleAsync(PigpotContext context)
        {
            return Task.CompletedTask;
        }
    }
}
