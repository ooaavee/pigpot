using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Threading.Tasks;

namespace WebAppDemo.Middlewares
{
    public class IndexMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;

        public IndexMiddleware(RequestDelegate next, IHostingEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Path.Value == "/")
            {
                IFileInfo file = _env.WebRootFileProvider.GetFileInfo("index.html");
                string content = File.ReadAllText(file.PhysicalPath);
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(content);
                return;
            }

            await _next(context);
        }
    }
}
