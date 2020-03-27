﻿using MatchEntities;
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
        private static string _redisUri;
        private IDatabase cache;

        public MatchRedis(ILogger<MatchRedis> logger, string redisUri)
        {
            _logger = logger;
            _redisUri = redisUri;
            cache = lazyConnection.Value.GetDatabase();
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

        /// <summary>
        /// Provides a lazy connection to redis.
        /// 
        /// For more info see https://docs.microsoft.com/en-us/azure/azure-cache-for-redis/cache-dotnet-core-quickstart.
        /// </summary>
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(_redisUri);
        });

        /// <summary>
        /// Provides a connection to redis.
        /// 
        /// For more info see https://docs.microsoft.com/en-us/azure/azure-cache-for-redis/cache-dotnet-core-quickstart.
        /// </summary>
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }

    public class MockRedis : IMatchRedis
    {
        public async Task<MatchDataSet> GetMatch(string key)
        {
            return new MatchDataSet();
        }
    }
}
