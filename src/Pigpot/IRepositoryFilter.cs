using System.Collections.Generic;

namespace Pigpot
{
    public interface IRepositoryFilter
    {
        IRepository Filter(string catalog, string path, IEnumerable<IRepository> sequence);
    }
}
