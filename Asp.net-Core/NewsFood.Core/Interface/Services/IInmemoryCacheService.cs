using NewsFood.Core.Common.Parameter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Services
{
    public interface IInmemoryCacheService
    {
        Task<TEntity> GetOrCreateAsync<TEntity>(CacheKey cacheKey, Func<Task<TEntity>> entity);

        void Remove<TEntity>(CacheKey cacheKey);
        
        TEntity Get<TEntity>(CacheKey cacheKey);
    }
}
