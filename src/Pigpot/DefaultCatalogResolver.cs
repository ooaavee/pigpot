using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Pigpot
{
    public class DefaultCatalogResolver : ICatalogResolver
    {
        private string _claimType;
        private string _fallback;
        private string _name;
        private DefaultCatalogResolverMode _mode;

        public static DefaultCatalogResolver AsClaimBasedCatalogResolver(string claimType, string fallback)
        {
            return new DefaultCatalogResolver
            {
                _mode = DefaultCatalogResolverMode.ClaimBased,
                _fallback = fallback,
                _claimType = claimType
            };
        }

        public static DefaultCatalogResolver AsFixedCatalogResolver(string name)
        {
            return new DefaultCatalogResolver
            {
                _mode = DefaultCatalogResolverMode.Fixed,
                _name = name
            };
        }

        public static DefaultCatalogResolver AsIdentityBasedCatalogResolver(string fallback)
        {
            return new DefaultCatalogResolver
            {
                _mode = DefaultCatalogResolverMode.IdentityBased,
                _fallback = fallback
            };
        }

        public Catalog Resolve(HttpContext context)
        {
            Catalog catalog = null;

            switch (_mode)
            {
                case DefaultCatalogResolverMode.Fixed:
                    {
                        catalog = new Catalog(_name);
                        break;

                    }

                case DefaultCatalogResolverMode.ClaimBased:
                    {
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

                        break;
                    }

                case DefaultCatalogResolverMode.IdentityBased:
                    {
                        if (context.User != null && context.User.Identity.IsAuthenticated)
                        {
                            catalog = new Catalog(context.User.Identity.Name);
                        }

                        break;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (catalog == null)
            {
                catalog = new Catalog(_fallback);
            }

            return catalog;
        }

        private enum DefaultCatalogResolverMode
        {
            Fixed,
            ClaimBased,
            IdentityBased
        }
    }

    /// <summary>
    /// Resolves catalogs by using the claim value.
    /// </summary>
    //public class ClaimBasedCatalogResolver : ICatalogResolver
    //{
    //    private readonly string _claimType;
    //    private readonly ICatalogResolver _fallback;

    //    public ClaimBasedCatalogResolver(string claimType, string fallback)
    //    {
    //        _claimType = claimType;
    //        _fallback = new FixedCatalogResolver(fallback);
    //    }

    //    public Catalog Resolve(HttpContext context)
    //    {
    //        Catalog catalog = null;

    //        if (context.User != null)
    //        {
    //            List<string> names = new List<string>();

    //            foreach (Claim claim in context.User.Claims.Where(claim => claim.Type == _claimType))
    //            {
    //                string name = claim.Value;

    //                if (!string.IsNullOrEmpty(name))
    //                {
    //                    if (!names.Contains(name))
    //                    {
    //                        names.Add(name);
    //                    }
    //                }
    //            }

    //            if (names.Any())
    //            {
    //                if (names.Count > 1)
    //                {
    //                    throw new InvalidOperationException("Found multiple catalog name candidates.");
    //                }

    //                string name = names.Single();

    //                catalog = new Catalog(name);
    //            }
    //        }

    //        if (catalog == null)
    //        {
    //            catalog = _fallback.Resolve(context);
    //        }

    //        return catalog;
    //    }
    //}


    /// <summary>
    /// Resolves catalogs by using the fixed catalog name.
    /// </summary>
    //public class FixedCatalogResolver : ICatalogResolver
    //{
    //    private readonly string _name;

    //    public FixedCatalogResolver(string name)
    //    {
    //        _name = name;
    //    }

    //    public Catalog Resolve(HttpContext context)
    //    {
    //        return new Catalog(_name);
    //    }
    //}

    /// <summary>
    /// Resolve catalogs by using the name of the current user.
    /// </summary>
    //public class IdentityBasedCatalogResolver : ICatalogResolver
    //{
    //    private readonly ICatalogResolver _fallback;

    //    public IdentityBasedCatalogResolver(string fallback)
    //    {
    //        _fallback = new FixedCatalogResolver(fallback);
    //    }

    //    public Catalog Resolve(HttpContext context)
    //    {
    //        Catalog catalog = null;

    //        if (context.User != null && context.User.Identity.IsAuthenticated)
    //        {
    //            catalog = new Catalog(context.User.Identity.Name);
    //        }

    //        if (catalog == null)
    //        {
    //            catalog = _fallback.Resolve(context);
    //        }

    //        return catalog;
    //    }
    //}

}
