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
        public IActionResult RangeColumn()
        {
            List<RangeColumnChartData> chartData = new List<RangeColumnChartData>
            {
               new RangeColumnChartData { x= "Sun", low= 3.1, high= 10.8 },
               new RangeColumnChartData { x= "Mon", low= 5.7, high= 14.4 }, 
               new RangeColumnChartData { x= "Tue", low= 8.4, high= 16.9 },
               new RangeColumnChartData { x= "Wed", low= 10.6, high= 19.2 },
               new RangeColumnChartData { x= "Thu", low= 8.5, high= 16.1 }, 
               new RangeColumnChartData { x= "Fri", low= 6.0, high= 12.5 },
               new RangeColumnChartData { x= "Sat", low= 1.5, high= 6.9 }
            };
            ViewBag.dataSource = chartData;
            List<RangeColumnChartData> chartData1 = new List<RangeColumnChartData>
            {
                new RangeColumnChartData { x= "Sun", low= 2.5, high= 9.8 },
                new RangeColumnChartData { x= "Mon", low= 4.7, high= 11.4 },
                new RangeColumnChartData { x= "Tue", low= 6.4, high= 14.4 },
                new RangeColumnChartData { x= "Wed", low= 9.6, high= 17.2 },
                new RangeColumnChartData { x= "Thu", low= 7.5, high= 15.1 },
                new RangeColumnChartData { x= "Fri", low= 3.0, high= 10.5 },
                new RangeColumnChartData { x= "Sat", low= 1.2, high= 7.9 }
            };
            ViewBag.dataSource1 = chartData1;
            return View();
        }
        public class RangeColumnChartData
        {
            public string x;
            public double low;
            public double high;
        }
    }
}