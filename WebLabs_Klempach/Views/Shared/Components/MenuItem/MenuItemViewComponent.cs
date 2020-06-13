using WebLabs_Klempach.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLabs_Klempach.Views.Shared.Components
{
    public class MenuItemViewComponent : ViewComponent
    {
        private List<MenuItem> menuItems { get; set; }
        public IViewComponentResult Invoke()
        {
            menuItems = new List<MenuItem>
            {
                new MenuItem{controllerName="Home", methodName="Index", itemText="Лабораторная"},
                new MenuItem{controllerName="Loot", methodName="Index", itemText="Каталог"},
                new MenuItem{isRazorPage=true, areaName="Admin", pageName="/Index", itemText="Администрирование"}
            };
            foreach (MenuItem item in menuItems)
            {
                if ((item.controllerName != null && item.controllerName.Equals(ViewContext.RouteData.Values["controller"]))
                    || (item.areaName != null && item.areaName.Equals(ViewContext.RouteData.Values["area"])))
                {
                    item.activeClassName = "active";
                }
            }
            return View(menuItems);
        }
    }
}
