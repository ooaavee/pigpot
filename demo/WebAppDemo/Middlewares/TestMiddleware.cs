using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace WebAppDemo.Middlewares
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;
       
        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Path.Value == "/test")
            {
                await RunTestSequenceAsync(context);
                return;
            }
            await _next(context);
        }

        private async Task RunTestSequenceAsync(HttpContext context)
        {
            string host = GetHost(context);

            var result = await host
                .AppendPathSegment("person")
                .SetQueryParams(new { key = "123" })
                .GetAsync()
                .ReceiveJson<SampleData>();
        }

        private static string GetHost(HttpContext context)
        {
            string host = context.Request.Scheme + "://" + context.Request.Host + "/pigpot/api";
            return host;
        }


        //private async Task Test<T>()
        //{
        //    var result = await "https://api.mysite.com"
        //        .AppendPathSegment("person")
        //        .SetQueryParams(new { api_key = "xyz" })
        //        .WithOAuthBearerToken("my_oauth_token")
        //        .PostJsonAsync(new { first_name = firstName, last_name = lastName })
        //        .ReceiveJson<T>();
        //}


        public class SampleData
        {

        }

    }
}
