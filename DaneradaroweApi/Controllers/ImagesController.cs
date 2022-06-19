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
    public class ImagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ImagesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages(
            [FromQuery] string radarId,
            [FromQuery] string scanId,
            [FromQuery] string productId,
            [FromQuery] int? n
            )
        {

            return await _context.Images
                .Where(i => (radarId == null || i.RadarID.ToString() == radarId))
                .Where(i => (scanId == null || i.ScanID.ToString() == scanId))
                .Where(i => (productId == null || i.ProductID.ToString() == productId))
                .OrderByDescending(i => i.Date)
                .Take(n != null? (int) n : _context.Images.Count())
                .ToListAsync();
        }

        // GET: api/Images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(Guid id)
        {
            var image = await _context.Images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // POST: api/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("addMultiple")]
        public async Task<ActionResult<Image>> PostImages(Image[] images)
        {
            _context.Images.AddRange(images);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetImage", images);
            //return NoContent();
            return new JsonResult(new {status = "OK"});
        }

        [HttpPost]
        [Route("addSingle")]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImage", new {id = image.Id}, image);
        }

        // DELETE: api/Images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageExists(Guid id)
        {
            return _context.Images.Any(e => e.Id == id);
        }
    }
}
