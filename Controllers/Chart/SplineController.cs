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

        public IActionResult Spline()
        {
            List<SplineChartData> SplineData = new List<SplineChartData>
            {
                new SplineChartData { Days = "Sun", MaxTemp = 15, AvgTemp = 10, MinTemp = 2 },
                new SplineChartData { Days = "Mon", MaxTemp = 22, AvgTemp = 18, MinTemp = 12 },
                new SplineChartData { Days = "Tue", MaxTemp = 32, AvgTemp = 28, MinTemp = 22 },
                new SplineChartData { Days = "Wed", MaxTemp = 31, AvgTemp = 28, MinTemp = 23 },
                new SplineChartData { Days = "Thu", MaxTemp = 29, AvgTemp = 26, MinTemp = 19 },
                new SplineChartData { Days = "Fri", MaxTemp = 24, AvgTemp = 20, MinTemp = 13 },
                new SplineChartData { Days = "Sat", MaxTemp = 18, AvgTemp = 15, MinTemp = 8 }
            };
            ViewBag.SplineData = SplineData;
            return View();
        }

        public class SplineChartData
        {
            public string Days;
            public double MaxTemp;
            public double AvgTemp;
            public double MinTemp;
        }
    }
}
