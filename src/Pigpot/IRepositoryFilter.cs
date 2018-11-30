using System.Collections.Generic;

namespace Pigpot
{
    public interface IRepositoryFilter
    {
        IRepository Filter(RequestContext context, IEnumerable<IRepository> sequence);
    }
}
