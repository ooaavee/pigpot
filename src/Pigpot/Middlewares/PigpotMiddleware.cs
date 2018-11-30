using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Pigpot.Middlewares
{
    public class PigpotMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IContextFactory _factory;

        public PigpotMiddleware(RequestDelegate next, IContextFactory factory)
        {
            _next = next;
            _factory = factory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            RequestContext request = _factory.CreateIfShould(context);

            if (request != null)
            {
                await request.OnRequestStartedAsync();
            }
            else
            {
                await _next(context);
            }

            //if (handler != null)
            //{
            //    var pigpot = new PigpotContext(context, handler);
            //    await pigpot.OnRequestStartedAsync();
            //    return;
            //}

        }
    }
}
