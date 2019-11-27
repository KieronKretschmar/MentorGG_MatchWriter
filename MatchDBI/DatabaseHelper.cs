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
    public static class DatabaseHelper
    {
        private static readonly ILogger logger;
        //public DatabaseHelper()
        //{
        //    // TODO: MAKE HELPER AS SERVICE INSTEAD OF STATIC, WITH _logger COMING IN AS DI
        //    _logger = GetServices();
        //}

        public static bool TryPutMatch(string json)
        {
            var matchDataSet = MatchDataSetConverter.FromJson(json);
            var success = TryPutMatch(matchDataSet);
            return success;
        }

        public static bool TryPutMatch(MatchDataSet data)
        {
            try
            {
                using MatchContext dbContext = new MatchContext();
                foreach (dynamic table in data.Tables())
                {
                    dbContext.AddRange(table);
                }
                dbContext.SaveChanges();
            }

            catch (Exception)
            {
                return false;
                throw;
            }
            throw new NotImplementedException();
        }


        public static void RemoveMatch(long id)
        {
            using MatchContext dbContext = new MatchContext();
            var match = dbContext.MatchStats.SingleOrDefault(x => x.MatchId == id);
            if (match != null)
            {
                dbContext.MatchStats.Remove(match);
                dbContext.SaveChanges();
            }
        }


        public static bool MatchStatsExists(long id)
        {
            using MatchContext dbContext = new MatchContext();
            return dbContext.MatchStats.Any(e => e.MatchId == id);
        }
    }
}
