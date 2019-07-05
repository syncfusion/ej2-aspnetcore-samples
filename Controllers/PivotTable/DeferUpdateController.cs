using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PivotTableController : Controller
    {

        public IActionResult DeferUpdate()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.drilledMembers = new string[] { "France", "Germany", "United States" };
            ViewBag.filterMembers = new string[] { "Gloves", "Helmets", "Shorts", "Vests" };
            return View();
        }
    }
}
