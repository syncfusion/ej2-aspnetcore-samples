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
        public IActionResult PolarStackedArea()
        {
            List<PolarStackedAreaData> data = new List<PolarStackedAreaData>
            {
                   new PolarStackedAreaData { x = "JPN", y= 5156, y1= 4849, y2= 4382, y3= 4939 },
                   new PolarStackedAreaData { x= "DEU", y= 3754, y1= 3885, y2= 3365, y3= 3467 },
                   new PolarStackedAreaData { x = "FRA", y = 2809, y1= 2844, y2= 2420, y3= 2463 },
                   new PolarStackedAreaData { x = "GBR", y= 2721, y1= 3002, y2= 2863, y3= 2629 },
                   new PolarStackedAreaData { x = "BRA", y= 2472, y1= 2456, y2= 1801, y3= 1799 },
                   new PolarStackedAreaData { x = "RUS", y= 2231, y1= 2064, y2= 1366, y3= 1281 },
                   new PolarStackedAreaData { x = "ITA", y= 2131, y1= 2155, y2= 1826, y3= 1851 },
                   new PolarStackedAreaData { x = "IND", y= 1857, y1= 2034, y2= 2088, y3= 2256 },
                   new PolarStackedAreaData { x = "CAN", y= 1843, y1= 1793, y2= 1553, y3= 1529 }
            };
            ViewBag.dataSource = data;
            ViewBag.select = new string[] { "Polar", "Radar" };
            return View();
        }
        public class PolarStackedAreaData
        {
            public string x;
            public double y;
            public double y1;
            public double y2;
            public double y3;
        }
    }
}