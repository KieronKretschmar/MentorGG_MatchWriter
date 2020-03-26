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
    [Route("api/[controller]")]
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

        // GET: api/MatchStats?version=0.1.1
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

        // POST: api/MatchStats
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
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

        // DELETE: api/MatchStats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMatchStats(long id)
        {
            _logger.LogInformation($"Received HTTP DELETE request for MatchId [ {id} ]");
            await _dbHelper.RemoveMatchAsync(id);
            return Ok();
        }
    }
}
