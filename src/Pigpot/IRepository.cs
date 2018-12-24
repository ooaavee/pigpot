using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Pigpot
{
    public interface IRepository
    {
        Task<string> GetSingleAsync(IRequestContext context, string key);
        Task<T> GetSingleAsync<T>(IRequestContext context, string key);

        Task<IEnumerable<string>> GetAllAsync(IRequestContext context);
        Task<IEnumerable<T>> GetAllAsync<T>(IRequestContext context);

        Task<string> AddAsync(IRequestContext context, string key, string content);
        Task<string> AddAsync<T>(IRequestContext context, string key, T content);

        Task<string> UpdateAsync(IRequestContext context, string key, string content);
        Task<string> UpdateAsync<T>(IRequestContext context, string key, T content);

        Task<string> AddOrUpdateAsync(IRequestContext context, string key, string content);
        Task<string> AddOrUpdateAsync<T>(IRequestContext context, string key, T content);

        Task<string> DeleteAsync(IRequestContext context, string key);
    }
}
