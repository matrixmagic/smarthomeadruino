using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using arduino.Data;
using arduino.Models;

namespace arduino.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempraturesController : ControllerBase
    {
        private readonly arduinoContext _context;

        public TempraturesController(arduinoContext context)
        {
            _context = context;
        }

        // GET: api/Tempratures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temprature>>> GetTemprature()
        {
            return await _context.Temprature.ToListAsync();
        }

        // GET: api/Tempratures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temprature>> GetTemprature(int id)
        {
            var temprature = await _context.Temprature.FindAsync(id);

            if (temprature == null)
            {
                return NotFound();
            }

            return temprature;
        }

        // PUT: api/Tempratures/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemprature(int id, Temprature temprature)
        {
            if (id != temprature.Id)
            {
                return BadRequest();
            }

            _context.Entry(temprature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TempratureExists(id))
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

        // POST: api/Tempratures
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Temprature>> PostTemprature(Temprature temprature)
        {
            temprature.Date = DateTime.Now;

            _context.Temprature.Add(temprature);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemprature", new { id = temprature.Id }, temprature);
        }

        // DELETE: api/Tempratures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Temprature>> DeleteTemprature(int id)
        {
            var temprature = await _context.Temprature.FindAsync(id);
            if (temprature == null)
            {
                return NotFound();
            }

            _context.Temprature.Remove(temprature);
            await _context.SaveChangesAsync();

            return temprature;
        }

        private bool TempratureExists(int id)
        {
            return _context.Temprature.Any(e => e.Id == id);
        }
    }
}
