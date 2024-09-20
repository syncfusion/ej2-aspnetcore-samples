#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
        public IActionResult AreaEmpty()
        {
            List<AreaEmptyChartData> ChartPoints = new List<AreaEmptyChartData>
            {
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 15), US_InflationRate = 2.2, IN_InflationRate = 0.8 },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 16), US_InflationRate = 2.0, IN_InflationRate = 1.7 },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 17), US_InflationRate = 2.8, IN_InflationRate = 1.8 },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 18), US_InflationRate = 1.6, IN_InflationRate = 2.1 },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 19), US_InflationRate = 2.3, IN_InflationRate = Double.NaN },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 20), US_InflationRate = 2.5, IN_InflationRate = 2.3 },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 21), US_InflationRate = 2.9, IN_InflationRate = 1.7 },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 22), US_InflationRate = 1.1, IN_InflationRate = 1.5 },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 23), US_InflationRate = 1.4, IN_InflationRate = 0.5 },
                new AreaEmptyChartData { Period = new DateTime(2021, 11, 24), US_InflationRate = 1.1, IN_InflationRate = 1.3 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class AreaEmptyChartData
        {
            public DateTime Period;
            public double US_InflationRate;
            public double IN_InflationRate;
        }
    }
}