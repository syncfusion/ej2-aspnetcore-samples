using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.LinearGauge
{
    public partial class LinearGaugeController : Controller
    {
        public IActionResult Axes()
        {
            return View();
        }
    }
}