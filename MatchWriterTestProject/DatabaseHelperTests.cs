using Database;
using MatchWriter;
using MatchWriter.Controllers.trusted;
using MatchEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.Globalization;

namespace MatchWriterTestProject
{
    [TestClass]
    public class DatabaseHelperTests
    {
        private readonly ILogger<DatabaseHelper> _dbHelperLogger;

        public DatabaseHelperTests()
        {
            var services = new ServiceCollection();

            services.AddLogging(o =>
            {
                o.AddConsole();
                o.AddDebug();
            });

            var serviceProvider = services.BuildServiceProvider();
            _dbHelperLogger = serviceProvider.GetService<ILogger<DatabaseHelper>>();
        }

        [DataRow("TestDemo_Valve1.json")]
        [DataTestMethod]
        public async Task TestIdempotency(string jsonFileName)
        {
            var options = new DbContextOptionsBuilder<MatchContext>()
                .UseInMemoryDatabase(databaseName: "TestIdempotency")
                .Options;

            // Run each section of the test against seperate InMemory instances of the context
            // See https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory#writing-tests
            // Enter matchstats
            long matchId;
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                // Put match stats
                var testFilePath = TestHelper.GetTestFilePath(jsonFileName);
                var json = File.ReadAllText(testFilePath);
                matchId = TestHelper.GetMatchIdFromJson(json);
                await databaseHelper.PutMatchAsync(json);

                // Put match stats again to test idempotency
                await databaseHelper.PutMatchAsync(json);
            }

            // Check if one, and only one MatchStats was entered, using a seperate instance of the context
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                var isInDatabase = await databaseHelper.MatchStatsExistsAsync(matchId);
                Assert.IsTrue(isInDatabase);

                var onlyOneMatchInDatabase = context.MatchStats.Count() == 1;
                Assert.IsTrue(onlyOneMatchInDatabase);
            }
        }

        [DataRow("TestDemo_Valve1.json")]
        [DataTestMethod]
        public async Task TestPutMatch(string jsonFileName)
        {
            var options = new DbContextOptionsBuilder<MatchContext>()
                .UseInMemoryDatabase(databaseName: "TestPutMatch")
                .Options;

            // Run each section of the test against seperate InMemory instances of the context
            // See https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory#writing-tests
            // Enter matchstats
            long matchId;
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                // Put match stats
                var testFilePath = TestHelper.GetTestFilePath(jsonFileName);
                var json = File.ReadAllText(testFilePath);
                matchId = TestHelper.GetMatchIdFromJson(json);
                if (matchId == 0)
                {
                    // When inserting a MatchDataSet with MatchId=0, the database auto generates a new MatchId, 
                    // even when we call entity.Property(p => p.MatchId).ValueGeneratedNever();
                    // Therefore always use test jsons with matchId!=0
                    Assert.Inconclusive();
                }

                await databaseHelper.PutMatchAsync(json);
            }

            // Check if MatchStats was entered, using a seperate instance of the context
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                var isInDatabase = await databaseHelper.MatchStatsExistsAsync(matchId);
                Assert.IsTrue(isInDatabase);
            }
        }


        [DataRow("TestDemo_Valve1.json")]
        [DataTestMethod]
        public async Task TestDeleteMatch(string jsonFileName)
        {
            var options = new DbContextOptionsBuilder<MatchContext>()
                .UseInMemoryDatabase(databaseName: "TestDeleteMatch")
                .Options;

            // Run each section of the test against seperate InMemory instances of the context
            // See https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory#writing-tests
            // Enter matchstats
            long matchId;
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                // Put match stats
                var testFilePath = TestHelper.GetTestFilePath(jsonFileName);
                var json = File.ReadAllText(testFilePath);
                matchId = TestHelper.GetMatchIdFromJson(json);
                await databaseHelper.PutMatchAsync(json);
            }

            // Delete match
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                await databaseHelper.RemoveMatchAsync(matchId);
            }


            // Check if it was successfully deleted
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);
                var dbIsEmpty = databaseHelper.DatabaseIsEmpty();
                Assert.IsTrue(dbIsEmpty);
            }
        }

        /// <summary>
        /// This test makes sure that writing and loading a serialized MatchDataSet to the database and loading 
        /// it again does not change its contents except for PlayerPositions table, thereby guaranteeing no such information to be lost when writing to the database.
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <returns></returns>
        [DataRow("TestDemo_Valve4.json")]
        [DataRow("TestDemo_Valve3.json")]
        [DataRow("TestDemo_Valve1.json")]
        [DataTestMethod]
        public async Task PutAndLoadInvarianceWithoutPositions(string jsonFileName)
        {
            var options = new DbContextOptionsBuilder<MatchContext>()
                // InMemory databases can't handle transactions, suppress the warning
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseInMemoryDatabase(databaseName: "PutAndLoadInvariance")
                .Options;

            // Put match stats
            var testFilePath = TestHelper.GetTestFilePath(jsonFileName);
            var jsonOriginal = File.ReadAllText(testFilePath);

            // Run each section of the test against seperate InMemory instances of the context
            // See https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory#writing-tests
            // Enter match
            long matchId;
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                matchId = TestHelper.GetMatchIdFromJson(jsonOriginal);
                await databaseHelper.PutMatchAsync(jsonOriginal);
            }

            // Load match from database and serialize it
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                // Get original dataset with removed positions
                var originalDataWithoutPositions = GetMatchDataSetWithoutPositions(jsonOriginal);
                var originalJsonWithoutPositions = originalDataWithoutPositions.ToJson();

                var databaseDataWithoutPositions = await databaseHelper.GetMatchDataSetAsync(matchId);
                databaseDataWithoutPositions.PlayerPositionList = new List<PlayerPosition>();
                var databaseJsonWithoutPositions = databaseDataWithoutPositions.ToJson();

                var resultsAreEqual = originalJsonWithoutPositions == databaseJsonWithoutPositions;
                Assert.AreEqual(originalJsonWithoutPositions.Length, databaseJsonWithoutPositions.Length);
                Assert.IsTrue(resultsAreEqual);
            }
        }

        /// <summary>
        /// This test makes sure that writing and loading a serialized MatchDataSet to the database and loading 
        /// it again does not change data in the PlayerPositions table, thereby guaranteeing no such information to be lost when writing to the database.
        /// 
        /// Warning: Only works with real database, as PlayerPositions uses RawSql which is not possible with InMemory.
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <returns></returns>
        //[DataRow("TestDemo_Valve4.json")]
        //[DataRow("TestDemo_Valve3.json")]
        [DataRow("TestDemo_Valve1.json")]
        [DataTestMethod]
        public async Task PutAndLoadInvariancePositions(string jsonFileName)
        {
            var options = new DbContextOptionsBuilder<MatchContext>()
                .UseMySql("server=localhost;userid=localuser;password=passwort;database=matchdb;persistsecurityinfo=True")
                .Options;

            // Put match stats
            var testFilePath = TestHelper.GetTestFilePath(jsonFileName);
            var jsonOriginal = File.ReadAllText(testFilePath);

            // Run each section of the test against seperate InMemory instances of the context
            // See https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory#writing-tests
            // Enter match
            long matchId;
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                matchId = TestHelper.GetMatchIdFromJson(jsonOriginal);
                await databaseHelper.PutMatchAsync(jsonOriginal);
            }

            // Load match from database and serialize it
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                // Get original dataset with removed positions
                var originalPositions = MatchDataSet.FromJson(jsonOriginal).PlayerPositionList;
                var databasePositions = (await databaseHelper.GetMatchDataSetAsync(matchId)).PlayerPositionList;

                // Make sure they're both in the same order
                originalPositions = originalPositions
                    .OrderBy(x => x.Time)
                    .ThenBy(x => x.PlayerId)
                    .ToList();
                databasePositions = databasePositions
                    .OrderBy(x => x.Time)
                    .ThenBy(x => x.PlayerId)
                    .ToList();

                var serializerSettings = TestHelper.GetJsonSerializerSettings();
                serializerSettings.Culture = CultureInfo.InvariantCulture;

                Assert.AreEqual(originalPositions.Count, databasePositions.Count);
                for (int i = 0; i < originalPositions.Count; i++)
                {
                    var originalPos = originalPositions[i];
                    var databasePos = databasePositions[i];

                    Assert.AreEqual(originalPos.MatchId, databasePos.MatchId);
                    Assert.AreEqual(originalPos.Round, databasePos.Round);
                    Assert.AreEqual(originalPos.Time, databasePos.Time);
                    Assert.AreEqual(originalPos.PlayerId, databasePos.PlayerId);
                    Assert.AreEqual(originalPos.IsCt, databasePos.IsCt);
                    Assert.IsTrue(originalPos.PlayerPos.AlmostEquals(databasePos.PlayerPos));
                    Assert.IsTrue(originalPos.PlayerView.AlmostEquals(databasePos.PlayerView));
                    Assert.IsTrue(originalPos.PlayerVelo.AlmostEquals(databasePos.PlayerVelo));
                    Assert.AreEqual(originalPos.Weapon, databasePos.Weapon);
                }
            }
        }

        private MatchDataSet GetMatchDataSetWithoutPositions(string json)
        {
            var dataSet = MatchDataSet.FromJson(json);
            dataSet.PlayerPositionList = new List<PlayerPosition>();
            return dataSet;
        }
    }
}
