using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pigpot.Services
{
    public class PigpotService : IPigpot
    {
        private readonly IEnumerable<IRepository> _repositories;
        private readonly IRepositoryFilter _repositoryFilter;
        private readonly IRequestContextFactory _contextFactory;

        public PigpotService(IEnumerable<IRepository> repositories, IRepositoryFilter repositoryFilter, IRequestContextFactory contextFactory)
        {
            _repositories = repositories;
            _repositoryFilter = repositoryFilter;
            _contextFactory = contextFactory;
        }

        private IRepository Repository(IRequestContext context)
        {
            return _repositoryFilter.Filter(context.Catalog, context.Path, _repositories);
        }

        private IRequestContext Context(string path, string catalog = null)
        {
            return catalog != null
                ? _contextFactory.CreateRequestContext(path, catalog)
                : _contextFactory.CreateRequestContext(path);
        }

        public async Task<string> GetSingleAsync(string path, string key)
        {
            return await GetSingleAsync(Context(path), key);
        }

        public async Task<string> GetSingleAsync(string path, string catalog, string key)
        {
            return await GetSingleAsync(Context(path), key);
        }

        public async Task<T> GetSingleAsync<T>(string path, string key)
        {
            return await GetSingleAsync<T>(Context(path), key);
        }

        public async Task<T> GetSingleAsync<T>(string path, string catalog, string key)
        {
            return await GetSingleAsync<T>(Context(path), key);
        }

        public async Task<string> GetSingleAsync(IRequestContext context, string key)
        {
            return await Repository(context).GetSingleAsync(context, key);
        }

        public async Task<T> GetSingleAsync<T>(IRequestContext context, string key)
        {           
            return await Repository(context).GetSingleAsync<T>(context, key);
        }

        public async Task<IEnumerable<string>> GetAllAsync(string path)
        {
            return await GetAllAsync(Context(path));
        }

        public async Task<IEnumerable<string>> GetAllAsync(string path, string catalog)
        {
            return await GetAllAsync(Context(path));
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string path)
        {
            return await GetAllAsync<T>(Context(path));
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string path, string catalog)
        {
            return await GetAllAsync<T>(Context(path));
        }

        public async Task<IEnumerable<string>> GetAllAsync(IRequestContext context)
        {          
            return await Repository(context).GetAllAsync(context);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(IRequestContext context)
        {
            return await Repository(context).GetAllAsync<T>(context);
        }

        public async Task<string> AddAsync(string path, string key, string content)
        {
            return await AddAsync(Context(path), key, content);
        }

        public async Task<string> AddAsync(string path, string catalog, string key, string content)
        {
            return await AddAsync(Context(path), key, content);
        }

        public async Task<string> AddAsync<T>(string path, string key, T content)
        {
            return await AddAsync<T>(Context(path), key, content);
        }

        public async Task<string> AddAsync<T>(string path, string catalog, string key, T content)
        {
            return await AddAsync<T>(Context(path), key, content);
        }

        public async Task<string> AddAsync(IRequestContext context, string key, string content)
        {
            return await Repository(context).AddAsync(context, key, content);
        }

        public async Task<string> AddAsync<T>(IRequestContext context, string key, T content)
        {
            return await Repository(context).AddAsync<T>(context, key, content);
        }

        public async Task<string> UpdateAsync(string path, string key, string content)
        {
            return await UpdateAsync(Context(path), key, content);
        }

        public async Task<string> UpdateAsync(string path, string catalog, string key, string content)
        {
            return await UpdateAsync(Context(path), key, content);
        }

        public async Task<string> UpdateAsync<T>(string path, string key, T content)
        {          
            return await UpdateAsync<T>(Context(path), key, content);
        }

        public async Task<string> UpdateAsync<T>(string path, string catalog, string key, T content)
        {
            return await UpdateAsync<T>(Context(path), key, content);
        }

        public async Task<string> UpdateAsync(IRequestContext context, string key, string content)
        {
            return await Repository(context).UpdateAsync(context, key, content);
        }

        public async Task<string> UpdateAsync<T>(IRequestContext context, string key, T content)
        {
            return await Repository(context).UpdateAsync<T>(context, key, content);
        }

        public async Task<string> AddOrUpdateAsync(string path, string key, string content)
        {
            return await AddOrUpdateAsync(Context(path), key, content);
        }

        public async Task<string> AddOrUpdateAsync(string path, string catalog, string key, string content)
        {
            return await AddOrUpdateAsync(Context(path), key, content);
        }

        public async Task<string> AddOrUpdateAsync<T>(string path, string key, T content)
        {
            return await AddOrUpdateAsync<T>(Context(path), key, content);
        }

        public async Task<string> AddOrUpdateAsync<T>(string path, string catalog, string key, T content)
        {
            return await AddOrUpdateAsync<T>(Context(path), key, content);
        }

        public async Task<string> AddOrUpdateAsync(IRequestContext context, string key, string content)
        {
            return await Repository(context).AddOrUpdateAsync(context, key, content);
        }

        public async Task<string> AddOrUpdateAsync<T>(IRequestContext context, string key, T content)
        {
            return await Repository(context).AddOrUpdateAsync<T>(context, key, content);
        }

        public async Task<string> DeleteAsync(string path, string key)
        {
            return await DeleteAsync(Context(path), key);
        }

        public async Task<string> DeleteAsync(string path, string catalog, string key)
        {
            return await DeleteAsync(Context(path), key);
        }

        public async Task<string> DeleteAsync(IRequestContext context, string key)
        {
            return await Repository(context).DeleteAsync(context, key);
        }
    }
}
