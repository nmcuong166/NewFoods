using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NewsFood.Core.Common.Extension;
using NewsFood.Core.Common.Parameter;
using NewsFood.Core.Interface.Cache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace NewsFood.Infurstructure.Cache
{
    public class DistributedRedisCacheService : IDistributedRedisCacheService
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ILogger _logger;
        public DistributedRedisCacheService(IDistributedCache distributedCache, ILogger logger)
        {
            _distributedCache = distributedCache;
            _logger = logger;
        }

        public async Task<T> Get<T>(CacheKey cacheKey)
        {
            var isExistCacheKey = await _distributedCache.GetAsync(cacheKey.GetStringValue());
            return isExistCacheKey.DeserializeByteArrayToObject<T>();
        }

        public async Task<T> GetOrCreateAsync<T>(CacheKey cacheKey, Func<Task<T>> source)
        {
            var taskExistCacheKey = _distributedCache.GetStringAsync(cacheKey.GetStringValue());

            await Task.WhenAny(taskExistCacheKey);

            if (taskExistCacheKey.IsFaulted)
            {
                _logger.LogInformation("Task in GetOrCreateAsync on DistributedRedisCacheService {0}", taskExistCacheKey.Status.ToString());
                return await source.Invoke();
            }
            else
            {
               if (taskExistCacheKey.Result == null)
                {
                    var data = await source.Invoke();
                    await _distributedCache.SetStringAsync(cacheKey.GetStringValue(), JsonConvert.SerializeObject(data));
                    return data;
                }
                return JsonConvert.DeserializeObject<T>(taskExistCacheKey.Result);
            }
        }

        public bool Remove<T>(CacheKey cacheKey)
        {
            var task = _distributedCache.RemoveAsync(cacheKey.GetStringValue());
            task.Wait();

            if (task.IsFaulted || task.IsCanceled)
            {
                return false;
            }
            return true;
        }
    }
}
