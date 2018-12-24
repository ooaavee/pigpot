using Microsoft.AspNetCore.Http;

namespace Pigpot.Services
{
    /// <summary>
    /// Resolves catalogs by using the fixed catalog name.
    /// </summary>
    public class FixedCatalogResolver : ICatalogResolver
    {
        private readonly string _name;

        public FixedCatalogResolver(string name)
        {
            _name = name;
        }

        public ICatalog Resolve(HttpContext context)
        {
            return new Catalog(_name);
        }
    }
}
