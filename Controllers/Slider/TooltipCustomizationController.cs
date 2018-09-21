using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Slider
{
    public partial class SliderController : Controller
    {
        // GET: /<controller>/
        public IActionResult TooltipCustomization()
        {
            ViewBag.timeValue = new decimal[] { 1373697000000, 1373718600000 };
            return View();
        }
    }
}
