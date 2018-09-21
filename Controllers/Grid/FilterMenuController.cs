using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Grid
{
    public partial class GridController : Controller
    {
        public IActionResult FilterMenu()
        {
            var order = OrdersDetails.GetAllRecords();
            ViewBag.datasource = order;
            ViewBag.filtertype = new string[] { "Menu","Excel","CheckBox"};            
            return View();
        }
    }
}