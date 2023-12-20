#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET6.Controllers.ThreeDimensionsChart
{
    public partial class ThreeDimensionsChartController : Controller
    {
        public IActionResult Cylinder()
        {
            List<CylinderChartData> ChartPoints = new List<CylinderChartData>
            {
                new CylinderChartData { X = "Czechia",     Y = 1.11 },
                new CylinderChartData { X = "Spain",       Y = 1.66 },
                new CylinderChartData { X = "USA",         Y = 1.56 },
                new CylinderChartData { X = "Germany",     Y = 3.1  },
                new CylinderChartData { X = "Russia",      Y = 1.35 },
                new CylinderChartData { X = "Slovakia",    Y = 1    },
                new CylinderChartData { X = "South Korea", Y = 3.16 },
                new CylinderChartData { X = "France",      Y = 0.92 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class CylinderChartData
        {
            public string X;
            public double Y;
        }
    }
}
