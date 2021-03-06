﻿using Pigpot.Middlewares;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder
{
    public static class PigpotApplicationBuilderExtensions
    {
        public static IApplicationBuilder UsePigpot(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PigpotMiddleware>();
        }
    }
}
