#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using StackExchange.Redis;
using System.Text.Json;
namespace EJ2CoreSampleBrowser.Services
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _database;
        private readonly ISubscriber _subscriber;
        private readonly ILogger<RedisService> _logger;

        public RedisService(IConnectionMultiplexer redis, ILogger<RedisService> logger)
        {
            _database = redis.GetDatabase();
            _subscriber = redis.GetSubscriber();
            _logger = logger;
        }

        // Versioning
        public async Task<(bool accepted, long version)> CompareAndIncrementAsync(string key, long expectedVersion)
        {
            const string lua = @"
local v = redis.call('GET', KEYS[1])
if not v then
  v = 0
else
  v = tonumber(v) or 0
end

local expected = tonumber(ARGV[1]) or -1

if v == expected then
  local newv = redis.call('INCR', KEYS[1])
  return {1, newv}
else
  return {0, v}
end
";
            try
            {
                var result = (StackExchange.Redis.RedisResult[])await _database.ScriptEvaluateAsync(
                    lua,
                    keys: new StackExchange.Redis.RedisKey[] { key },
                    values: new StackExchange.Redis.RedisValue[] { expectedVersion.ToString() });

                bool accepted = (int)result[0] == 1;

                long version;
                if (result[1].Type == StackExchange.Redis.ResultType.Integer)
                    version = (long)result[1];
                else
                    version = long.Parse((string)result[1]);

                return (accepted, version);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompareAndIncrementAsync for key {Key}", key);
                long current = 0;
                try
                {
                    var raw = await _database.StringGetAsync(key);
                    if (raw.HasValue && long.TryParse(raw.ToString(), out var v))
                        current = v;
                }
                catch { }
                return (false, current);
            }
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            try
            {
                var value = await _database.StringGetAsync(key);
                return value.HasValue ? JsonSerializer.Deserialize<T>((string)value) : default;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting key {Key}", key);
                return default;
            }
        }

        public async Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            try
            {
                var serializedValue = JsonSerializer.Serialize(value);
                return await _database.StringSetAsync(key, serializedValue, expiry);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting key {Key}", key);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string key)
        {
            try
            {
                return await _database.KeyDeleteAsync(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting key {Key}", key);
                return false;
            }
        }

        public async Task<long> ListPushAsync<T>(string key, T value)
        {
            try
            {
                var serializedValue = JsonSerializer.Serialize(value);
                return await _database.ListLeftPushAsync(key, serializedValue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error pushing to list {Key}", key);
                return 0;
            }
        }

        public async Task<long> ListLengthAsync(string key)
        {
            try
            {
                return await _database.ListLengthAsync(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list length {Key}", key);
                return 0;
            }
        }

        public async Task<RedisValue[]> ListRangeAsync(string key, long start = 0, long stop = -1)
        {
            try
            {
                return await _database.ListRangeAsync(key, start, stop);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list range {Key}", key);
                return Array.Empty<RedisValue>();
            }
        }

        public async Task<bool> ListTrimAsync(string key, long start, long stop)
        {
            try
            {
                await _database.ListTrimAsync(key, start, stop);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trimming list {Key} start={Start} stop={Stop}", key, start, stop);
                return false;
            }
        }

        public async Task<List<T>> GetByPatternAsync<T>(string pattern)
        {
            var result = new List<T>();
            try
            {
                var endpoints = _database.Multiplexer.GetEndPoints();
                var server = _database.Multiplexer.GetServer(endpoints.First());

                // Get all keys matching the pattern
                var keys = server.Keys(pattern: pattern);

                foreach (var key in keys)
                {
                    var value = await _database.StringGetAsync(key);
                    if (value.HasValue)
                    {
                        var deserialized = JsonSerializer.Deserialize<T>((string)value);
                        if (deserialized != null)
                            result.Add(deserialized);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving keys with pattern {Pattern}", pattern);
            }

            return result;
        }
    }
}