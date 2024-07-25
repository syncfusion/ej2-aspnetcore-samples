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
        public IActionResult PolarRangeColumn()
        {
            List<PolarRangeColumnData> ChartPoints = new List<PolarRangeColumnData>
            {
                new PolarRangeColumnData { Month = "Jan", MinTemp = 2, MaxTemp = 7 },
                new PolarRangeColumnData { Month = "Feb", MinTemp = 3, MaxTemp = 7 },
                new PolarRangeColumnData { Month = "Mar", MinTemp = 3, MaxTemp = 7 },
                new PolarRangeColumnData { Month = "Apr", MinTemp = 4, MaxTemp = 9 },
                new PolarRangeColumnData { Month = "May", MinTemp = 6, MaxTemp = 11 },
                new PolarRangeColumnData { Month = "June", MinTemp = 8,MaxTemp = 14 }
            };
            ViewBag.ChartPoints = ChartPoints;
            ViewBag.select = new string[] { "Polar", "Radar" };
            return View();
        }
        public class PolarRangeColumnData
        {
            public string Month;
            public double MinTemp;
            public double MaxTemp;
        }
    }
}