using Database;
using MatchEntities;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Loads data for the match with the given matchId into a MatchDataSet object and returns it.
        /// 
        /// Make sure to update this method when new tables are added, as I could not find a generic
        /// solution that works without having to load and assign explicitly each table's data explicitly. 
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<MatchDataSet> GetMatchDataSetAsync(long matchId)
        {
            var dataSet = new MatchDataSet();

            dataSet.MatchStats = await _context.MatchStats.FindAsync(matchId);
            dataSet.OverTimeStats = await _context.OverTimeStats.FindAsync(matchId);

            dataSet.PlayerMatchStatsList = await _context.PlayerMatchStats
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.RoundStatsList = await _context.RoundStats
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.PlayerRoundStatsList = await _context.PlayerRoundStats
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.BombPlantList = await _context.BombPlant
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.BombDefusedList = await _context.BombDefused
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.BombExplosionList = await _context.BombExplosion
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.BotTakeOverList = await _context.BotTakeOver
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.ConnectDisconnectList = await _context.ConnectDisconnect
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.HostageDropList = await _context.HostageDrop
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.HostagePickUpList = await _context.HostagePickUp
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.HostageRescueList = await _context.HostageRescue
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.ItemDroppedList = await _context.ItemDropped
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.ItemPickedUpList = await _context.ItemPickedUp
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.ItemSavedList = await _context.ItemSaved
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.RoundItemList = await _context.RoundItem
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.PlayerPositionList = await _context.PlayerPosition
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.DecoyList = await _context.Decoy
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.FireNadeList = await _context.FireNade
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.FlashList = await _context.Flash
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.FlashedList = await _context.Flashed
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.HeList = await _context.He
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.SmokeList = await _context.Smoke
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.DamageList = await _context.Damage
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.KillList = await _context.Kill
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.WeaponReloadList = await _context.WeaponReload
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            dataSet.WeaponFiredList = await _context.WeaponFired
                .Where(x => x.MatchId == matchId)
                .ToListAsync()
                .ConfigureAwait(false);

            return dataSet;
        }

        public async Task PutMatchAsync(string json)
        {
            var matchDataSet = MatchDataSet.FromJson(json);
            await PutMatchAsync(matchDataSet);
        }

        public async Task PutMatchAsync(MatchDataSet data)
        {
            await RemoveMatchAsync(data.MatchStats.MatchId);

            _logger.LogInformation($"Attempting to insert match with MatchId [ {data.MatchStats.MatchId} ]");
            foreach (dynamic table in data.Tables())
            {
                _context.AddRange(table);
            }
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Inserted match with MatchId [ {data.MatchStats.MatchId} ]");
        }


        public async Task RemoveMatchAsync(long id)
        {
            _logger.LogInformation($"Attempting to remove match with MatchId [ {id} ]");
            var match = _context.MatchStats.SingleOrDefault(x => x.MatchId == id);
            if (match != null)
            {
                _context.MatchStats.Remove(match);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Removed match with MatchId [ {id} ]");
            }
            else
            {
                _logger.LogInformation($"No match found to be removed with MatchId [ {id} ]");
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
