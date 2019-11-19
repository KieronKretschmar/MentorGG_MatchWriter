using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Entities;

namespace MatchDBI.Controllers.guarded
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatsController : ControllerBase
    {
        private readonly MatchContext _context;

        public MatchStatsController(MatchContext context)
        {
            _context = context;
        }

        // GET: api/MatchStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchStats>>> GetMatchStats()
        {
            return await _context.MatchStats.ToListAsync();
        }

        // GET: api/MatchStats?version=0.1.1
        [HttpGet("{id}")]
        public async Task<ActionResult<MatchStats>> GetMatchStats(string version, string json)
        {
            var matchStats = await _context.MatchStats.FindAsync(id);

            if (matchStats == null)
            {
                return NotFound();
            }

            return matchStats;
        }

        // PUT: api/MatchStats/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatchStats(long id, MatchStats matchStats)
        {
            if (id != matchStats.MatchId)
            {
                return BadRequest();
            }

            _context.Entry(matchStats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchStatsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MatchStats
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MatchStats>> PostMatchStats(MatchStats matchStats)
        {
            _context.MatchStats.Add(matchStats);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMatchStats", new { id = matchStats.MatchId }, matchStats);
        }

        // DELETE: api/MatchStats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MatchStats>> DeleteMatchStats(long id)
        {
            var matchStats = await _context.MatchStats.FindAsync(id);
            if (matchStats == null)
            {
                return NotFound();
            }

            _context.MatchStats.Remove(matchStats);
            await _context.SaveChangesAsync();

            return matchStats;
        }

        private bool MatchStatsExists(long id)
        {
            return _context.MatchStats.Any(e => e.MatchId == id);
        }
    }
}
