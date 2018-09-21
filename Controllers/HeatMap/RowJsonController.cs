using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.HeatMap
{
    public partial class HeatMapController : Controller
    {
        public IActionResult RowJson()
        {
            return View();
        }
    }
}