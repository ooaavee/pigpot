using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IRequestHandler
    {
        bool CanHandle(HttpContext httpContext);

        Task HandleAsync(PigpotContext context);
    }
}
