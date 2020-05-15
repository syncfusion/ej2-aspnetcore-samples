using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.ProgressBar
{
    public partial class ProgressBarController : Controller
    {
        public IActionResult Segment()
        {
            ViewBag.color = new string[] { "#47a85c", "#0662c4", "#ed61d6", "#edb761" };
            ViewBag.color1 = new string[] { "#c0b0f5", "#b39ff5", "#a48cf5", "#8d6ff2", "#7653ed" };
            return View();
        }
    }
}