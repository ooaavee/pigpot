using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Pigpot.Middlewares
{
    public class PigpotCrudMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IContextFactory _factory;

        public PigpotCrudMiddleware(RequestDelegate next, IContextFactory factory)
        {
            _next = next;
            _factory = factory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            RequestContext request = _factory.CreateIfShould(context);

            if (request == null)
            {
                await _next(context);
                return;
            }

            object result = await request.HandleAsync();

            // TODO: write response!

        }
    }
}
