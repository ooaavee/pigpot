using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IRequestContext
    {
        /// <summary>
        /// The current HTTP context
        /// </summary>
        HttpContext HttpContext { get; }

        /// <summary>
        /// The current catalog
        /// </summary>
        string Catalog { get; }

        /// <summary>
        /// The current path
        /// </summary>
        string Path { get; }
    }
}