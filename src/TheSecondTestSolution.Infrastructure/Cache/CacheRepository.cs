using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Infrastructure.Cache
{
    internal class CacheRepository<T> : ICacheRepository<T> where T : class
    {
        private readonly IDistributedCache _distributedCache;

        public CacheRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task DeleteAsync(string key)
        {
            await _distributedCache.RemoveAsync(BuildKey<T>(key));
        }

        public async Task DeleteRangeAsync(string key)
        {
            await _distributedCache.RemoveAsync(BuildKey<IEnumerable<T>>(key));
        }

        public async Task<T?> GetAsync(string key)
        {
            string? value = await _distributedCache.GetStringAsync(BuildKey<T>(key));

            if (value == null)
            {
                return null;
            }

            return JsonSerializer.Deserialize<T>(value);
        }

        public async Task<IEnumerable<T>?> GetRangeAsync(string key)
        {
            string? value = await _distributedCache.GetStringAsync(BuildKey<IEnumerable<T>>(key));

            if (value == null)
            {
                return null;
            }

            return JsonSerializer.Deserialize<IEnumerable<T>>(value);
        }

        public async Task SetAsync(string key, T value, TimeSpan expire)
        {
            string strValue = JsonSerializer.Serialize(value);

            await _distributedCache.SetStringAsync(BuildKey<T>(key), strValue, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expire,
            });

        }

        public async Task SetRangeAsync(string key, IEnumerable<T> value, TimeSpan expire)
        {
            string strValue = JsonSerializer.Serialize(value);

            await _distributedCache.SetStringAsync(BuildKey<IEnumerable<T>>(key), strValue, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expire,
            });
        }

        private string BuildKey<TKey>(string key)
        {
            return $"{typeof(TKey).FullName}-{key}";
        }
    }
}
