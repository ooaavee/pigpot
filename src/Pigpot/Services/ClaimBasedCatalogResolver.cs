using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Pigpot.Services
{
    /// <summary>
    /// Resolves catalogs by using the claim value.
    /// </summary>
    public class ClaimBasedCatalogResolver : ICatalogResolver
    {
        private readonly string _claimType;
        private readonly ICatalogResolver _fallback;

        public ClaimBasedCatalogResolver(string claimType, string fallback)
        {
            _claimType = claimType;
            _fallback = new FixedCatalogResolver(fallback);
        }

        public ICatalog Resolve(HttpContext context)
        {
            ICatalog catalog = null;

            if (context.User != null)
            {
                var names = new List<string>();

                foreach (Claim claim in context.User.Claims.Where(claim => claim.Type == _claimType))
                {
                    if (!string.IsNullOrEmpty(claim.Value))
                    {
                        if (!names.Contains(claim.Value))
                        {
                            names.Add(claim.Value);
                        }
                    }
                }

                if (names.Any())
                {
                    if (names.Count > 1)
                    {
                        throw new InvalidOperationException("Found multiple catalog name candidates.");
                    }

                    catalog = new Catalog(names.Single());
                }
            }

            return catalog ?? _fallback.Resolve(context);
        }
    }
}
