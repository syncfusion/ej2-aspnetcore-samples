using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.SparkLine
{
    public partial class SparkLineController : Controller
    {
        public IActionResult AxisTypes()
        {
            return View();
        }
    }
}