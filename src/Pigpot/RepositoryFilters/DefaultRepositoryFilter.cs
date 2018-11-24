using System;
using System.Collections.Generic;
using System.Linq;

namespace Pigpot.RepositoryFilters
{
    public class DefaultRepositoryFilter : IRepositoryFilter
    {
        public IRepository Filter(PigpotContext context, IEnumerable<IRepository> sequence)
        {
            IRepository[] repositories = sequence.ToArray();

            int count = repositories.Length;

            if (count == 0)
            {
                throw new InvalidOperationException("No repositories available.");
            }

            if (count > 1)
            {
                throw new InvalidOperationException("Unable to resolve which repository to use, because there are more than one repository available.");
            }

            IRepository repository = repositories.Single();
            return repository;
        }
    }
}
