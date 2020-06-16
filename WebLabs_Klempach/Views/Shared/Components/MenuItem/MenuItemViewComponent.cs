using WebLabs_Klempach.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebLabs_Klempach.Views.Shared.Components
{
    public class MenuItemViewComponent : ViewComponent
    {
        private List<MenuItem> menuItems { get; set; }
        public IViewComponentResult Invoke()
        {
            menuItems = new List<MenuItem>
            {
                new MenuItem{controllerName="Home", methodName="Index", itemText="Lab 2"},
                new MenuItem{controllerName="Loot", methodName="Index", itemText="Catalog"},
                new MenuItem{isRazorPage=true, areaName="Admin", pageName="/Index", itemText="Administration"},
                new MenuItem{isRazorPage=true, areaName="ApiDemo", pageName="/Index", itemText="API Demo"}
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
