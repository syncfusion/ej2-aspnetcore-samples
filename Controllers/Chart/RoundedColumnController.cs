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
        public IActionResult RoundedColumn()
        {
            List<RoundedColumnChartData> chartData = new List<RoundedColumnChartData>
            {
                  new RoundedColumnChartData { x= "BGD", y= 106, text= "Bangaladesh" },
                  new RoundedColumnChartData { x= "BTN", y= 103, text= "Bhutn" },
                  new RoundedColumnChartData { x= "NPL", y= 198, text= "Nepal" },
                  new RoundedColumnChartData { x= "THA", y= 189, text= "Thiland" },
                  new RoundedColumnChartData { x= "MYS", y= 250, text= "Malaysia" }
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class RoundedColumnChartData
        {
            public string x;
            public double y;
            public string text;
        }
    }
}