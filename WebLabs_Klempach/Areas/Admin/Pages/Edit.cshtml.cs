using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLabs_Klempach.DAL.Entities;

namespace WebLabs_Klempach.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebLabs_Klempach.DAL.Data.ApplicationDbContext _context;

        private IWebHostEnvironment _environment;

        public EditModel(WebLabs_Klempach.DAL.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;
        }

        [BindProperty]
        public Loot Loot { get; set; }
        [BindProperty]
        public IFormFile image { get; set; }

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
           ViewData["LootCategoryId"] = new SelectList(_context.LootCategories, "LootCategoryId", "LootCategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string path = "";
            string previousImage = String.IsNullOrEmpty(Loot.LootImageName)
                ? ""
                : Loot.LootImageName;
            if (image != null)
            {
                Loot.LootImageName = Loot.LootId + Path.GetExtension(image.FileName);
                path = Path.Combine(_environment.WebRootPath, "images", Loot.LootImageName);
            }
            _context.Attach(Loot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                if (image != null)
                {
                    if (!String.IsNullOrEmpty(previousImage))
                    {
                        var fileInfo = _environment.WebRootFileProvider
                            .GetFileInfo("/Images/" + previousImage);
                        if (fileInfo.Exists)
                        {
                            var oldPath = Path.Combine(_environment.WebRootPath, "images", previousImage);
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    };
                }
            }
            finally
            {
                _context.Attach(Loot).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LootExists(Loot.LootId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LootExists(int id)
        {
            return _context.Loot.Any(e => e.LootId == id);
        }
    }
}
