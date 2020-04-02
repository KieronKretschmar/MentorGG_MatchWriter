using MatchEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchWriter
{
    public interface IMatchRedis
    {
        Task<MatchDataSet> GetMatch(string key);
        Task DeleteMatch(string redisKey);
    }

    /// <summary>
    /// Communicates with the redis cache that stores MatchDataSets
    /// </summary>
    public class MatchRedis : IMatchRedis
    {
        private readonly ILogger<MatchRedis> _logger;
        private IDatabase cache;

        public MatchRedis(ILogger<MatchRedis> logger, IConnectionMultiplexer connectionMultiplexer)
        {
            _logger = logger;
            cache = connectionMultiplexer.GetDatabase();
        }

        /// <summary>
        /// Attempts to load a MatchDataSet from redis.
        /// 
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<MatchDataSet> GetMatch(string key)
        {
            _logger.LogInformation($"Attempting to load match with key {key} from redis.");
            var response = await cache.StringGetAsync(key).ConfigureAwait(false);
            var match = MatchDataSet.FromJson(response.ToString());

            _logger.LogInformation($"Succesfully loaded Match with key {key} from redis.");
            return match;
        }

        public async Task DeleteMatch(string redisKey)
        {
            _logger.LogInformation($"Attempting to delete key [ {redisKey} ]");
            await cache.KeyDeleteAsync(redisKey).ConfigureAwait(false);
            _logger.LogInformation($"Deleted key [ {redisKey} ] from RedisCache");
        }
    }

    public class MockRedis : IMatchRedis
    {
        /// <summary>
        /// Do nothing
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public Task DeleteMatch(string redisKey)
        {
            return Task.CompletedTask;
        }

        public async Task<MatchDataSet> GetMatch(string key)
        {
            return new MatchDataSet();
        }
    }
}
