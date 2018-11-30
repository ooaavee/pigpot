using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pigpot.RequestHandlers
{
    public abstract class RequestHandlerBase : IRequestHandler
    {

        protected RequestHandlerBase()
        {
        }

        protected RequestHandlerBase(RequestType requestType, PathString rootPath)
        {
            RequestType = requestType;
            RootPath = rootPath;
        }

        public RequestType RequestType { get; }

        public PathString RootPath { get; }

        public Task HandleAsync(RequestContext context)
        {
            return Task.CompletedTask;
        }
    }
}
