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
                matchId = GetMatchIdFromJson(json);
                await databaseHelper.PutMatchAsync(json);

                // Put match stats again to test idempotency
                await databaseHelper.PutMatchAsync(json);
            }

            // Check if one, and only one MatchStats was entered, using a seperate instance of the context
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                var isInDatabase = databaseHelper.MatchStatsExists(matchId);
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
                matchId = GetMatchIdFromJson(json);
                if(matchId == 0)
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

                var isInDatabase = databaseHelper.MatchStatsExists(matchId);
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
                matchId = GetMatchIdFromJson(json);
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
        /// it again does not change its contents, thereby guaranteeing no information to be lost when writing to the database.
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <returns></returns>
        [DataRow("TestDemo_Valve1.json")]
        [DataTestMethod]
        public async Task PutAndLoadInvariance(string jsonFileName)
        {
            var options = new DbContextOptionsBuilder<MatchContext>()
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

                matchId = GetMatchIdFromJson(jsonOriginal);
                await databaseHelper.PutMatchAsync(jsonOriginal);
            }

            // Load match from database and serialize it
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);
                var matchDataSet = await databaseHelper.GetMatchDataSetAsync(matchId);
                var jsonFromDb = matchDataSet.ToJson();
                Assert.AreEqual(jsonOriginal, jsonFromDb);
            }
        }

        public long GetMatchIdFromJson(string json)
        {
            var data = JsonConvert.DeserializeObject<MatchDataSet>(json);
            return data.MatchStats.MatchId;
        }
    }
}
