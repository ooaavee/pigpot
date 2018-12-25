using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface ICatalogResolver
    {
        string GetCatalog(HttpContext context);
    }
}
