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
                  new RoundedColumnChartData { x= "Egg", y= 106, text= "Egg" },
                  new RoundedColumnChartData { x= "Fish", y= 103, text= "Fish" },
                  new RoundedColumnChartData { x= "Misc", y= 198, text= "Misc" },
                  new RoundedColumnChartData { x= "Tea", y= 189, text= "Tea" },
                  new RoundedColumnChartData { x= "Fruits", y= 250, text= "Fruits" }
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