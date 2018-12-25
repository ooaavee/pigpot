using System.Threading.Tasks;

namespace Pigpot.Services
{
    public class GetSingle : RequestHandlerBase
    {
        private readonly IPigpot _service;

        public GetSingle(IPigpot service) : base(RequestType.GetSingle)
        {
            _service = service;
        }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var item = await _service.GetSingleAsync(context, key);
            return new JsonResponse(item);
        }
    }

    public class GetAll : RequestHandlerBase
    {
        private readonly IPigpot _service;

        public GetAll(IPigpot service) : base(RequestType.GetAll)
        {
            _service = service;
        }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var items = await _service.GetAllAsync(context);
            return new JsonResponse(items);
        }
    }

    public class AddSingle : RequestHandlerBase
    {
        private readonly IPigpot _service;

        public AddSingle(IPigpot service) : base(RequestType.AddSingle)
        {
            _service = service;
        }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var content = Content(context);
            var itemKey = await _service.AddAsync(context, key, content);
            return new KeyResponse(itemKey);
        }
    }

    public class UpdateSingle : RequestHandlerBase
    {
        private readonly IPigpot _service;

        public UpdateSingle(IPigpot service) : base(RequestType.UpdateSingle)
        {
            _service = service;
        }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var content = Content(context);
            var itemKey = await _service.UpdateAsync(context, key, content);
            return new KeyResponse(itemKey);
        }
    }

    public class AddOrUpdateSingle : RequestHandlerBase
    {
        private readonly IPigpot _service;

        public AddOrUpdateSingle(IPigpot service) : base(RequestType.AddOrUpdateSingle)
        {
            _service = service;
        }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var content = Content(context);
            var itemKey = await _service.AddOrUpdateAsync(context, key, content);
            return new KeyResponse(itemKey);
        }
    }

    public class DeleteSingle : RequestHandlerBase
    {
        private readonly IPigpot _service;

        public DeleteSingle(IPigpot service) : base(RequestType.DeleteSingle)
        {
            _service = service;
        }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var itemKey = await _service.DeleteAsync(context, key);
            return new KeyResponse(itemKey);
        }
    }
}
