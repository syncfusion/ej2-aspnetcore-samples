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

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult Area()
        {
            List<AreaChartData> chartData = new List<AreaChartData>
            {
                new AreaChartData { xValue = new DateTime(2000, 01, 01), yValue = 4, yValue1 = 2.6 },
                new AreaChartData { xValue = new DateTime(2001, 01, 01), yValue = 3.0, yValue1 = 2.8 },
                new AreaChartData { xValue = new DateTime(2002, 01, 01), yValue = 3.8, yValue1 = 2.6 },
                new AreaChartData { xValue = new DateTime(2003, 01, 01), yValue = 3.4, yValue1 = 3 },
                new AreaChartData { xValue = new DateTime(2004, 01, 01), yValue = 3.2, yValue1 = 3.6 },
                new AreaChartData { xValue = new DateTime(2005, 01, 01), yValue = 3.9, yValue1 = 3 },
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class AreaChartData
        {
            public DateTime xValue;
            public double yValue;
            public double yValue1;
        }
    }
}