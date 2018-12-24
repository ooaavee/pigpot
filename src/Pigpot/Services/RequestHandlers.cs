using System.Threading.Tasks;

namespace Pigpot.Services
{
    public class GetSingle : RequestHandlerBase
    {
        public GetSingle(IPigpot service) : base(service, RequestType.GetSingle) { }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var item = await Service.GetSingleAsync(context, key);
            return new JsonResponse(item);
        }
    }

    public class GetAll : RequestHandlerBase
    {
        public GetAll(IPigpot service) : base(service, RequestType.GetAll) { }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var items = await Service.GetAllAsync(context);
            return new JsonResponse(items);
        }
    }

    public class AddSingle : RequestHandlerBase
    {
        public AddSingle(IPigpot service) : base(service, RequestType.AddSingle) { }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var content = Content(context);
            var itemKey = await Service.AddAsync(context, key, content);
            return new KeyResponse(itemKey);
        }
    }

    public class UpdateSingle : RequestHandlerBase
    {
        public UpdateSingle(IPigpot service) : base(service, RequestType.UpdateSingle) { }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var content = Content(context);
            var itemKey = await Service.UpdateAsync(context, key, content);
            return new KeyResponse(itemKey);
        }
    }

    public class AddOrUpdateSingle : RequestHandlerBase
    {
        public AddOrUpdateSingle(IPigpot service) : base(service, RequestType.AddOrUpdateSingle) { }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var content = Content(context);
            var itemKey = await Service.AddOrUpdateAsync(context, key, content);
            return new KeyResponse(itemKey);
        }
    }

    public class DeleteSingle : RequestHandlerBase
    {
        public DeleteSingle(IPigpot service) : base(service, RequestType.DeleteSingle) { }

        protected override async Task<IRequestHandlerResponse> OnHandleAsync(IRequestContext context)
        {
            var key = Key(context);
            var itemKey = await Service.DeleteAsync(context, key);
            return new KeyResponse(itemKey);
        }
    }
}
