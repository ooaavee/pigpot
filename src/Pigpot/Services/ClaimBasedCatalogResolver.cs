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

        public string GetCatalog(HttpContext context)
        {
            string catalog = null;

            if (context.User != null)
            {
                var names = new List<string>();

                foreach (Claim claim in context.User.Claims.Where(x => x.Type == _claimType))
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

                    catalog = names.Single();
                }
            }

            return catalog ?? _fallback.GetCatalog(context);
        }
    }
}
