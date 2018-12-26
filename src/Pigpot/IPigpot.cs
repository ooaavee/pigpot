using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IPigpot
    {
        // get single
        Task<string> GetSingleAsync(string path, string key);
        Task<string> GetSingleAsync(string path, string catalog, string key);
        Task<T> GetSingleAsync<T>(string path, string key);
        Task<T> GetSingleAsync<T>(string path, string catalog, string key);
        Task<string> GetSingleAsync(IRequestContext context, string key);
        Task<T> GetSingleAsync<T>(IRequestContext context, string key);

        // get all
        Task<IEnumerable<string>> GetAllAsync(string path);
        Task<IEnumerable<string>> GetAllAsync(string path, string catalog);
        Task<IEnumerable<T>> GetAllAsync<T>(string path);
        Task<IEnumerable<T>> GetAllAsync<T>(string path, string catalog);
        Task<IEnumerable<string>> GetAllAsync(IRequestContext context);
        Task<IEnumerable<T>> GetAllAsync<T>(IRequestContext context);

        // add single
        Task<string> AddAsync(string path, string key, string content);
        Task<string> AddAsync(string path, string catalog, string key, string content);
        Task<string> AddAsync<T>(string path, string key, T content);
        Task<string> AddAsync<T>(string path, string catalog, string key, T content);
        Task<string> AddAsync(IRequestContext context, string key, string content);
        Task<string> AddAsync<T>(IRequestContext context, string key, T content);

        // update single
        Task<string> UpdateAsync(string path, string key, string content);
        Task<string> UpdateAsync(string path, string catalog, string key, string content);
        Task<string> UpdateAsync<T>(string path, string key, T content);
        Task<string> UpdateAsync<T>(string path, string catalog, string key, T content);
        Task<string> UpdateAsync(IRequestContext context, string key, string content);
        Task<string> UpdateAsync<T>(IRequestContext context, string key, T content);

        // add or update single
        Task<string> AddOrUpdateAsync(string path, string key, string content);
        Task<string> AddOrUpdateAsync(string path, string catalog, string key, string content);
        Task<string> AddOrUpdateAsync<T>(string path, string key, T content);
        Task<string> AddOrUpdateAsync<T>(string path, string catalog, string key, T content);
        Task<string> AddOrUpdateAsync(IRequestContext context, string key, string content);
        Task<string> AddOrUpdateAsync<T>(IRequestContext context, string key, T content);

        // delete single
        Task<string> DeleteAsync(string path, string key);
        Task<string> DeleteAsync(string path, string catalog, string key);
        Task<string> DeleteAsync(IRequestContext context, string key);
    }
}