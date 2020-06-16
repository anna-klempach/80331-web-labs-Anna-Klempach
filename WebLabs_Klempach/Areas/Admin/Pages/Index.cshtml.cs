using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLabs_Klempach.DAL.Entities;

namespace WebLabs_Klempach.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebLabs_Klempach.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebLabs_Klempach.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Loot> Loot { get;set; }

        public async Task OnGetAsync()
        {
            Loot = await _context.Loot
                .Include(l => l.Category).ToListAsync();
        }
    }
}
