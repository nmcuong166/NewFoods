using Microsoft.Extensions.Caching.Memory;
using NewsFood.Core.Common.Parameter;
using NewsFood.Core.Interface.Cache;
using System;
using System.Threading.Tasks;

namespace NewsFood.Infurstructure.Cache
{
    public class InMemoryCacheService : IInmemoryCacheService
    {
        private IMemoryCache _cache;

        public InMemoryCacheService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public TEntity Get<TEntity>(CacheKey cacheKey)
        {
            return _cache.Get<TEntity>(cacheKey);
        }

        public void Remove<TEntity>(CacheKey cacheKey)
        {
            _cache.Remove(cacheKey);
        }

        public async Task<TEntity> GetOrCreateAsync<TEntity>(CacheKey cacheKey, Func<Task<TEntity>> entity)
        { 
            var cacheEntry = await _cache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.Priority = CacheItemPriority.NeverRemove;
                return await entity();
            });
            return cacheEntry;
        }
    }
}
