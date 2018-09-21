using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.CircularGauge
{
    public partial class CircularGaugeController : Controller
    {
        public IActionResult Annotation()
        {
            return View();
        }
    }
}