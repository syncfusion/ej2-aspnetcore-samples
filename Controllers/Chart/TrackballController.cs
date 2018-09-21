using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {

        public IActionResult Trackball()
        {
            List<TrackballChartData> chartData = new List<TrackballChartData>
            {
                new TrackballChartData { xValue = new DateTime(2000, 2, 11), yValue = 14, yValue1 = 39, yValue2 = 60 },
                new TrackballChartData { xValue = new DateTime(2000, 9, 4), yValue = 20, yValue1 = 30, yValue2 = 55 },
                new TrackballChartData { xValue = new DateTime(2001, 2, 11), yValue = 25, yValue1 = 28, yValue2 = 48 },
                new TrackballChartData { xValue = new DateTime(2001, 9, 16), yValue = 21, yValue1 = 35, yValue2 = 57 },
                new TrackballChartData { xValue = new DateTime(2002, 2, 7), yValue = 13, yValue1 = 39, yValue2 = 62 },
                new TrackballChartData { xValue = new DateTime(2002, 9, 7), yValue = 18, yValue1 = 41, yValue2 = 64 },
                new TrackballChartData { xValue = new DateTime(2003, 2, 11), yValue = 24, yValue1 = 45, yValue2 = 57 },
                new TrackballChartData { xValue = new DateTime(2003, 9, 14), yValue = 23, yValue1 = 48, yValue2 = 53 },
                new TrackballChartData { xValue = new DateTime(2004, 2, 6), yValue = 19, yValue1 = 54, yValue2 = 63 },
                new TrackballChartData { xValue = new DateTime(2004, 9, 6), yValue = 31, yValue1 = 55, yValue2 = 50 },
                new TrackballChartData { xValue = new DateTime(2005, 2, 11), yValue = 39, yValue1 = 57, yValue2 = 66 },
                new TrackballChartData { xValue = new DateTime(2005, 9, 11), yValue = 50, yValue1 = 60, yValue2 = 65 },
                new TrackballChartData { xValue = new DateTime(2006, 2, 11), yValue = 24, yValue1 = 60, yValue2 = 79 },
            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class TrackballChartData
        {
            public DateTime xValue;
            public double yValue;
            public double yValue1;
            public double yValue2;
        }
    }
}
