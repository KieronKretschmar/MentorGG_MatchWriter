using Database;
using MatchWriter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MatchWriterTestProject
{
    /// <summary>
    /// Not meant for testing, contains utility methods for when you need a local database with data for debugging.
    /// </summary>
    [TestClass]
    public class UtilityMethods
    {
        private const string CONNECTIONSTRING = "server=localhost;userid=localuser;password=passwort;database=matchdb;persistsecurityinfo=True";        

        /// <summary>
        /// Loads all specified matches into the database. 
        /// Not meant for testing, just a utility method for when you need a local database with data for debugging.
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <returns></returns>
        [DataRow("TestDemo_Valve1.json")]
        [DataRow("TestDemo_Valve2.json")]
        [DataRow("TestDemo_Valve3.json")]
        [DataRow("TestDemo_Valve4.json")]
        [DataRow("Issue5.json")]
        //[Ignore]
        [DataTestMethod]
        public async Task UploadToDatabase(string jsonFileName)
        {
            var options = new DbContextOptionsBuilder<MatchContext>()
                .UseMySql(CONNECTIONSTRING)
                .Options;


            // Submit match to database
            // Put match stats
            var testFilePath = TestHelper.GetTestFilePath(jsonFileName);
            var jsonOriginal = File.ReadAllText(testFilePath);
            using (var context = new MatchContext(options))
            {
                DatabaseHelper databaseHelper = new DatabaseHelper(new Mock<ILogger<DatabaseHelper>>().Object, context);
                await databaseHelper.PutMatchAsync(jsonOriginal);
            }
        }

    }
}
