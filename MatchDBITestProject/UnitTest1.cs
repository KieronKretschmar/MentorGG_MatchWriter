using MatchDBI;
using MatchEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace MatchDBITestProject
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow("valve_match1.json")]
        [DataTestMethod]
        public void TestUploadDeletion(string jsonFileName)
        {
            using var dbContext = new Database.MatchContext();
            var msController = new MatchDBI.Controllers.trusted.MatchStatsController(dbContext);

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
