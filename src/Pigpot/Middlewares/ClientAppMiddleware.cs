using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Pigpot.Middlewares
{
    public class ClientAppMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ClientAppMiddleware> _logger;

        public ClientAppMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ClientAppMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {            

            await _next(context);
        }
    }
}
