#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
namespace EJ2CoreSampleBrowser_NET6.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult SplineUpdate()
        {
            List<SplineUpdateChartData> ChartPoints = new List<SplineUpdateChartData>
            {
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 3),   Y = 42 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 5),   Y = 52 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 7),   Y = 83 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 9),   Y = 75 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 11),  Y = 35 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 13),  Y = 85 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 15),  Y = 78 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 17),  Y = 29 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 19),  Y = 62 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 21),  Y = 95 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 23),  Y = 32 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 25),  Y = 76 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 27),  Y = 83 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 29),  Y = 53 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 31),  Y = 32 },
               new SplineUpdateChartData { X = new DateTime(2024, 06, 06, 6, 7, 33),  Y = 75 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class SplineUpdateChartData
        {
            public DateTime X;
            public double Y;
        }
    }
}
