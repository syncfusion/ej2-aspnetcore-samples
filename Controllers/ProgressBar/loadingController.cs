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
        public IActionResult Loading()
        {
            return View();
        }
    }
}