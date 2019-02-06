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
       
        public IActionResult PagingAPI()
        {
            ViewBag.dropdata = new List<object>() {
               new { id= "All", mode= "All" },
               new { id= "Root", mode= "Root" }
            };
            var order = TreeData.GetDefaultData();
            ViewBag.dataSource = order;
            return View();
        }       
    }
}