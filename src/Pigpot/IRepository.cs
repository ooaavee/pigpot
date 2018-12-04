using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IRepository
    {
        Task<string> GetSingleAsync(Catalog catalog, PathString path, string key);
        Task<T> GetSingleAsync<T>(Catalog catalog, PathString path, string key);
        Task<IEnumerable<string>> GetAllAsync(Catalog catalog, PathString path);
        Task<IEnumerable<T>> GetAllAsync<T>(Catalog catalog, PathString path);
        Task<string> AddAsync(Catalog catalog, PathString path, string key, string content);
        Task<string> AddAsync<T>(Catalog catalog, PathString path, string key, T content);
        Task<string> UpdateAsync(Catalog catalog, PathString path, string key, string content);
        Task<T> UpdateAsync<T>(Catalog catalog, PathString path, string key, T content);
        Task<string> AddOrUpdateAsync(Catalog catalog, PathString path, string key, string content);
        Task<T> AddOrUpdateAsync<T>(Catalog catalog, PathString path, string key, T content);
        Task<string> DeleteAsync(Catalog catalog, PathString path, string key);
    }
}
