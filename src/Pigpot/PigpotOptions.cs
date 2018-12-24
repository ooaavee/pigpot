using System;
using System.Collections.Generic;
using Pigpot.Services;

namespace Pigpot
{
    public class PigpotOptions
    {
        public Type RequestContextFactoryType { get; set; } = typeof(DefaultRequestContextFactory);

        public Type CatalogResoverType { get; set; } = typeof(DefaultCatalogResolver);

        public Type RepositoryFilterType { get; set; } = typeof(DefaultRepositoryFilter);

        public Type PigpotServiceType { get; set; } = typeof(PigpotService);

        public bool AddHttpContextAccessor { get; set; } = true;

        public List<Type> RequestHandlerTypes { get; set; } = new List<Type>(new[]
        {
            typeof(GetSingle),
            typeof(GetAll),
            typeof(AddSingle),
            typeof(UpdateSingle),
            typeof(AddOrUpdateSingle),
            typeof(DeleteSingle)
        });       
    }
}
