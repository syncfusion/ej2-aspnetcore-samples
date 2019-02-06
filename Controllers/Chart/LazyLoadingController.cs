using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult LazyLoading()
        {
            ViewBag.type = new String[] { "Range", "Points Length" };
            ViewBag.min = new DateTime(2009, 1, 1);
            ViewBag.max = new DateTime(2014, 1, 1);
            return View();
        }
    }
}