using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Pigpot.Middlewares
{
    public class CrudMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestContextFactory _contextFactory;
        private readonly ILogger<CrudMiddleware> _logger;

        public CrudMiddleware(RequestDelegate next, IRequestContextFactory contextFactory, ILoggerFactory loggerFactory)
        {
            _next = next;
            _contextFactory = contextFactory;
            _logger = loggerFactory.CreateLogger<CrudMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            foreach (IRequestHandler handler in context.RequestServices.GetServices<IRequestHandler>())
            {
                if (handler.CanHandle(context.Request, out string path))
                {
                    IRequestContext ctx = _contextFactory.CreateRequestContext(path);
                    await handler.HandleAsync(ctx);
                    return;
                }
            }

            await _next(context);
        }
    }
}
