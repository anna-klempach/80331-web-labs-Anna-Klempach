using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1_Klempach.Models
{
    public class MenuItem
    {
        public bool isRazorPage { get; set; }
        public string itemText { get; set; }
        public string controllerName { get; set; }
        public string methodName { get; set; }
        public string pageName { get; set; }
        public string areaName { get; set; }
        public string activeClassName { get; set; }
    }
}
