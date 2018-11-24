using System.Collections.Generic;

namespace Pigpot
{
    public interface IRepositoryFilter
    {
        IRepository Filter(PigpotContext context, IEnumerable<IRepository> sequence);
    }
}
