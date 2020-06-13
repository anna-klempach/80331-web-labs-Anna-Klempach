using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebLabs_Klempach.DAL.Entities;
using WebLabs_Klempach.Models;
using WebLabs_Klempach.Extensions;
using WebLabs_Klempach.DAL.Data;

namespace WebLabs_Klempach.Controllers
{
    public class LootController : Controller
    {
        List<LootCategory> _lootCategoryList;
        int _pageSize;

        public List<Loot> _lootList;
        ApplicationDbContext _context;

        public LootController(ApplicationDbContext context)
        {
            _pageSize = 3;
            _context = context;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNumber}")]
        public IActionResult Index(int? category, int pageNumber = 1)
        {
            var filteredLootList = _context.Loot
                .Where(item => !category.HasValue || item.LootCategoryId == category.Value || category.Value == 0);
            ViewData["LootCategories"] = _context.LootCategories;
            var lootCategory = category.HasValue
                ? category
                : 0;
            ViewData["CurrentCategory"] = lootCategory;
            if (Request.IsAjaxRequest())
                return PartialView("_ListPartial", ListViewModel<Loot>.GetModel(filteredLootList, pageNumber, _pageSize));
            return View(ListViewModel<Loot>.GetModel(filteredLootList, pageNumber, _pageSize));
        }
    }
}
