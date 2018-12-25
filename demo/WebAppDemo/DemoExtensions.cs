using Microsoft.AspNetCore.Builder;
using WebAppDemo.Middlewares;

namespace WebAppDemo
{
    public static class DemoExtensions
    {
        public static IApplicationBuilder UseDemo(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<IndexMiddleware>();
            builder.UseMiddleware<TestMiddleware>();

            return builder;
        }

    }
}
