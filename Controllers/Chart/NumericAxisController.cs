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

        public IActionResult NumericAxis()
        {
            List<DoubleData> chartData = new List<DoubleData>
            {
                new DoubleData { xValue = 16, yValue1 = 2, yValue2= 7},
                new DoubleData { xValue = 17, yValue1 = 14, yValue2 = 7 },
                new DoubleData { xValue = 18, yValue1 = 7, yValue2 = 11 },
                new DoubleData { xValue = 19, yValue1 = 7, yValue2 = 8 },
                new DoubleData { xValue = 20, yValue1 = 10, yValue2 = 24 },
                            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class DoubleData
        {
            public double xValue;
            public double yValue1;
            public double yValue2;
        }
    }
}
