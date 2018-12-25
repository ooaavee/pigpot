using System;
using System.Collections.Generic;
using System.Linq;

namespace Pigpot.Services
{
    public class DefaultRepositoryFilter : IRepositoryFilter
    {
        public IRepository Filter(string catalog, string path, IEnumerable<IRepository> sequence)
        {
            try
            {
                return sequence.Single();
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException("Unable to resolve which repository to use, because there is zero or more than one repository available. Please make sure that there is only one registered IRepository service or use a custom IRepositoryFilter service to filter repositories.", e);
            }
        }
    }
}
