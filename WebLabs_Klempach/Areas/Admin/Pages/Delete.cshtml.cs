using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLabs_Klempach.DAL.Entities;

namespace WebLabs_Klempach.Areas.Admin.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly WebLabs_Klempach.DAL.Data.ApplicationDbContext _context;

        public DeleteModel(WebLabs_Klempach.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Loot Loot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Loot = await _context.Loot
                .Include(l => l.Category).FirstOrDefaultAsync(m => m.LootId == id);

            if (Loot == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Loot = await _context.Loot.FindAsync(id);

            if (Loot != null)
            {
                _context.Loot.Remove(Loot);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
