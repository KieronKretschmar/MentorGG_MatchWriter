using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Database;

namespace MatchWriter.Controllers
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
            using (MatchContext dbContext = new MatchContext())
            {
                //var newMatch = new Entities.MatchStats
                //{
                //};
                //dbContext.MatchStats.Add(newMatch);

                //dbContext.SaveChanges();

                //dbContext.RoundStats.Add(new Entities.RoundStats
                //{
                //    MatchId = dbContext.MatchStats.First().MatchId
                //});

                //dbContext.SaveChanges();

                //var debug = dbContext.RoundStats.FirstOrDefault();

                //dbContext.MatchStats.Remove(newMatch);
                //dbContext.SaveChanges();



                //    dbContext.SaveChanges();


                //}

                //using (testContext testContext = new testContext())
                //{
                //    //testContext.MatchStats.Add(new TestEntities.MatchStats
                //    //{
                //    //});
                //    var match = testContext.MatchStats.First();


                //    testContext.BombDefused.Add(new TestEntities.BombDefused
                //    {
                //        MatchId = match.MatchId
                //    });
                //    testContext.SaveChanges();
                //    var a = testContext.Kills.First().VictimMatchStats;
                //    var b = testContext.PlayerMatchStats.First().Kills;
                //    var gay = testContext.BombDefused.First().Match.Avgrank;

            }
            return "";
        }
    }
}
