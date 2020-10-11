using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Redis.Demo.Services
{
    public class InMemoryCacheService : ICachService
    {
        private readonly MemoryCache _cash = new MemoryCache(new MemoryCacheOptions());
        public Task<string> GetCacheValueAsync(string key)
        {
            return Task.FromResult(_cash.Get<string>(key));
        }

        public Task SetCacheValueAsync(string key, string value)
        {
            _cash.Set(key, value);
            return Task.CompletedTask;
        }
    }
}
