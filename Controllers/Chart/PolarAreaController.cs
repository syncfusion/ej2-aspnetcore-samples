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
        public IActionResult PolarArea()
        {
            List<PolarAreaChartData> chartData = new List<PolarAreaChartData>
            {
                new PolarAreaChartData { x= "2000", y= 4 }, 
                new PolarAreaChartData { x= "2001", y= 3.0 },
                new PolarAreaChartData { x= "2002", y= 3.8 }, 
                new PolarAreaChartData { x= "2003", y= 3.4 },
                new PolarAreaChartData { x= "2004", y= 3.2 }, 
                new PolarAreaChartData { x= "2005", y= 3.9 }
            };
            ViewBag.dataSource = chartData;
            List<PolarAreaChartData> chartData1= new List<PolarAreaChartData>
            {
                new PolarAreaChartData { x= "2000", y= 2.6 }, 
                new PolarAreaChartData { x= "2001", y= 2.8 },
                new PolarAreaChartData { x= "2002", y= 2.6 }, 
                new PolarAreaChartData { x= "2003", y= 3 },
                new PolarAreaChartData { x= "2004", y= 3.6 }, 
                new PolarAreaChartData { x= "2005", y= 3 }
            };
            ViewBag.dataSource1 = chartData1;
            List<PolarAreaChartData> chartData2 = new List<PolarAreaChartData>
            {
                new PolarAreaChartData { x= "2000", y= 2.8 },
                new PolarAreaChartData { x= "2001", y= 2.5 },
                new PolarAreaChartData { x= "2002", y= 2.8 },
                new PolarAreaChartData { x= "2003", y= 3.2 },
                new PolarAreaChartData { x= "2004", y= 2.9 },
                new PolarAreaChartData { x= "2005", y= 2 }
            };
            ViewBag.dataSource2 = chartData2;
            ViewBag.select = new string[] { "Polar", "Radar" };
            return View();
        }
        public class PolarAreaChartData
        {
            public string x;
            public double y;
        }
    }
}