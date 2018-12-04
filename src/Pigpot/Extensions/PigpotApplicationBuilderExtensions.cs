using Pigpot;
using Pigpot.Middlewares;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class PigpotApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePigpotCrud(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PigpotCrudMiddleware>();
        }
    }
}
