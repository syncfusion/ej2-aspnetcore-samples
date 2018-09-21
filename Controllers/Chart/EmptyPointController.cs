using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult EmptyPoint()
        {
            ViewBag.data = new string[] { "Column", "Area", "Spline" };
            ViewBag.data1 = new string[] { "Gap", "Drop", "Average", "Zero"};
            return View();
        }
    }
}