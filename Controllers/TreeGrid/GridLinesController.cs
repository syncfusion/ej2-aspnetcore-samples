using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class TreeGridController : Controller
    {
        public IActionResult GridLines()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            ViewBag.dropdata = new List<object>() {
               new { id= "Vertical", mode= "Vertical" },
               new { id= "Horizontal", mode= "Horizontal" },
               new { id= "Both", mode= "Both" },
               new { id= "None", mode= "None" },
            };
            return View();
        }
    }
}