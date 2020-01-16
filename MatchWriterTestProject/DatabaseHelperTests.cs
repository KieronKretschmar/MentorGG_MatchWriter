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

        [DataRow("valve_match1.json")]
        [DataTestMethod]
        public async Task TestUploadDeletion(string jsonFileName)
        {
            var options = new DbContextOptionsBuilder<MatchContext>()
                .UseInMemoryDatabase(databaseName: "TestUploadDeletion")
                //.UseMySql("server=localhost;userid=matchdbuser;password=passwort;database=matchdb;persistsecurityinfo=True")
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

            // Check if MatchStats was entered, using a seperate instance of the context
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(_dbHelperLogger, context);

                var isInDatabase = databaseHelper.MatchStatsExists(matchId);
                Assert.IsTrue(isInDatabase);
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
                var isInDatabase = databaseHelper.MatchStatsExists(matchId);
                Assert.IsFalse(isInDatabase);
            }
        }

        public long GetMatchIdFromJson(string json)
        {
            var data = JsonConvert.DeserializeObject<MatchDataSet>(json);
            return data.MatchStats.MatchId;
        }
    }
}
