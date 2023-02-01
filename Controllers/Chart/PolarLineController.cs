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

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult PolarLine()
        {
            List<PolarLineChartData> chartData = new List<PolarLineChartData>
            {
                new PolarLineChartData { xValue = "Jan", yValue = -7.1, yValue1 = -17.4 },
                new PolarLineChartData { xValue = "Feb", yValue = -3.7, yValue1 = -15.6  },
                new PolarLineChartData { xValue = "Mar", yValue = 0.8, yValue1 = -12.3  },
                new PolarLineChartData { xValue = "Apr", yValue = 6.3, yValue1 = -5.3 },
                new PolarLineChartData { xValue = "May", yValue = 13.3, yValue1 = 1.0 },
                new PolarLineChartData { xValue = "Jun", yValue = 18.0, yValue1 =  6.9  },
                new PolarLineChartData { xValue = "Jul", yValue = 19.8 , yValue1 = 9.4 },
                new PolarLineChartData { xValue = "Aug", yValue = 18.1, yValue1 = 7.6 },
                new PolarLineChartData { xValue = "Sep", yValue = 13.1 , yValue1 = 2.6 },
                new PolarLineChartData { xValue = "Oct", yValue = 4.1, yValue1 = -4.9},
                new PolarLineChartData { xValue = "Nov", yValue = -3.8, yValue1 = -13.4 },
                new PolarLineChartData { xValue = "Dec", yValue = -6.8, yValue1 = -16.4 },
            };
            ViewBag.dataSource = chartData;
            ViewBag.data = new string[] { "Polar", "Radar" };
            return View();
        }
        public class PolarLineChartData
        {
            public string xValue;
            public double yValue;
            public double yValue1;
        }
    }
}