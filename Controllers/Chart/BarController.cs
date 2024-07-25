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
        public IActionResult Bar()
        {
            List<BarChartData> ChartPoints = new List<BarChartData>
            {
                new BarChartData { Country = "Canada",  GDP = 3.05 , WorldShare = 2.04 },
                new BarChartData { Country = "Italy", GDP = 1.50 , WorldShare = 2.40 },
                new BarChartData { Country = "Germany",  GDP = 2.22, WorldShare = 4.56 },
                new BarChartData { Country = "India", GDP = 6.68 , WorldShare = 3.28  },
                new BarChartData { Country = "France",  GDP = 1.82, WorldShare = 3.19 },
                new BarChartData { Country = "Japan",  GDP = 1.71, WorldShare = 6.02 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class BarChartData
        {
            public string Country;
            public double GDP;
            public double WorldShare;
        }
    }
}