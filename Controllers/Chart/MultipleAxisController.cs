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

        public IActionResult MultipleAxis()
        {
            List<MultipleAxesChartData> ChartPoints = new List<MultipleAxesChartData>
            {
                new MultipleAxesChartData { Day = "SUN", DEU_Temp = 35, JPN_Temp = 31 },
                new MultipleAxesChartData { Day = "MON", DEU_Temp = 40, JPN_Temp = 28 },
                new MultipleAxesChartData { Day = "TUE", DEU_Temp = 50, JPN_Temp = 29 },
                new MultipleAxesChartData { Day = "WED", DEU_Temp = 70, JPN_Temp = 30 },
                new MultipleAxesChartData { Day = "THU", DEU_Temp = 65, JPN_Temp = 33 },
                new MultipleAxesChartData { Day = "FRI", DEU_Temp = 55, JPN_Temp = 32},
                new MultipleAxesChartData { Day = "SAT", DEU_Temp = 50, JPN_Temp = 34 },          
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class MultipleAxesChartData
        {
            public string Day;
            public double DEU_Temp;
            public double JPN_Temp;
        }
    }
}
