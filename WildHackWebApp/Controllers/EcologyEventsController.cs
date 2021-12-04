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
            if (_context.EcologyEvents.Count() == 0)
            {
                Task<List<EcologyEvent>> task = ParseTool.GetDatasetAsync(DatasetOption.Init);
                List<EcologyEvent> ecologyEvents = task.Result;
                foreach (var i in ecologyEvents)
                {
                    _context.Add(i);
                }
                _context.SaveChanges();
            }
        }

        // GET: api/EcologyEvents
        [HttpGet("test")]
        public async Task<IEnumerable<EcologyEvent>> GetEcologyEvents1()
        {
            //return await ParseTool.GetDatasetAsync(DatasetOption.Update);
            List<EcologyEvent> list = await _context.EcologyEvents.ToListAsync();

            return list.Where(ecEvent => ecEvent.Link == "https://ria.ru/20211111/oleni-1758491544.html").ToList();
        }

        // GET: api/EcologyEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EcologyEvent>>> GetEcologyEvents()
        {
            //return await ParseTool.GetDatasetAsync(DatasetOption.Update);
            List<EcologyEvent> ecologyEvents = await _context.EcologyEvents.ToListAsync();
            ecologyEvents.Sort((ecoEvent1, ecoEvent2) =>
            {
                int year1 = int.Parse(ecoEvent1.Date.Substring(6, 4));
                int year2 = int.Parse(ecoEvent2.Date.Substring(6, 4));
                if (year1 == year2)
                {
                    int month1 = int.Parse(ecoEvent1.Date.Substring(3, 2));
                    int month2 = int.Parse(ecoEvent2.Date.Substring(3, 2));
                    if (month1 == month2)
                    {
                        int day1 = int.Parse(ecoEvent1.Date.Substring(0, 2));
                        int day2 = int.Parse(ecoEvent2.Date.Substring(0, 2));
                        if (day1 == day2)
                        {
                            return 0;
                        }
                        else
                        {
                            if (day1 > day2)
                            {
                                return 1;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                    else
                    {
                        if (month1 > month2)
                        {
                            return 1;
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
                else
                {
                    if (year1 > year2)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            });
            return ecologyEvents;
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
        public async Task<IActionResult> PutEcologyEvent(long id, [FromBody] EcologyEvent ecologyEvent)
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

            return NoContent();
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
