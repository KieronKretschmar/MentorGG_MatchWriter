using Database;
using MatchEntities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MatchWriter
{
    public interface IDatabaseHelper
    {
        bool DatabaseIsEmpty();
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
            var matchDataSet = MatchDataSet.FromJson(json);
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

        public bool DatabaseIsEmpty()
        {
            var isEmpty = true;
            //foreach (dynamic table in data.Tables())
            //{
            //    _context.Database.;
            //}

            var dbSets = _context.GetType().GetProperties().Where(p => p.PropertyType.Name.StartsWith("DbSet")); //get Dbset<T>

            foreach (var dbSetProps in dbSets)
            {
                var dbSet = dbSetProps.GetValue(_context, null);
                var dbSetType = dbSet.GetType().GetGenericArguments().First();

                var classNameProp = dbSetType.GetProperty("className");// i did not undestand, you want classes with className property?

                if (classNameProp != null)
                {
                    var contents = ((IEnumerable)dbSet).Cast<object>().ToArray();//Get The Contents of table
                    isEmpty = isEmpty && contents.Length == 0;
                }
            }

            return isEmpty;
        }
    }
}
