using System.Collections.Generic;
using System.Threading.Tasks;
using Pigpot.Azure;

namespace Pigpot.Services
{
    public class AzureBlobRepository : IRepository
    {
        private readonly IAzureBlobStorage _storage;

        public AzureBlobRepository(IAzureBlobStorage storage)
        {
            _storage = storage;
        }

        public Task<string> GetSingleAsync(IRequestContext context, string key)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetSingleAsync<T>(IRequestContext context, string key)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetAllAsync(IRequestContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync<T>(IRequestContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> AddAsync(IRequestContext context, string key, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> AddAsync<T>(IRequestContext context, string key, T content)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateAsync(IRequestContext context, string key, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateAsync<T>(IRequestContext context, string key, T content)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> AddOrUpdateAsync(IRequestContext context, string key, string content)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> AddOrUpdateAsync<T>(IRequestContext context, string key, T content)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> DeleteAsync(IRequestContext context, string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
