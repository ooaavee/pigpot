using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Pigpot
{
    public interface IRepositoryFilter
    {
        IRepository Filter(ICatalog catalog, PathString path, IEnumerable<IRepository> sequence);
    }
}
