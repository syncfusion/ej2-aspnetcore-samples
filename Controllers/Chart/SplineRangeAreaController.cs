using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Charts;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {
        public ActionResult SplineRangeArea()
        {
            List<SplineRangeAreaChartData> chartData = new List<SplineRangeAreaChartData>
            {
                new SplineRangeAreaChartData { XValue = "Jan", High1 = 14, High2 = 29, Low1 = 4 , Low2 = 19},
                new SplineRangeAreaChartData { XValue = "Feb", High1 = 17, High2 = 32, Low1 = 7, Low2 = 22},
                new SplineRangeAreaChartData { XValue = "Mar", High1 = 20, High2 = 35, Low1 = 10, Low2 = 25},
                new SplineRangeAreaChartData { XValue = "Apr", High1 = 22, High2 = 37, Low1 = 12, Low2 = 27},
                new SplineRangeAreaChartData { XValue = "May", High1 = 20, High2 = 35, Low1 = 10, Low2 = 25},
                new SplineRangeAreaChartData { XValue = "Jun", High1 = 17, High2 = 32, Low1 = 7, Low2 = 22},
                new SplineRangeAreaChartData { XValue = "Jul", High1 = 15, High2 = 30, Low1 = 5, Low2 = 20},
                new SplineRangeAreaChartData { XValue = "Aug", High1 = 17, High2 = 32, Low1 = 7, Low2 = 22},
                new SplineRangeAreaChartData { XValue = "Sep", High1 = 20, High2 = 35, Low1 = 10, Low2 = 25},
                new SplineRangeAreaChartData { XValue = "Oct", High1 = 22, High2 = 37, Low1 = 12, Low2 = 27},
                new SplineRangeAreaChartData { XValue = "Nov", High1 = 20, High2 = 35, Low1 = 10, Low2 = 25},
                new SplineRangeAreaChartData { XValue = "Dec", High1 = 17, High2 = 32, Low1 = 7, Low2 = 22},
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class SplineRangeAreaChartData
        {
            public string XValue;
            public double High1;
            public double High2;
            public double Low1;
            public double Low2;
        }
    }
}