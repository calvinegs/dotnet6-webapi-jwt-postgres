using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet6_webapi_jwt.Data;
using dotnet6_webapi_jwt.Models;

namespace dotnet6_webapi_jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TodoController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemData>>> GetItemData()
        {
          if (_context.ItemData == null)
          {
              return NotFound();
          }
            return await _context.ItemData.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemData>> GetItemData(int id)
        {
          if (_context.ItemData == null)
          {
              return NotFound();
          }
            var itemData = await _context.ItemData.FindAsync(id);

            if (itemData == null)
            {
                return NotFound();
            }

            return itemData;
        }

        // PUT: api/Todo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemData(int id, ItemData itemData)
        {
            if (id != itemData.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDataExists(id))
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

        // POST: api/Todo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItemData>> PostItemData(ItemData itemData)
        {
          if (_context.ItemData == null)
          {
              return Problem("Entity set 'ApiDbContext.ItemData'  is null.");
          }
            _context.ItemData.Add(itemData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemData", new { id = itemData.Id }, itemData);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemData(int id)
        {
            if (_context.ItemData == null)
            {
                return NotFound();
            }
            var itemData = await _context.ItemData.FindAsync(id);
            if (itemData == null)
            {
                return NotFound();
            }

            _context.ItemData.Remove(itemData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemDataExists(int id)
        {
            return (_context.ItemData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
