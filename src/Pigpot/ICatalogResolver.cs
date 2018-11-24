using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface ICatalogResolver
    {
        Catalog Resolve(HttpContext context);
    }
}
