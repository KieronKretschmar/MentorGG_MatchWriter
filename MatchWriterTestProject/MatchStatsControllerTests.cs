using Database;
using MatchWriter;
using MatchWriter.Controllers.trusted;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchWriterTestProject
{
    /// <summary>
    /// TODO: Write tests
    /// </summary>
    [TestClass]
    public class MatchStatsControllerTests
    {
        private readonly IDatabaseHelper _dbHelper;
        private readonly ILogger<MatchStatsController> _matchStatsLogger;

        public MatchStatsControllerTests()
        {
            var services = new ServiceCollection();

            services.AddLogging(o =>
            {
                o.AddConsole();
                o.AddDebug();
            });

            services.AddControllers();
            services.AddSingleton<IDatabaseHelper, DatabaseHelper>();

            var serviceProvider = services.BuildServiceProvider();
            _dbHelper = serviceProvider.GetService<IDatabaseHelper>();
            _matchStatsLogger = serviceProvider.GetService<ILogger<MatchStatsController>>();
        }

        [TestMethod]
        public void TestMethod()
        {
            var matchStatsController = new MatchStatsController(_matchStatsLogger, _dbHelper);
            Assert.IsTrue(true);
        }
    }
}
