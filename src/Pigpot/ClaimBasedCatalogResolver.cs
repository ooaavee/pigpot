using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Pigpot
{
    /// <summary>
    /// Resolves catalogs by using the claim value.
    /// </summary>
    public class ClaimBasedCatalogResolver : ICatalogResolver
    {
        private readonly string _claimType;
        private readonly ICatalogResolver _fallback;

        public ClaimBasedCatalogResolver(string claimType, ICatalogResolver fallback)
        {
            _claimType = claimType;
            _fallback = fallback;
        }

        public ClaimBasedCatalogResolver(string claimType, string fallback)
        {
            _claimType = claimType;
            _fallback = new FixedCatalogResolver(fallback);
        }

        public Catalog Resolve(HttpContext context)
        {
            Catalog catalog = null;

            if (context.User != null)
            {
                List<string> names = new List<string>();

                foreach (Claim claim in context.User.Claims.Where(claim => claim.Type == _claimType))
                {
                    string name = claim.Value;

                    if (!string.IsNullOrEmpty(name))
                    {
                        if (!names.Contains(name))
                        {
                            names.Add(name);
                        }
                    }
                }

                if (names.Any())
                {
                    if (names.Count > 1)
                    {
                        throw new InvalidOperationException("Found multiple catalog name candidates.");
                    }

                    string name = names.Single();

                    catalog = new Catalog(name);
                }
            }

            if (catalog == null)
            {
                catalog = _fallback.Resolve(context);
            }

            return catalog;
        }
    }
}
