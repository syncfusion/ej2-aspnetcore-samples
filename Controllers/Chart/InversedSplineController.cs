#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

        public IActionResult InversedSpline()
        {
            List<InversedLineChartData> chartData = new List<InversedLineChartData>
            {
                new InversedLineChartData { xValue = "Jan", yValue = -1, yValue1 = 7 },
                new InversedLineChartData { xValue = "Mar", yValue = 12, yValue1 = 2 },
                new InversedLineChartData { xValue = "Apr", yValue = 25, yValue1 = 13 },
                new InversedLineChartData { xValue = "Jun", yValue = 31, yValue1 = 21 },
                new InversedLineChartData { xValue = "Aug", yValue = 26, yValue1 = 26 },
                new InversedLineChartData { xValue = "Oct", yValue = 14, yValue1 = 10 },
                new InversedLineChartData { xValue = "Dec", yValue = 8, yValue1 = 0 },
            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class InversedLineChartData
        {
            public String xValue;
            public double yValue;
            public double yValue1;
        }
    }
}
