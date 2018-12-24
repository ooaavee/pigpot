using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Pigpot.Middlewares
{
    public class CrudMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestContextFactory _factory;
        private readonly ILogger<CrudMiddleware> _logger;

        public CrudMiddleware(RequestDelegate next, IRequestContextFactory factory, ILoggerFactory loggerFactory)
        {
            _next = next;
            _factory = factory;
            _logger = loggerFactory.CreateLogger<CrudMiddleware>();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            foreach (IRequestHandler handler in context.RequestServices.GetServices<IRequestHandler>())
            {
                if (handler.Accept(context.Request, out PathString path))
                {
                    IRequestContext ctx = _factory.ForPath(path);
                    await handler.HandleAsync(ctx);
                    return;
                }
            }

            await _next(context);
        }
    }
}
