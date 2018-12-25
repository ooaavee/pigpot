using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebAppDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

           // var p = new PathString("ssss");

            services.AddPigpot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UsePigpotCrud();
            app.UsePigpotClientApp();

            app.Run(async context =>
            {
                var file = env.WebRootFileProvider.GetFileInfo("index.html");
                var content = File.ReadAllText(file.PhysicalPath);
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(content);                
            });
        }
    }
}
