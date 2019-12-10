using Database;
using MatchEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MatchDBI
{
    public interface IDatabaseHelper
    {
        Task<MatchStats> GetMatchStatsAsync(long id);
        bool MatchStatsExists(long id);
        Task PutMatchAsync(MatchDataSet data);
        Task PutMatchAsync(string json);
        Task RemoveMatchAsync(long id);
    }

    public class DatabaseHelper : IDatabaseHelper
    {
        private readonly ILogger<DatabaseHelper> _logger;
        private readonly MatchContext _context;

        public DatabaseHelper(ILogger<DatabaseHelper> logger, MatchContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public async Task<MatchStats> GetMatchStatsAsync(long id)
        {
            var matchStats = await _context.MatchStats.FindAsync(id);
            return matchStats;
        }

        public async Task PutMatchAsync(string json)
        {
            var matchDataSet = MatchDataSetConverter.FromJson(json);
            await PutMatchAsync(matchDataSet);
        }

        public async Task PutMatchAsync(MatchDataSet data)
        {
            await RemoveMatchAsync(data.MatchStats.MatchId);
            foreach (dynamic table in data.Tables())
            {
                _context.AddRange(table);
            }
            await _context.SaveChangesAsync();
        }


        public async Task RemoveMatchAsync(long id)
        {
            var match = _context.MatchStats.SingleOrDefault(x => x.MatchId == id);
            if (match != null)
            {
                _context.MatchStats.Remove(match);
                await _context.SaveChangesAsync();
            }
        }


        public bool MatchStatsExists(long id)
        {
            return _context.MatchStats.Any(e => e.MatchId == id);
        }
    }
}
