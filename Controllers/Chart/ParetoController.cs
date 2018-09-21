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
        public IActionResult PareTo()
        {
            List<PareToData> chartData = new List<PareToData>
            {
                new PareToData { x= "Traffic", y= 56 }, 
                new PareToData { x= "Child Care", y= 44.8 },
                new PareToData { x= "Transport", y= 27.2 }, 
                new PareToData { x= "Weather", y= 19.6 },
                new PareToData { x= "Emergency", y= 6.6 }
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class PareToData
        {
            public string x;
            public double y;
        }
    }
}