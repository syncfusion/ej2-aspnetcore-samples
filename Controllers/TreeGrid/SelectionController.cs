using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class TreeGridController : Controller
    {
       
        public IActionResult Selection()
        {
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            ViewBag.typedata = new List<object>() {
               new { id= "Single", type= "Single" },
               new { id= "Multiple", type= "Multiple" }
            };
            ViewBag.modedata = new List<object>() {
               new { id= "Row", mode= "Row" },
               new { id= "Cell", mode= "Cell" }
            };
            ViewBag.cellmodedata = new List<object>() {
               new { id= "Flow", cellmode= "Flow" },
               new { id= "Box", cellmode= "Box" }
            };
            return View();
        }       
    }
}