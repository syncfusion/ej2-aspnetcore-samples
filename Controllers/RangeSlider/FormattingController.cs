using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RangeSliderController : Controller
    {
        public IActionResult Formatting()
        {
            ViewBag.currencyValue = new int[] { 20, 80 };
            ViewBag.kilometerValue = new int[] { 1100, 1850 };
            ViewBag.timeValue = new decimal[] { 1373697000000, 1373718600000 };
            return View();
        }
    }
}
