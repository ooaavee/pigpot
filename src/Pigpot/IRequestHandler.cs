using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Pigpot
{
    public interface IRequestHandler
    {       
        bool CanHandle(HttpRequest request, out string path);

        Task HandleAsync(IRequestContext context);
    }
}
