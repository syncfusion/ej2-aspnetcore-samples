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
        public IActionResult SplineArea()
        {
            List<SplineAreaChartData> ChartPoints = new List<SplineAreaChartData>
            {
                new SplineAreaChartData { Period = new DateTime(2002, 01, 01), US_InflationRate = 2.2, FR_InflationRate = 2, GER_InflationRate = 0.8  },
                new SplineAreaChartData { Period = new DateTime(2003, 01, 01), US_InflationRate = 3.4, FR_InflationRate = 1.7, GER_InflationRate = 1.3 },
                new SplineAreaChartData { Period = new DateTime(2004, 01, 01), US_InflationRate = 2.8, FR_InflationRate = 1.8, GER_InflationRate = 1.1 },
                new SplineAreaChartData { Period = new DateTime(2005, 01, 01), US_InflationRate = 1.6, FR_InflationRate = 2.1, GER_InflationRate = 1.6 },
                new SplineAreaChartData { Period = new DateTime(2006, 01, 01), US_InflationRate = 2.3, FR_InflationRate = 2.3, GER_InflationRate = 2 },
                new SplineAreaChartData { Period = new DateTime(2007, 01, 01), US_InflationRate = 2.5, FR_InflationRate = 1.7, GER_InflationRate = 1.7 },
                new SplineAreaChartData { Period = new DateTime(2008, 01, 01), US_InflationRate = 2.9, FR_InflationRate = 1.5, GER_InflationRate = 2.3 },
                new SplineAreaChartData { Period = new DateTime(2009, 01, 01), US_InflationRate = 1.1, FR_InflationRate = 0.5, GER_InflationRate = 2.7 },
                new SplineAreaChartData { Period = new DateTime(2010, 01, 01), US_InflationRate = 1.4, FR_InflationRate = 1.5, GER_InflationRate = 1.1 },
                new SplineAreaChartData { Period = new DateTime(2011, 01, 01), US_InflationRate = 1.1, FR_InflationRate = 1.3, GER_InflationRate = 1.5 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class SplineAreaChartData
        {
            public DateTime Period;
            public double US_InflationRate;
            public double FR_InflationRate;
            public double GER_InflationRate;
        }
    }
}