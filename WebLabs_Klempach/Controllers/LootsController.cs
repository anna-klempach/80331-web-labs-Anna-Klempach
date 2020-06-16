using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebLabs_Klempach.DAL.Entities;
using WebLabs_Klempach.DAL.Data;

namespace WebLabs_Klempach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LootsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LootsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Loots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loot>>> GetLoot(int? category)
        {
            return await _context
                .Loot
                .Where(loot => !category.HasValue || loot.LootCategoryId.Equals(category.Value) || category.Value == 0)
                .ToListAsync();
        }

        // GET: api/Loots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Loot>> GetLoot(int id)
        {
            var loot = await _context.Loot.FindAsync(id);

            if (loot == null)
            {
                return NotFound();
            }

            return loot;
        }

        // PUT: api/Loots/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoot(int id, Loot loot)
        {
            if (id != loot.LootId)
            {
                return BadRequest();
            }

            _context.Entry(loot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LootExists(id))
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

        // POST: api/Loots
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Loot>> PostLoot(Loot loot)
        {
            _context.Loot.Add(loot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoot", new { id = loot.LootId }, loot);
        }

        // DELETE: api/Loots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Loot>> DeleteLoot(int id)
        {
            var loot = await _context.Loot.FindAsync(id);
            if (loot == null)
            {
                return NotFound();
            }

            _context.Loot.Remove(loot);
            await _context.SaveChangesAsync();

            return loot;
        }

        private bool LootExists(int id)
        {
            return _context.Loot.Any(e => e.LootId == id);
        }
    }
}
