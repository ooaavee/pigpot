using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IRequestContextFactory
    {
        IRequestContext ForPath(string path);

        IRequestContext ForPath(PathString path);

        IRequestContext ForPathAndCatalog(string path, string catalog);

        IRequestContext ForPathAndCatalog(PathString path, Catalog catalog);
    }
}
