using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IContextFactory
    {
        RequestContext CreateIfShould(HttpContext context);
    }
}
