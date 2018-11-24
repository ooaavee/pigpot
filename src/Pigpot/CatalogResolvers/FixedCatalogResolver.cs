using Microsoft.AspNetCore.Http;

namespace Pigpot.CatalogResolvers
{
    /// <summary>
    /// Resolve catalogs by using the fixed catalog name.
    /// </summary>
    public class FixedCatalogResolver : ICatalogResolver
    {
        private readonly string _name;

        public FixedCatalogResolver(string name)
        {
            _name = name;
        }

        public Catalog Resolve(HttpContext context)
        {
            return new Catalog(_name);
        }
    }
}
