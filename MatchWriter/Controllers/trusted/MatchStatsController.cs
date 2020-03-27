using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using MatchEntities;
using System.IO;
using Microsoft.Extensions.Logging;

namespace MatchWriter.Controllers.trusted
{
    [Route("api/match")]
    [ApiController]
    public class MatchStatsController : ControllerBase
    {
        private readonly IDatabaseHelper _dbHelper;
        private readonly ILogger<MatchStatsController> _logger;

        public MatchStatsController(ILogger<MatchStatsController> logger, IDatabaseHelper dbHelper)
        {
            _logger = logger;
            _dbHelper = dbHelper;
        }

        /// <summary>
        /// Getter for Metadata of a stored match.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchStats>> GetMatchStats(long id)
        {
            _logger.LogInformation($"Received HTTP GET request for MatchId [ {id} ]");
            var matchStats = await _dbHelper.GetMatchStatsAsync(id);

            if (matchStats == null)
            {
                _logger.LogInformation($"Could not find match with MatchId [ {id} ]");
                return NotFound();
            }

            _logger.LogInformation($"Returning match with MatchId [ {id} ]");
            return matchStats;
        }

        /// <summary>
        /// Writes the MatchDataSet from the body to the database. 
        /// If another match already exists with the same MatchId, it will be replaced.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> PutMatchStats()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();

                // Upload match to db
                _dbHelper.PutMatchAsync(body);

                return new OkResult();
            }
        }

        /// <summary>
        /// Deletes all data of the match with the given Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatchStats(long id)
        {
            _logger.LogInformation($"Received HTTP DELETE request for MatchId [ {id} ]");
            await _dbHelper.RemoveMatchAsync(id);
            return Ok();
        }
    }
}
