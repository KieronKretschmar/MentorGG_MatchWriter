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
            DatabaseHelper.TryPutMatch(json);


            // Check if MatchStats was entered
            var matchId = GetMatchIdFromJson(json);
            var isInDatabase = dbContext.MatchStats.Any(x => x.MatchId == matchId);
            Assert.IsTrue(isInDatabase);



        }

        public long GetMatchIdFromJson(string json)
        {
            var data = JsonConvert.DeserializeObject<MatchDataSet>(json);
            return data.MatchStats.MatchId;
        }
    }
}
