using NewsFood.Core.Common.Parameter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Cache
{
    public interface IDistributedRedisCacheService
    {
        Task<TEntity> GetOrCreateAsync<TEntity>(CacheKey cacheKey, Func<Task<TEntity>> entity);

        bool Remove<T>(CacheKey cacheKey);

        Task<T> Get<T>(CacheKey cacheKey);
    }
}
