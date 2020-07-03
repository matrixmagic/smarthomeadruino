using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using arduino.Data;
using arduino.Models;
using Microsoft.Extensions.Caching.Memory;

namespace arduino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumingsController : ControllerBase
    {
        private readonly arduinoContext _context;
        private IMemoryCache _cache;

        public ConsumingsController(arduinoContext context, IMemoryCache memoryCache)
        {
            _cache = memoryCache;
            _context = context;
        }

        // GET: api/Consumings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consuming>>> GetConsuming()
        {
            return await _context.Consuming.ToListAsync();
        }

        // GET: api/Consumings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consuming>> GetConsuming(int id)
        {
            var consuming = await _context.Consuming.FindAsync(id);

            if (consuming == null)
            {
                return NotFound();
            }

            return consuming;
        }

        // PUT: api/Consumings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsuming(int id, Consuming consuming)
        {
            if (id != consuming.Id)
            {
                return BadRequest();
            }

            _context.Entry(consuming).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumingExists(id))
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

        // POST: api/Consumings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Consuming>> PostConsuming(Consuming consuming)
        {

            consuming.date = DateTime.Now;
            _context.Consuming.Add(consuming);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsuming", new { id = consuming.Id }, consuming);
        }

        // DELETE: api/Consumings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Consuming>> DeleteConsuming(int id)
        {
            var consuming = await _context.Consuming.FindAsync(id);
            if (consuming == null)
            {
                return NotFound();
            }

            _context.Consuming.Remove(consuming);
            await _context.SaveChangesAsync();

            return consuming;
        }

        private bool ConsumingExists(int id)
        {
            return _context.Consuming.Any(e => e.Id == id);
        }
    }
}
