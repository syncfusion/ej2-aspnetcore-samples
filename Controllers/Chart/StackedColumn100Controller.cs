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
        public IActionResult StackedColumn100()
        {
            List<StackedColumnChartData100> chartData = new List<StackedColumnChartData100>
            {
                    new StackedColumnChartData100 { x= "2014", y= 111.1 },
                    new StackedColumnChartData100 { x= "2015", y= 127.3 },
                    new StackedColumnChartData100 { x= "2016", y= 143.4 },
                    new StackedColumnChartData100 { x= "2017", y= 159.9 }
            };
            ViewBag.dataSource = chartData;
            List<StackedColumnChartData100> chartData1 = new List<StackedColumnChartData100>
            {
                    new StackedColumnChartData100 { x= "2014", y= 76.9 },
                    new StackedColumnChartData100 { x= "2015", y= 99.5 },
                    new StackedColumnChartData100 { x= "2016", y= 121.7 },
                    new StackedColumnChartData100 { x= "2017", y= 142.5 }
            };
            ViewBag.dataSource1 = chartData1;
            List<StackedColumnChartData100> chartData2 = new List<StackedColumnChartData100>
            {
                    new StackedColumnChartData100 { x= "2014", y= 66.1 },
                    new StackedColumnChartData100 { x= "2015", y= 79.3 },
                    new StackedColumnChartData100 { x= "2016", y= 91.3 },
                    new StackedColumnChartData100 { x= "2017", y= 102.4 }
            };
            ViewBag.dataSource2 = chartData2;
            List<StackedColumnChartData100> chartData3 = new List<StackedColumnChartData100>
            {
                    new StackedColumnChartData100 { x= "2014", y= 34.1 },
                    new StackedColumnChartData100 { x= "2015", y= 38.2 },
                    new StackedColumnChartData100 { x= "2016", y= 44.0 },
                    new StackedColumnChartData100 { x= "2017", y= 51.6 }
            };
            ViewBag.dataSource3 = chartData3;
            return View();
        }
        public class StackedColumnChartData100
        {
            public string x;
            public double y;
        }
    }
}