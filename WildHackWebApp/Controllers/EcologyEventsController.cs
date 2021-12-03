using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WildHackWebApp.BL;
using WildHackWebApp.Models;

namespace WildHackWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcologyEventsController : ControllerBase
    {
        private readonly EcologyEventContext _context;

        public EcologyEventsController(EcologyEventContext context)
        {
            _context = context;
        }

        // GET: api/EcologyEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EcologyEvent>>> GetEcologyEvents()
        {
            var ecologyEvents = ParseTool.GetLastUpdates();
            string date = ecologyEvents[0].Title;
            Random rnd = new Random();
            await Task.Run(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    ecologyEvents.Add(new EcologyEvent() { Id = i, Title = $"Title-{i}", Description = $"Des-{i}" });
                }
            });
            
            return ecologyEvents;
            //return await _context.EcologyEvents.ToListAsync();
        }

        // GET: api/EcologyEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EcologyEvent>> GetEcologyEvent(long id)
        {
            var ecologyEvent = await _context.EcologyEvents.FindAsync(id);

            if (ecologyEvent == null)
            {
                return NotFound();
            }

            return ecologyEvent;
        }

        // PUT: api/EcologyEvents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEcologyEvent(long id, EcologyEvent ecologyEvent)
        {
            if (id != ecologyEvent.Id)
            {
                return BadRequest();
            }

            _context.Entry(ecologyEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EcologyEventExists(id))
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

        // POST: api/EcologyEvents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EcologyEvent>> PostEcologyEvent(EcologyEvent ecologyEvent)
        {
            _context.EcologyEvents.Add(ecologyEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEcologyEvent", new { id = ecologyEvent.Id }, ecologyEvent);
        }

        // DELETE: api/EcologyEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEcologyEvent(long id)
        {
            var ecologyEvent = await _context.EcologyEvents.FindAsync(id);
            if (ecologyEvent == null)
            {
                return NotFound();
            }

            _context.EcologyEvents.Remove(ecologyEvent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EcologyEventExists(long id)
        {
            return _context.EcologyEvents.Any(e => e.Id == id);
        }
    }
}
