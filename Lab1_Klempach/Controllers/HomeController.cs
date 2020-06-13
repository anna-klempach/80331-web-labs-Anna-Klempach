using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebLabs_Klempach.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ListDemo> listDemos = new List<ListDemo>()
            {
                new ListDemo{ ListItemText = "Value 1", ListItemValue = 1 },
                new ListDemo{ ListItemText = "Value 2", ListItemValue = 2},
                new ListDemo{ ListItemText = "Value 3", ListItemValue = 3}
            };

            ViewData["Text"] = "Лабораторная работа №2";
            ViewData["Items"] = new SelectList(listDemos, "ListItemValue", "ListItemText");
            return View();
        }
    }
}