using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public class PigpotService : IPigpot
    {
        public async Task<string> GetSingleAsync(Catalog catalog, PathString path, string key)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetSingleAsync<T>(Catalog catalog, PathString path, string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<string>> GetAllAsync(Catalog catalog, PathString path)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(Catalog catalog, PathString path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddAsync(Catalog catalog, PathString path, string key, string content)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddAsync<T>(Catalog catalog, PathString path, string key, T content)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateAsync(Catalog catalog, PathString path, string key, string content)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync<T>(Catalog catalog, PathString path, string key, T content)
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddOrUpdateAsync(Catalog catalog, PathString path, string key, string content)
        {
            throw new NotImplementedException();
        }

        public async Task<T> AddOrUpdateAsync<T>(Catalog catalog, PathString path, string key, T content)
        {
            throw new NotImplementedException();
        }

        public async Task<string> DeleteAsync(Catalog catalog, PathString path, string key)
        {
            throw new NotImplementedException();
        }
    }
}
