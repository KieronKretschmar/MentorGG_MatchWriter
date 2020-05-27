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
    }

    /// <summary>
    /// Communicates with the redis cache that stores MatchDataSets
    /// </summary>
    public class MatchRedis : IMatchRedis
    {
        private readonly ILogger<MatchRedis> _logger;
        private IDatabase cache;

        public MatchRedis(
            ILogger<MatchRedis> logger,
            IConnectionMultiplexer connectionMultiplexer)
        {
            _logger = logger;
            cache = connectionMultiplexer.GetDatabase();
        }

        /// <summary>
        /// Attempts to load a MatchDataSet from redis.
        /// 
        /// </summary>
        /// <param name="key">Redis key</param>
        /// <returns></returns>
        public async Task<MatchDataSet> GetMatch(string key)
        {
            _logger.LogDebug($"Attempting to load match with key [ {key} from redis.");
            var response = await cache.StringGetAsync(key).ConfigureAwait(false);

            if (response.IsNullOrEmpty){
                throw new MatchEmptyOrNull($"Received NULL value from Redis for key [ {key} ]");
            }

            var match = MatchDataSet.FromJson(response.ToString());

            _logger.LogDebug($"Succesfully loaded Match with key [ {key} ] from redis.");
            return match;
        }
    }

    /// <summary>
    /// Indicates a Match is empty or null
    /// </summary>
    class MatchEmptyOrNull : Exception
    {
        public MatchEmptyOrNull() { }
        public MatchEmptyOrNull(string message) : base(message) { }

    }

    public class MockRedis : IMatchRedis
    {
        public async Task<MatchDataSet> GetMatch(string key)
        {
            return new MatchDataSet();
        }
    }
}
