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

        public IActionResult Olap()
        {
            ViewBag.filterMembers = new string[] { "[Date].[Fiscal].[Fiscal Quarter].&[2002]&[4]", "[Date].[Fiscal].[Fiscal Year].&[2005]" };
            return View();
        }
    }
}
