using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pigpot.Services
{
    public class PigpotService : IPigpot
    {
        private readonly IEnumerable<IRepository> _repositories;
        private readonly IRepositoryFilter _repositoryFilter;

        public PigpotService(IEnumerable<IRepository> repositories, IRepositoryFilter repositoryFilter)
        {
            _repositories = repositories;
            _repositoryFilter = repositoryFilter;
        }

        private IRepository GetRepository(IRequestContext context)
        {
            return _repositoryFilter.Filter(context.Catalog, context.Path, _repositories);
        }

        public async Task<string> GetSingleAsync(IRequestContext context, string key)
        {
            IRepository repository = GetRepository(context);
            string response = await repository.GetSingleAsync(context, key);
            return response;
        }

        public async Task<T> GetSingleAsync<T>(IRequestContext context, string key)
        {
            IRepository repository = GetRepository(context);
            T response = await repository.GetSingleAsync<T>(context, key);
            return response;
        }

        public async Task<IEnumerable<string>> GetAllAsync(IRequestContext context)
        {
            IRepository repository = GetRepository(context);
            IEnumerable<string> response = await repository.GetAllAsync(context);
            return response;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(IRequestContext context)
        {
            IRepository repository = GetRepository(context);
            IEnumerable<T> response = await repository.GetAllAsync<T>(context);
            return response;
        }

        public async Task<string> AddAsync(IRequestContext context, string key, string content)
        {
            IRepository repository = GetRepository(context);
            string response = await repository.AddAsync(context, key, content);
            return response;
        }

        public async Task<string> AddAsync<T>(IRequestContext context, string key, T content)
        {
            IRepository repository = GetRepository(context);
            string response = await repository.AddAsync<T>(context, key, content);
            return response;
        }

        public async Task<string> UpdateAsync(IRequestContext context, string key, string content)
        {
            IRepository repository = GetRepository(context);
            string response = await repository.UpdateAsync(context, key, content);
            return response;
        }

        public async Task<string> UpdateAsync<T>(IRequestContext context, string key, T content)
        {
            IRepository repository = GetRepository(context);
            string response = await repository.UpdateAsync<T>(context, key, content);
            return response;
        }

        public async Task<string> AddOrUpdateAsync(IRequestContext context, string key, string content)
        {
            IRepository repository = GetRepository(context);
            string response = await repository.AddOrUpdateAsync(context, key, content);
            return response;
        }

        public async Task<string> AddOrUpdateAsync<T>(IRequestContext context, string key, T content)
        {
            IRepository repository = GetRepository(context);
            string response = await repository.AddOrUpdateAsync<T>(context, key, content);
            return response;
        }

        public async Task<string> DeleteAsync(IRequestContext context, string key)
        {
            IRepository repository = GetRepository(context);
            string response = await repository.DeleteAsync(context, key);
            return response;
        }
    }
}
