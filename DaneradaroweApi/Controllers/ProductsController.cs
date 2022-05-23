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
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
          if (_context.ProductTypes == null)
          {
              return NotFound();
          }
            return await _context.ProductTypes.Include(p => p.Products).ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(Guid id)
        {
          if (_context.ProductTypes == null)
          {
              return NotFound();
          }
            var productType = await _context.ProductTypes.FindAsync(id);

            if (productType == null)
            {
                return NotFound();
            }

            await _context.Entry(productType).Collection(p => p.Products).LoadAsync();

            return productType;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductType(Guid id, ProductType productType)
        {
            if (id != productType.Id)
            {
                return BadRequest();
            }

            _context.Entry(productType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductType>> PostProductType(ProductType productType)
        {
          if (_context.ProductTypes == null)
          {
              return Problem("Entity set 'AppDbContext.ProductTypes'  is null.");
          }
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductType", new { id = productType.Id }, productType);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(Guid id)
        {
            if (_context.ProductTypes == null)
            {
                return NotFound();
            }
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTypeExists(Guid id)
        {
            return (_context.ProductTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
