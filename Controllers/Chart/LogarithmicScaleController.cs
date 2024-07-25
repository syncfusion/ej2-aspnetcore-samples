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

        public IActionResult LogarithmicScale()
        {
            List<LogarithmicScaleChartData> ChartPoints = new List<LogarithmicScaleChartData>
            {
                new LogarithmicScaleChartData { Period = new DateTime(1995, 1, 1),  ProfitInfo = 80  },
                new LogarithmicScaleChartData { Period = new DateTime(1996, 1, 1),  ProfitInfo = 200 },
                new LogarithmicScaleChartData { Period = new DateTime(1997, 1, 1),  ProfitInfo = 400 },
                new LogarithmicScaleChartData { Period = new DateTime(1998, 1, 1),  ProfitInfo = 600 },
                new LogarithmicScaleChartData { Period = new DateTime(1999, 1, 1),  ProfitInfo = 700 },
                new LogarithmicScaleChartData { Period = new DateTime(2000, 1, 1),  ProfitInfo = 1400 },
                new LogarithmicScaleChartData { Period = new DateTime(2001, 1, 1),  ProfitInfo = 2000 },
                new LogarithmicScaleChartData { Period = new DateTime(2002, 1, 1),  ProfitInfo = 4000 },
                new LogarithmicScaleChartData { Period = new DateTime(2003, 1, 1),  ProfitInfo = 6000 },
                new LogarithmicScaleChartData { Period = new DateTime(2004, 1, 1),  ProfitInfo = 8000 },
                new LogarithmicScaleChartData { Period = new DateTime(2005, 1, 1),  ProfitInfo = 11000 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class LogarithmicScaleChartData
        {
            public DateTime Period;
            public double ProfitInfo;
        }
    }
}
