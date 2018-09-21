using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult Stripline()
        {
            List<SymbolsData> chartData = new List<SymbolsData>
            {
                new SymbolsData { x = "Sun", y = 25},
                new SymbolsData { x = "Mon", y = 27},
                new SymbolsData { x = "Tue", y = 33},
                new SymbolsData { x = "Wed", y = 36},
                new SymbolsData { x = "Thu", y = 26},
                new SymbolsData { x = "Fri", y = 37.5},
                new SymbolsData { x = "Sat", y = 23}
            };
            ViewBag.dataSource = chartData;          

            ViewBag.mode = new String[] { "Vertical", "Horizontal", "Segment" };
            return View();
        }        
  

    }
}