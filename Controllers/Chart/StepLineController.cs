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

        public IActionResult StepLine()
        {
            List<StepLineChartData> chartData = new List<StepLineChartData>
            {
                new StepLineChartData { xValue = new DateTime(1975, 01, 01), yValue = 16, yValue1 = 10 },
                new StepLineChartData { xValue = new DateTime(1980, 01, 01), yValue = 12.5, yValue1 = 7.5 },
                new StepLineChartData { xValue = new DateTime(1985, 01, 01), yValue = 19, yValue1 = 11 },
                new StepLineChartData { xValue = new DateTime(1990, 01, 01), yValue = 14.4, yValue1 = 7 },
                new StepLineChartData { xValue = new DateTime(1995, 01, 01), yValue = 11.5, yValue1 = 8 },
                new StepLineChartData { xValue = new DateTime(2000, 01, 01), yValue = 14, yValue1 = 6 },
                new StepLineChartData { xValue = new DateTime(2005, 01, 01), yValue = 10, yValue1 = 3.5 },
                new StepLineChartData { xValue = new DateTime(2010, 01, 01), yValue = 16, yValue1 = 7 },
            };                                   
            ViewBag.dataSource = chartData;
            return View();
        }

        public class StepLineChartData
        {
            public DateTime xValue;
            public double yValue;
            public double yValue1;
        }
    }
}
