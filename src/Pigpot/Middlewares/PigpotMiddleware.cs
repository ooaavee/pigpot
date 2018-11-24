using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Pigpot.Middlewares
{
    public class PigpotMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<PigpotMiddleware> _logger;
        private readonly PigpotOptions _options;

        public PigpotMiddleware(
            RequestDelegate next, 
            ILoggerFactory loggerFactory, 
            IOptions<PigpotOptions> options)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<PigpotMiddleware>();
            _options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {



            await _next(context);
        }
    }
}
