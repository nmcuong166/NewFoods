using Microsoft.Extensions.Caching.Distributed;
using NewsFood.Core.Common.Extension;
using NewsFood.Core.Common.Parameter;
using NewsFood.Core.Interface.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Infurstructure.Cache
{
    public class DistributedRedisCacheService : IDistributedRedisCacheService
    {
        private readonly IDistributedCache _distributedCache;
        public DistributedRedisCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> Get<T>(CacheKey cacheKey)
        {
            var isExistCacheKey = await _distributedCache.GetAsync(cacheKey.GetStringValue());
            return isExistCacheKey.DeserializeByteArrayToObject<T>();
        }

        public async Task<T> GetOrCreateAsync<T>(CacheKey cacheKey, Func<Task<T>> source)
        {
            var isExistCacheKey = await _distributedCache.GetStringAsync(cacheKey.GetStringValue());
            if (isExistCacheKey == null)
            {
                var data = await source.Invoke();
                await _distributedCache.SetStringAsync(cacheKey.GetStringValue(), JsonConvert.SerializeObject(data));
                return data;
            }
            return JsonConvert.DeserializeObject<T>(await _distributedCache.GetStringAsync(cacheKey.GetStringValue()));
        }

        public bool Remove<T>(CacheKey cacheKey)
        {
            var task = _distributedCache.RemoveAsync(cacheKey.GetStringValue());
            if (!task.IsCompleted)
            {
                
            }
            return true;
        }
    }
}
