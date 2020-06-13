using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLabs_Klempach.DAL.Data;
using WebLabs_Klempach.DAL.Entities;

namespace WebLabs_Klempach.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebLabs_Klempach.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(WebLabs_Klempach.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
