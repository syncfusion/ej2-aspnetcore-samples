using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PivotViewController : Controller
    {

        public IActionResult ConditionalFormatting()
        {
            ViewBag.data = new PivotViewData().GetPivot_Data();
            ViewBag.drilledMembers = new string[] { "France", "Germany" };
            return View();
        }
    }
}
