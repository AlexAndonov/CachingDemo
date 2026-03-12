using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CachingDemo.Services.Caching
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache cache;

        public RedisCacheService(IDistributedCache _cache)
        {
              cache = _cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var cachedData = await cache.GetStringAsync(key);

            if (cachedData == null)
                return default;

            return JsonSerializer.Deserialize<T>(cachedData);
        }

        public async Task RemoveAsync(string key)
        {
            await cache.RemoveAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            await cache.SetStringAsync(
                key,
                JsonSerializer.Serialize(value),
                options);
        }
    }
}
