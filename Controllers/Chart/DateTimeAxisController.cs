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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {

        public IActionResult DateTimeAxis()
        {
            List<DateTimeData> ChartPoints = new List<DateTimeData>
            {
                new DateTimeData { Period = new DateTime(2016, 3, 07), MaxTemp = 6.3,  MinTemp = -5.3},
                new DateTimeData { Period = new DateTime(2016, 4, 15), MaxTemp = 13.3, MinTemp = 1.0 },
                new DateTimeData { Period = new DateTime(2016, 5, 10), MaxTemp = 18.0, MinTemp = 6.9 },
                new DateTimeData { Period = new DateTime(2016, 6, 17), MaxTemp = 19.8, MinTemp = 9.4 },
                new DateTimeData { Period = new DateTime(2016, 7, 13), MaxTemp = 18.1, MinTemp = 7.6 },
                new DateTimeData { Period = new DateTime(2016, 8, 11), MaxTemp = 13.1, MinTemp = 2.6 },
                new DateTimeData { Period = new DateTime(2016, 9, 16), MaxTemp = 4.1,  MinTemp = -4.9 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }

        public class DateTimeData
        {
            public DateTime Period;
            public double MaxTemp;
            public double MinTemp;
        }
    }
}
