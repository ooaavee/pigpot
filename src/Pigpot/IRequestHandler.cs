using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IRequestHandler
    {
        RequestType RequestType { get; }

        PathString RootPath { get; }

        Task HandleAsync(RequestContext context);
    }
}
