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
        public IActionResult SplineArea()
        {
            List<SplineAreaChartData> chartData = new List<SplineAreaChartData>
            {
                new SplineAreaChartData { xValue = new DateTime(2002, 01, 01), yValue = 2.2, yValue1 = 2, yValue2 = 0.8  },
                new SplineAreaChartData { xValue = new DateTime(2003, 01, 01), yValue = 3.4, yValue1 = 1.7, yValue2 = 1.3 },
                new SplineAreaChartData { xValue = new DateTime(2004, 01, 01), yValue = 2.8, yValue1 = 1.8, yValue2 = 1.1 },
                new SplineAreaChartData { xValue = new DateTime(2005, 01, 01), yValue = 1.6, yValue1 = 2.1, yValue2 = 1.6 },
                new SplineAreaChartData { xValue = new DateTime(2006, 01, 01), yValue = 2.3, yValue1 = 2.3, yValue2 = 2 },
                new SplineAreaChartData { xValue = new DateTime(2007, 01, 01), yValue = 2.5, yValue1 = 1.7, yValue2 = 1.7 },
                new SplineAreaChartData { xValue = new DateTime(2008, 01, 01), yValue = 2.9, yValue1 = 1.5, yValue2 = 2.3 },
                new SplineAreaChartData { xValue = new DateTime(2009, 01, 01), yValue = 3.8, yValue1 = 2.8, yValue2 = 2.7 },
                new SplineAreaChartData { xValue = new DateTime(2010, 01, 01), yValue = 1.4, yValue1 = 1.5, yValue2 = 1.1 },
                new SplineAreaChartData { xValue = new DateTime(2011, 01, 01), yValue = 3.1, yValue1 = 2.3, yValue2 = 2.3 },
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class SplineAreaChartData
        {
            public DateTime xValue;
            public double yValue;
            public double yValue1;
            public double yValue2;
        }
    }
}