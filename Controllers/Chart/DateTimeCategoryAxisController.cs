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

        public IActionResult DateTimeCategoryAxis()
        {
            List<DateTimeData> chartData = new List<DateTimeData>
            {
                new DateTimeData { xValue = new DateTime(2017, 12, 20), yValue1 = 21},
                new DateTimeData { xValue = new DateTime(2017, 12, 21), yValue1 = 24 },
                new DateTimeData { xValue = new DateTime(2017, 12, 22), yValue1 = 24},
                new DateTimeData { xValue = new DateTime(2017, 12, 26), yValue1 = 70},
                new DateTimeData { xValue = new DateTime(2017, 12, 27), yValue1 = 75 },
                new DateTimeData { xValue = new DateTime(2018, 1, 2), yValue1 = 82 },
                new DateTimeData { xValue = new DateTime(2018, 1, 3), yValue1 = 53 },
                new DateTimeData { xValue = new DateTime(2018, 1, 4), yValue1 = 54 },
                new DateTimeData { xValue = new DateTime(2018, 1, 5), yValue1 = 53},
                new DateTimeData { xValue = new DateTime(2018, 1, 8), yValue1 = 45 },
            };
            ViewBag.dataSource = chartData;
            return View();
        }        
    }
}
