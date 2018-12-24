using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Pigpot
{
    public interface IRequestHandler
    {       
        bool Accept(HttpRequest request, out PathString path);

        Task HandleAsync(IRequestContext context);
    }
}
