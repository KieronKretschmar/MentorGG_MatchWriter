using Database;
using MatchDBI.Controllers.trusted;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchDBITestProject
{
    /// <summary>
    /// TODO: Write tests
    /// </summary>
    class MatchStatsControllerTests
    {
        private readonly MatchContext _context;
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
            services.AddDbContext<MatchContext>();

            var serviceProvider = services.BuildServiceProvider();
            _context = serviceProvider.GetService<MatchContext>();
            _matchStatsLogger = serviceProvider.GetService<ILogger<MatchStatsController>>();
        }
    }
}
