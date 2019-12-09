using Database;
using MatchDBI;
using MatchDBI.Controllers.trusted;
using MatchEntities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace MatchDBITestProject
{
    [TestClass]
    public class DatabaseHelperTests
    {
        [DataRow("valve_match1.json")]
        [DataTestMethod]
        public void TestUploadDeletion(string jsonFileName)
        {
            //var msController = new MatchStatsController(_context, _matchStatsLogger);
            // Put match stats
            var testFilePath = TestHelper.GetTestFilePath(jsonFileName);
            var json = File.ReadAllText(testFilePath);
            DatabaseHelper.PutMatch(json);

            // Check if MatchStats was entered
            var matchId = GetMatchIdFromJson(json);
            var isInDatabase = DatabaseHelper.MatchStatsExists(matchId);
            Assert.IsTrue(isInDatabase);


            // Put match stats again to test idempotency
            DatabaseHelper.PutMatch(json);
            isInDatabase = DatabaseHelper.MatchStatsExists(matchId);
            Assert.IsTrue(isInDatabase);


            // Delete match and check if it was successfully deleted
            DatabaseHelper.RemoveMatch(matchId);
            isInDatabase = DatabaseHelper.MatchStatsExists(matchId);
            Assert.IsFalse(isInDatabase);
        }

        public long GetMatchIdFromJson(string json)
        {
            var data = JsonConvert.DeserializeObject<MatchDataSet>(json);
            return data.MatchStats.MatchId;
        }
    }
}
