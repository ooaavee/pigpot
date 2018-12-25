using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pigpot.Services
{
    public abstract class RequestHandlerBase : IRequestHandler
    {
        private const string RootPath = "/pigpot/api";

        private const string GenerateKeyParam = "keygen";
        private const string KeyParam = "key";
        private const string ForceParam = "force";

        protected RequestType Type { get; }

        protected RequestHandlerBase(RequestType type)
        {  
            Type = type;
        }

        public bool CanHandle(HttpRequest request, out string path)
        {
            path = null;

            if (request.Path.StartsWithSegments(RootPath))
            {
                if (IsRequestType(request, Type))
                {
                    path = request.Path.Value.Substring(RootPath.Length);
                }
            }

            return path != null;
        }

        public async Task HandleAsync(IRequestContext context)
        {
            IRequestHandlerResponse response;

            try
            {
                response = await OnHandleAsync(context);
            }
            catch (Exception e)
            {
                response = new ErrorResponse(e);
            }

            await response.WriteAsync(context.HttpContext.Response);
        }

        protected abstract Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context);

        protected static string Key(IRequestContext context)
        {
            var key = GetFirstValue(context.HttpContext.Request, KeyParam);
            if (key == null && UseKeyGen(context.HttpContext.Request))
            {
                key = Guid.NewGuid().ToString();
            }
            return key;
        }

        protected static string Content(IRequestContext context)
        {
            using (var reader = new StreamReader(context.HttpContext.Request.Body))
            {
                return reader.ReadToEnd();
            }
        }

        private static bool IsRequestType(HttpRequest request, RequestType wanted)
        {
            string method = request.Method;

            RequestType current = RequestType.Unknown;

            if (method == HttpMethods.Get)
            {
                current = HasKey(request) ? RequestType.GetSingle : RequestType.GetAll;
            }
            else if (method == HttpMethods.Post)
            {
                if (HasKey(request) || UseKeyGen(request))
                {
                    current = RequestType.AddSingle;
                }
            }
            else if (method == HttpMethods.Put)
            {
                if (HasKey(request))
                {
                    current = IsForceSave(request) ? RequestType.AddOrUpdateSingle : RequestType.UpdateSingle;
                }
            }
            else if (method == HttpMethods.Delete)
            {
                if (HasKey(request))
                {
                    current = RequestType.DeleteSingle;
                }
            }

            return current == wanted;
        }

        private static bool HasKey(HttpRequest request)
        {
            var value = GetFirstValue(request, KeyParam);
            return value != null;
        }

        private static bool IsForceSave(HttpRequest request)
        {
            var value = GetFirstValue(request, ForceParam);
            return value != null && value.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool UseKeyGen(HttpRequest request)
        {
            var value = GetFirstValue(request, GenerateKeyParam);
            return value != null && value.Equals(bool.TrueString, StringComparison.InvariantCultureIgnoreCase);
        }

        private static string GetFirstValue(HttpRequest request, string key)
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

        public interface IRequestHandlerResponse
        {
            Task WriteAsync(HttpResponse response);
        }

        public class ErrorResponse : IRequestHandlerResponse
        {
            public ErrorResponse(Exception e)
            {
                // TODO: riippuen exceptionin tyypistä voidaan antaa eri paluukoodi!
            }

            public async Task WriteAsync(HttpResponse response)
            {
                response.ContentType = "text/plain";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsync("An unhandled exception occured. Please check your application logs for more details.", Encoding.UTF8);
            }
        }

        public class KeyResponse : IRequestHandlerResponse
        {
            private readonly string _content;

            public KeyResponse(string key)
            {
                _content = JsonConvert.SerializeObject(new KeyWrapper {Key = key}, Formatting.Indented);
            }

            public async Task WriteAsync(HttpResponse response)
            {
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.OK;
                await response.WriteAsync(_content, Encoding.UTF8);
            }

            private class KeyWrapper
            {
                [JsonProperty("key")]
                public string Key { get; set; }
            }
        }

        public class JsonResponse : IRequestHandlerResponse
        {
            private readonly string _content;

            public JsonResponse(string content)
            {
                if (!string.IsNullOrEmpty(content))
                {
                    _content = JObject.Parse(content).ToString(Formatting.Indented);
                }
            }

            public JsonResponse(IEnumerable<string> content)
            {
                var items = new JArray(content.Select(item => (JObject)JsonConvert.DeserializeObject(item)).Cast<object>().ToArray());

                _content = items.ToString(Formatting.Indented);
            }

            public async Task WriteAsync(HttpResponse response)
            {
                if (_content != null)
                {
                    response.ContentType = "application/json";
                    response.StatusCode = (int)HttpStatusCode.OK;
                    await response.WriteAsync(_content, Encoding.UTF8);
                }
                else
                {
                    response.ContentType = "text/plain";
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    await response.WriteAsync("No data found.", Encoding.UTF8);
                }
            }
        }
    }
}