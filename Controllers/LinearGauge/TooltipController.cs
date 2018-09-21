using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.EJ2.CircularGauge;

namespace EJ2CoreSampleBrowser.Controllers.LinearGauge
{
    public partial class LinearGaugeController : Controller
    {        
        public IActionResult Tooltip()
        {
            return View();
        }
    }
}