#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DaneradaroweApi.Data;
using DaneradaroweApi.Models;

namespace DaneradaroweApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RadarsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Radars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Radar>>> GetRadars()
        {
            return await _context.Radars
                .Include(r => r.Scans)
                .Include(r => r.Products)
                .ToListAsync();
        }

        // GET: api/Radars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Radar>> GetRadar(Guid id)
        {
            var radar = await _context.Radars.FindAsync(id);

            if (radar == null)
            {
                return NotFound();
            }

            return radar;
        }

        // PUT: api/Radars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRadar(Guid id, Radar radar)
        {
            if (id != radar.Id)
            {
                return BadRequest();
            }

            _context.Entry(radar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RadarExists(id))
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

        // POST: api/Radars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Radar>> PostRadar(Radar radar)
        {
            _context.Radars.Add(radar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRadar", new { id = radar.Id }, radar);
        }

        // DELETE: api/Radars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRadar(Guid id)
        {
            var radar = await _context.Radars.FindAsync(id);
            if (radar == null)
            {
                return NotFound();
            }

            _context.Radars.Remove(radar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RadarExists(Guid id)
        {
            return _context.Radars.Any(e => e.Id == id);
        }
    }
}
