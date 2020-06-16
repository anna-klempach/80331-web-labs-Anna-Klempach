using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLabs_Klempach.DAL.Data;
using WebLabs_Klempach.DAL.Entities;

namespace WebLabs_Klempach.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        public IActionResult OnGet()
        {
        ViewData["LootCategoryId"] = new SelectList(_context.LootCategories, "LootCategoryId", "LootCategoryName");
            return Page();
        }

        [BindProperty]
        public Loot Loot { get; set; }
        [BindProperty]
        public IFormFile image { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Loot.Add(Loot);
            await _context.SaveChangesAsync();
            if (image != null)
            {
                Loot.LootImageName = Loot.LootId +
                    Path.GetExtension(image.FileName);
                var path = Path.Combine(_environment.WebRootPath, "images",
                    Loot.LootImageName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                };
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
