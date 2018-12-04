using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Pigpot
{
    public class AddOrUpdateSingle : RequestHandlerBase
    {
        public AddOrUpdateSingle() : base(RequestType.AddOrUpdateSingle)
        {
        }

        public override async Task<object> HandleAsync(RequestContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class AddSingle : RequestHandlerBase
    {
        public AddSingle() : base(RequestType.AddSingle)
        {
        }

        public override async Task<object> HandleAsync(RequestContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class DeleteSingle : RequestHandlerBase
    {
        public DeleteSingle() : base(RequestType.DeleteSingle) { }

        public override async Task<object> HandleAsync(RequestContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class GetAll : RequestHandlerBase
    {
        public GetAll() : base(RequestType.GetAll)
        {
        }

        public override async Task<object> HandleAsync(RequestContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class GetSingle : RequestHandlerBase
    {
        public GetSingle() : base(RequestType.GetSingle)
        {
        }

        public override async Task<object> HandleAsync(RequestContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class UpdateSingle : RequestHandlerBase
    {
        public UpdateSingle() : base(RequestType.UpdateSingle)
        {
        }

        public override async Task<object> HandleAsync(RequestContext context)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class RequestHandlerBase : IRequestHandler
    {
        private const string RootPath = "/pigpot/api/";
        private const string GenerateKey = "keygen";
        private const string Key = "key";
        private const string Force = "force";

        private readonly RequestType _requestType;

        protected RequestHandlerBase(RequestType requestType)
        {
            _requestType = requestType;
        }

        public bool CanHandle(HttpRequest request)
        {
            return request.Path.StartsWithSegments(RootPath) && IsRequestTypeMatch(request, _requestType);
        }

        public abstract Task<object> HandleAsync(RequestContext context);

        protected virtual IRequestKey GetKey(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        protected virtual PathString GetPath(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        protected string GetContent(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        private static bool IsRequestTypeMatch(HttpRequest request, RequestType requestType)
        {
            RequestType result = RequestType.Unknown;

            if (request.Method == HttpMethods.Get)
            {
                result = HasKey(request) ? 
                    RequestType.GetSingle : 
                    RequestType.GetAll;
            }

            if (request.Method == HttpMethods.Post)
            {
                if (HasKey(request) || UseKeyGenerator(request))
                {
                    result = RequestType.AddSingle;
                }
            }

            if (request.Method == HttpMethods.Put)
            {
                if (HasKey(request))
                {
                    result = IsForceSave(request) ? 
                        RequestType.AddOrUpdateSingle : 
                        RequestType.UpdateSingle;
                }
            }

            if (request.Method == HttpMethods.Delete)
            {
                if (HasKey(request))
                {
                    result = RequestType.DeleteSingle;
                }
            }

            return result == requestType;
        }

        private static bool HasKey(HttpRequest request)
        {

            return false;
        }

        private static bool IsForceSave(HttpRequest request)
        {
            // force = true
            return false;
        }

        private static bool UseKeyGenerator(HttpRequest request)
        {
            string value = GetFirstValueOrNull(request, GenerateKey);
            if (value != null)
            {
                if (value.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

       

        private static string GetFirstValueOrNull(HttpRequest request, string key)
        {
            if (request.Query.TryGetValue(key, out StringValues values))
            {
                foreach (string value in values)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        return value;
                    }
                }
            }
            return null;
        }

        public enum RequestType
        {
            Unknown,
            GetSingle,
            GetAll,
            AddSingle,
            UpdateSingle,
            AddOrUpdateSingle,
            DeleteSingle
        }

    }
}
