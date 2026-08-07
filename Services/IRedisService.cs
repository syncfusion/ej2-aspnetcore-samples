using StackExchange.Redis;

namespace EJ2CoreSampleBrowser.Services
{
    public interface IRedisService
    {
        Task<T?> GetAsync<T>(string key);
        Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task<bool> DeleteAsync(string key);
        Task<long> ListPushAsync<T>(string key, T value);
        Task<(bool accepted, long version)> CompareAndIncrementAsync(string key, long expectedVersion);
        Task<long> IncrementAsync(string key);
        Task<long> ListLengthAsync(string key);
        Task<RedisValue[]> ListRangeAsync(string key, long start = 0, long stop = -1);
        Task<bool> ListTrimAsync(string key, long start, long stop);
        Task<List<T>> GetByPatternAsync<T>(string pattern);
    }
}