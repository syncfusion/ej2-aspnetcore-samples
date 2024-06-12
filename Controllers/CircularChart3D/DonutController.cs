#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser_NET6.Controllers.CircularChart3D
{
    public partial class CircularChart3DController : Controller
    {
        public IActionResult Donut()
        {
            List<DonutChartData> ChartPoints = new List<DonutChartData>
            {
                new DonutChartData { X = "Tesla",   Y = 137429 },
                new DonutChartData { X = "Aion",    Y = 80308 },
                new DonutChartData { X = "Wuling",  Y = 76418 },
                new DonutChartData { X = "Changan", Y = 52849 },
                new DonutChartData { X = "Geely",   Y = 47234 },
                new DonutChartData { X = "Nio",     Y = 31041 },
                new DonutChartData { X = "Neta",    Y = 22449 },
                new DonutChartData { X = "BMW",     Y = 18733 }
            };
            ViewBag.ChartData = ChartPoints;
            return View();
        }
        public class DonutChartData
        {
            public string X;
            public double Y;
        }
    }
}
