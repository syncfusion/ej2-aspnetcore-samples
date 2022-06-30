#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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

        public IActionResult Spline()
        {
            List<SplineChartData> chartData = new List<SplineChartData>
            {
                new SplineChartData { xValue = "Sun", yValue = 15, yValue1 = 10, yValue2 = 2 },
                new SplineChartData { xValue = "Mon", yValue = 22, yValue1 = 18, yValue2 = 12 },
                new SplineChartData { xValue = "Tue", yValue = 32, yValue1 = 28, yValue2 = 22 },
                new SplineChartData { xValue = "Wed", yValue = 31, yValue1 = 28, yValue2 = 23 },
                new SplineChartData { xValue = "Thu", yValue = 29, yValue1 = 26, yValue2 = 19 },
                new SplineChartData { xValue = "Fri", yValue = 24, yValue1 = 20, yValue2 = 13 },
                new SplineChartData { xValue = "Sat", yValue = 18, yValue1 = 15, yValue2 = 8 },
            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class SplineChartData
        {
            public string xValue;
            public double yValue;
            public double yValue1;
            public double yValue2;
        }
    }
}
