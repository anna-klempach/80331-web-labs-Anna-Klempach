﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebLabs_Klempach.DAL.Entities;
using WebLabs_Klempach.Models;
using WebLabs_Klempach.Extensions;

namespace WebLabs_Klempach.Controllers
{
    public class LootController : Controller
    {
        List<LootCategory> _lootCategoryList;
        int _pageSize;

        public List<Loot> _lootList;

        public LootController()
        {
            _pageSize = 3;
            RenderContent();
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNumber}")]
        public IActionResult Index(int? category, int pageNumber = 1)
        {
            var filteredLootList = _lootList
                .Where(item => !category.HasValue || item.LootCategoryId == category.Value || category.Value == 0);
            ViewData["LootCategories"] = _lootCategoryList;
            var lootCategory = category.HasValue
                ? category
                : 0;
            ViewData["CurrentCategory"] = lootCategory;
            if (Request.IsAjaxRequest())
                return PartialView("_ListPartial", ListViewModel<Loot>.GetModel(filteredLootList, pageNumber, _pageSize));
            return View(ListViewModel<Loot>.GetModel(filteredLootList, pageNumber, _pageSize));
        }

        public void RenderContent()
        {
            this._lootCategoryList = new List<LootCategory>
            {
                new LootCategory {LootCategoryId = 1, LootCategoryName = "Weapon"},
                new LootCategory {LootCategoryId = 2, LootCategoryName = "Suits"},
                new LootCategory {LootCategoryId = 3, LootCategoryName = "Enhancers"},
                new LootCategory {LootCategoryId = 4, LootCategoryName = "Snacks"}
            };

            this._lootList = new List<Loot>
            {
                new Loot
                {
                    LootId = 1,
                    LootCategoryId = 1,
                    LootName = "Hammer",
                    LootDescription = "A powerful hammer that chooses the one who deserves it",
                    LootPrice = 200,
                    LootImageName = "hammer.jpg",
                    LootImageMimeType = ".jpg"
                },
                new Loot
                {
                    LootId = 2,
                    LootCategoryId = 1,
                    LootName = "Shield",
                    LootDescription = "A light and strong shield",
                    LootPrice = 50,
                    LootImageName = "shield.jpg",
                    LootImageMimeType = ".jpg"
                },
                new Loot
                {
                    LootId = 3,
                    LootCategoryId = 2,
                    LootName = "Iron Man Suit",
                    LootDescription = "Protection suit to make you a real superhero. Sizes XS, S, M, L, XL",
                    LootPrice = 100,
                    LootImageName = "iron-man-suit.jpg",
                    LootImageMimeType = ".jpg"
                },
                new Loot
                {
                    LootId = 4,
                    LootCategoryId = 2,
                    LootName = "Spider Man Suit",
                    LootDescription = "Soft and comfy. Hypoallergenic fabric. Has web throwers installed. Sizes XS, S, M, L, XL",
                    LootPrice = 100,
                    LootImageName = "spider-man-suit.jpg",
                    LootImageMimeType = ".jpg"
                },
                new Loot
                {
                    LootId = 5,
                    LootCategoryId = 1,
                    LootName = "Batarangs",
                    LootDescription = "Sharp and deadly. Have ergonomic design. Sizes S, M, L",
                    LootPrice = 100,
                    LootImageName = "batarangs.jpg",
                    LootImageMimeType = ".jpg"
                },
                new Loot
                {
                    LootId = 6,
                    LootCategoryId = 3,
                    LootName = "X-Ray vision",
                    LootDescription = "Allows you to see through living beings and objects.",
                    LootPrice = 70,
                    LootImageName = "x-ray-vision.jpg",
                    LootImageMimeType = ".jpg"
                },
                new Loot
                {
                    LootId = 7,
                    LootCategoryId = 3,
                    LootName = "Wolverine claws",
                    LootDescription = "Installed in arms. Materials: stainless steel/ bone",
                    LootPrice = 50,
                    LootImageName = "wolverine-claws.jpg",
                    LootImageMimeType = ".jpg"
                },
                new Loot
                {
                    LootId = 8,
                    LootCategoryId = 4,
                    LootName = "Shawarma",
                    LootDescription = "The best snack after saving the world",
                    LootPrice = 60,
                    LootImageName = "shawarma.jpg",
                    LootImageMimeType = ".jpg"
                },
            };
        }
    }
}