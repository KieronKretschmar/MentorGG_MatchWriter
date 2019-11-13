using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDatabase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MatchDBI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            using(testContext testContext = new testContext())
            {
                //testContext.MatchStats.Add(new TestEntities.MatchStats
                //{
                //});
                var match = testContext.MatchStats.First();


                //testContext.BombDefused.Add(new TestEntities.BombDefused
                //{
                //    MatchId = match.MatchId
                //});
                testContext.SaveChanges();

                var gay = testContext.BombDefused.First().Match.Avgrank;

            }
            return "";
        }
    }
}
