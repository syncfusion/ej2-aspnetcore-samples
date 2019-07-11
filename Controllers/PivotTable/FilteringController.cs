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

        public IActionResult Filtering()
        {
            ViewBag.data = new PivotTableData().GetPivot_Data();
            ViewBag.typeData = new string[] { "Include", "Exclude" }; ;
            ViewBag.fieldsData = new string[] { "Country", "Products", "Year" };
            return View();
        }
    }
}
