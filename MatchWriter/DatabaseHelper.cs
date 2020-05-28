using Database;
using MatchEntities;
using MatchEntities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MatchWriter
{
    public interface IDatabaseHelper : IDisposable
    {
        bool DatabaseIsEmpty();
        void Dispose();
        Task<MatchStats> GetMatchStatsAsync(long id);
        Task<bool> MatchStatsExistsAsync(long id);
        Task PutMatchAsync(MatchDataSet data);
        Task PutMatchAsync(string json);
        Task RemoveMatchAsync(long id);
    }

    public class DatabaseHelper : IDatabaseHelper, IDisposable
    {
        private readonly ILogger<DatabaseHelper> _logger;
        private readonly MatchContext _context;

        public DatabaseHelper(ILogger<DatabaseHelper> logger, MatchContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        /// <summary>
        /// Disposes resources.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
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
            await PutMatchAsync(matchDataSet).ConfigureAwait(false);
        }

        public async Task PutMatchAsync(MatchDataSet data)
        {
            await RemoveMatchAsync(data.MatchStats.MatchId).ConfigureAwait(false);

            await InsertMatchAsync(data).ConfigureAwait(false);
        }

        private async Task InsertMatchAsync(MatchDataSet data)
        {
            _logger.LogInformation($"Attempting to insert match with MatchId [ {data.MatchStats.MatchId} ]");

            // Start transaction, which is necessary because we use ExecuteSqlRawAsync
            // For more info on transactions, see https://docs.microsoft.com/en-us/ef/core/saving/transactions
            using (var transaction = _context.Database.BeginTransaction())
            {
                // Insert all tables but positions
                foreach (IEnumerable<IMatchDataEntity> table in data.Tables())
                {
                    // Skip positions, it will be inserted later
                    var type = table.FirstOrDefault()?.GetType() ?? null;
                    if (type == typeof(PlayerPosition))
                    {
                        continue;
                    }

                    _context.AddRange(table);
                }
                await _context.SaveChangesAsync().ConfigureAwait(false);

                // Insert positions with raw sql as its much more efficient than using Add / AddRange
                // See https://stackoverflow.com/questions/6889065/inserting-multiple-rows-in-mysql for syntax
                // Could be optimized even further utilizing mysql feature LOAD DATA INFILE
                // For more info see https://dev.mysql.com/doc/refman/5.7/en/insert-optimization.html
                var positionTableName = _context.Database.IsInMemory()
                    ? "PlayerPosition"
                    : _context.Model.FindEntityType(typeof(PlayerPosition)).GetTableName();

                foreach (var chunk in data.PlayerPositionList.Chunk(2000))
                {
                    var sql = CreatePlayerPositionSql(chunk, positionTableName);
                    await _context.Database.ExecuteSqlRawAsync(sql).ConfigureAwait(false);
                }

                await transaction.CommitAsync().ConfigureAwait(false);                

                _logger.LogInformation($"Inserted match with MatchId [ {data.MatchStats.MatchId} ]");
            }
        }

        public async Task RemoveMatchAsync(long id)
        {
            _logger.LogInformation($"Attempting to remove match with MatchId [ {id} ]");
            var match = await _context.MatchStats.SingleOrDefaultAsync(x => x.MatchId == id).ConfigureAwait(false);
            if (match != null)
            {
                _context.MatchStats.Remove(match);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                _logger.LogInformation($"Removed match with MatchId [ {id} ]");
            }
            else
            {
                _logger.LogInformation($"No match found to be removed with MatchId [ {id} ]");
            }
        }


        public async Task<bool> MatchStatsExistsAsync(long id)
        {
            return await _context.MatchStats.AnyAsync(e => e.MatchId == id).ConfigureAwait(false);
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

        /// <summary>
        /// Creates a raw sql string for inserting the given PlayerPositions.
        /// 
        /// WARNING: We do not use parametrization as these values are all guaranteed to be numeric only and thus are not susceptible to SQL Injection
        /// When adding new values, make sure to make them injection-safe by either validating or parametrizing the query string
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private string CreatePlayerPositionSql(IEnumerable<PlayerPosition> positions, string table)
        {
            // Set Culture to make sure floats like "167.1" are not parsed as "167,1"
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var sql =
                $"INSERT INTO {table} " +
                    $"(MatchId, Round, Time, PlayerId, Tick, IsCt, PlayerPosX, PlayerPosY, PlayerPosZ, " +
                    $"PlayerViewX, PlayerViewY, PlayerVeloX, PlayerVeloY, PlayerVeloZ, Weapon) " +
                $"VALUES ";
            foreach (var p in positions)
            {
                sql += $"({p.MatchId},{p.Round},{p.Time},{p.PlayerId},{p.Tick},{p.IsCt},{p.PlayerPos.X},{p.PlayerPos.Y},{p.PlayerPos.Z}," +
                    $"{p.PlayerView.X},{p.PlayerView.Y},{p.PlayerVelo.X},{p.PlayerVelo.Y},{p.PlayerVelo.Z},{(short) p.Weapon}),";
            }

            // replace last "," with a ';'
            sql = sql.Remove(sql.Length - 1, 1) + ";";

            return sql;
        }


    }
}
