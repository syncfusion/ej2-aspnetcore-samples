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

        public IActionResult DateTimeAxis()
        {
            List<DateTimeData> chartData = new List<DateTimeData>
            {
                new DateTimeData { xValue = new DateTime(2016, 3, 1), yValue1 = 6.3, yValue2 = -5.3},
                new DateTimeData { xValue = new DateTime(2016, 4, 1), yValue1 = 13.3, yValue2 = 1.0 },
                new DateTimeData { xValue = new DateTime(2016, 5, 1), yValue1 = 18.0, yValue2 = 6.9 },
                new DateTimeData { xValue = new DateTime(2016, 6, 1), yValue1 = 19.8, yValue2 = 9.4 },
                new DateTimeData { xValue = new DateTime(2016, 7, 1), yValue1 = 18.1, yValue2 = 7.6 },
                new DateTimeData { xValue = new DateTime(2016, 8, 1), yValue1 = 13.1, yValue2 = 2.6 },
                new DateTimeData { xValue = new DateTime(2016, 9, 1), yValue1 = 4.1, yValue2 = -4.9 },
                            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class DateTimeData
        {
            public DateTime xValue;
            public double yValue1;
            public double yValue2;
        }
    }
}
