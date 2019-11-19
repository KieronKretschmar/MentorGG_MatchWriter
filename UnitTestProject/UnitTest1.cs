using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var matchData = new MatchDataSet();
            var bombDefuseds = new List<BombDefused>
            {
                new BombDefused{PlayerId = 100}
            }
            .Select(x=> x as IMatchDataEntity)
            .ToList();

            matchData.Tables.Add(bombDefuseds);

            var json = matchData.ToJson();

            matchData.AssignMatchId(2);

            var json2 = matchData.ToJson();

            //var matchData2 = JsonConvert.DeserializeObject<MatchDataSet>(json2);

            MatchDataSet matchData2 = JsonConvert.DeserializeObject<MatchDataSet>(json2, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore,
            });

        }

        [TestMethod]
        public void TestBackwardsComp()
        {
            // Use versionSelector to get all supported Versions

            // foreach version
                // Get Sample data
                // Deserialize
                //
        }
    }
}
