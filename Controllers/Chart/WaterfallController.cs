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
        public IActionResult Waterfall()
        {
            List<WaterfallChartData> chartData = new List<WaterfallChartData>
            {
                    new WaterfallChartData { x= "Income", y= 4711 },
                    new WaterfallChartData { x= "Sales", y= -1015 },
                    new WaterfallChartData { x= "Development", y= -688 },
                    new WaterfallChartData { x= "Revenue", y= 1030 },
                    new WaterfallChartData { x= "Balance" },
                    new WaterfallChartData { x= "Expense", y= -361 },
                    new WaterfallChartData { x= "Tax", y= -695 },
                    new WaterfallChartData { x= "Net Profit" }
            };
            ViewBag.dataSource = chartData;
            ViewBag.intermediateSumIndexes = new int[] {4};
            ViewBag.sumIndexes = new int[] {7};
            return View();
        }
        public class WaterfallChartData {
            public string x;
            public double y;
        }
    }
}