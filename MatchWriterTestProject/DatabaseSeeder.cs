using MatchWriter;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MatchWriterTestProject
{
    /// <summary>
    /// Used to seed the local database. Does not contain unittests.
    /// </summary>
    [TestClass]
    public class DatabaseSeeder
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly IDatabaseHelper _dbHelper;

        public DatabaseSeeder()
        {
            _factory = new WebApplicationFactory<Startup>();
            _dbHelper = (IDatabaseHelper)_factory.Services.GetService(typeof(IDatabaseHelper));
        }

        /// <summary>
        /// Writes serialized MatchDataSet to database. Make sure to set env vars before running.
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <returns></returns>
        [DataRow("TestDemo_Valve4.json")]
        [DataRow("TestDemo_Valve3.json")]
        [DataRow("TestDemo_Valve1.json")]
        [DataTestMethod]
        public async Task Seed(string jsonFileName)
        {
            // Put match stats
            var testFilePath = TestHelper.GetTestFilePath(jsonFileName);
            var json = File.ReadAllText(testFilePath);
            var matchId = TestHelper.GetMatchIdFromJson(json);

            await _dbHelper.PutMatchAsync(json);
        }
    }
}
