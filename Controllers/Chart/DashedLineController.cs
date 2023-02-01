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

        public IActionResult DashedLine()
        {
            List<DashedLineChartData> chartData = new List<DashedLineChartData>
            {
                new DashedLineChartData { xValue = new DateTime(2005, 01, 01), yValue = 12, yValue1 = 9.5 },
                new DashedLineChartData { xValue = new DateTime(2006, 01, 01), yValue = 10.6, yValue1 = 19.9 },
                new DashedLineChartData { xValue = new DateTime(2007, 01, 01), yValue = 15.6, yValue1 = 25.2 },
                new DashedLineChartData { xValue = new DateTime(2008, 01, 01), yValue = 38.6, yValue1 = 36 },
                new DashedLineChartData { xValue = new DateTime(2009, 01, 01), yValue = 27.4, yValue1 = 16.6 },
                new DashedLineChartData { xValue = new DateTime(2010, 01, 01), yValue = 23.5, yValue1 = 14.2 },
                new DashedLineChartData { xValue = new DateTime(2011, 01, 01), yValue = 16.6, yValue1 = 10.3 },
            };
            ViewBag.dashedDataSource = chartData;
            return View();
        }

        public class DashedLineChartData
        {
            public DateTime xValue;
            public double yValue;
            public double yValue1;
        }
    }
}
