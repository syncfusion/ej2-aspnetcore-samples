using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.RangeNavigator
{
    public partial class RangeNavigatorController : Controller
    {
        public IActionResult Export()
        {
            ViewBag.mode = new string[] { "JPEG", "PNG", "SVG", "PDF" };
            return View();
        }
    }
}