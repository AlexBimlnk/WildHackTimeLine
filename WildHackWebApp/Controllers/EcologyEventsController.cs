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
        private readonly int _countLastEvents = 15;

        public EcologyEventsController(EcologyEventContext context)
        {
            _context = context;
            if (_context.EcologyEvents.Count() == 0)
            {
                Task<List<EcologyEvent>> task = ParseTool.GetDatasetAsync(DatasetOption.Init);
                List<EcologyEvent> ecologyEvents = task.Result;
                foreach (var i in ecologyEvents)
                {
                    _context.EcologyEvents.Add(i);
                    _context.SaveChanges();
                    var temp = _context.EcologyEvents.ToList();
                }
            }
        }

        // GET: api/EcologyEvents/after/15/15
        [HttpGet("after/{countNow}/{countTake}")]
        public async Task<ActionResult<IEnumerable<EcologyEvent>>> GetPartEcologyEvents(int countNow, int countTake)
        {
            var list = await _context.EcologyEvents.
                            Skip(_context.EcologyEvents.Count() - countNow - countTake)
                            .Take(countTake).ToListAsync();
            list.Reverse();

            return list;
        }

        // GET: api/EcologyEvents/after/15
        [HttpGet("after/{countNow}")]
        public async Task<ActionResult<IEnumerable<EcologyEvent>>> GetPartEcologyEvents(int countNow)
        {
            var list = await _context.EcologyEvents.
                            Skip(_context.EcologyEvents.Count() - countNow - _countLastEvents)
                            .Take(_countLastEvents).ToListAsync();
            list.Reverse();

            return list;
        }

        // GET: api/EcologyEvents/new
        [HttpGet("new")]
        public async Task<ActionResult<IEnumerable<EcologyEvent>>> GetNewEcologyEvents()
        {
            List<EcologyEvent> ecologyEvents = await ParseTool.GetDatasetAsync();
            Judge.SortByDate(Judge.CompareWithOld(ecologyEvents, await _context.EcologyEvents.ToListAsync()));
            foreach (var i in ecologyEvents)
            {
                _context.EcologyEvents.Add(i);
                _context.SaveChanges();
            }

            var list = await _context.EcologyEvents.Skip(_context.EcologyEvents.Count() - _countLastEvents).ToListAsync();
            list.Reverse();
            
            return list;
        }

        // GET: api/EcologyEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EcologyEvent>>> GetEcologyEvents()
        {
            var list = await _context.EcologyEvents.ToListAsync();
            list.Reverse();

            return list;
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

        // PUT: api/EcologyEvents/5/rating/1
        [HttpPut("{id}/rating/{value}")]
        public async Task<IActionResult> PutEcologyEvent(long id, int value)
        {
            var ecologyEvent = await _context.EcologyEvents.FindAsync(id);
            if (ecologyEvent == null)
            {
                return NotFound();
            }

            ecologyEvent.Rating += value;
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

        private bool EcologyEventExists(long id)
        {
            return _context.EcologyEvents.Any(e => e.Id == id);
        }
    }
}
