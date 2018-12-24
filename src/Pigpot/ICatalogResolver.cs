using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface ICatalogResolver
    {
        ICatalog Resolve(HttpContext context);
    }
}
