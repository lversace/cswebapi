using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cswebapi.Models;

namespace cswebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentsTopsController : ControllerBase
    {
        private readonly InstrumentsTopContext _context;

        public InstrumentsTopsController(InstrumentsTopContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstrumentsTop>>> GetInstrumentsTop(string prefix)
        {
            if (string.IsNullOrEmpty(prefix)) return NoContent();

            return await _context.InstrumentsTop.Where(i => i.Name.StartsWith(prefix)).Take(5).ToListAsync();
           
        }

        // POST: api/InstrumentsTops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InstrumentsTop>> PostInstrumentsTop(InstrumentsTop instrumentsTop)
        {
            var topSelected = _context.InstrumentsTop.Where(x => x.Name == instrumentsTop.Name).FirstOrDefault();
            if (topSelected == null)
            {
                _context.InstrumentsTop.Add(instrumentsTop);
                await _context.SaveChangesAsync();

                return Ok();
            }
            return NoContent();
        }
    }
}
