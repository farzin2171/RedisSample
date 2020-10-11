using System.Threading.Tasks;

namespace Redis.Demo.Services
{
    public interface ICachService
    {
        Task<string> GetCacheValueAsync(string key);
        Task SetCacheValueAsync(string key, string value);
    }
}
