#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using static EJ2CoreSampleBrowser.Controllers.Chart.ChartController;

namespace EJ2CoreSampleBrowser_NET6.Controllers.ThreeDimensionsChart
{
    public partial class ThreeDimensionsChartController : Controller
    {
        public IActionResult StackedBar()
        {
            List<StackedBarChartData> ChartPoints = new List<StackedBarChartData>
            {
                new StackedBarChartData { X = "Sochi 2014",        Y = 9,   Y1 = 10,  Y2 = 4,  Y3 = 8 },
                new StackedBarChartData { X = "Rio 2016",          Y = 46,  Y1 = 4,   Y2 = 10, Y3 = 17 },
                new StackedBarChartData { X = "Pyeongchang 2018",  Y = 9,   Y1 = 11,  Y2 = 5,  Y3 = 14 },
                new StackedBarChartData { X = "Tokyo 2020",        Y = 39,  Y1 = 7,   Y2 = 10, Y3 = 10 },
                new StackedBarChartData { X = "Beijing 2022",      Y = 8,   Y1 = 4,   Y2 = 5,  Y3 = 12 }
            };
            bool isMobile = Request.Headers["User-Agent"].ToString().Contains("Mobi");
            if (isMobile)
            {
                ChartPoints[2].X = "Pyeongchang<br> 2018";
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class StackedBarChartData
        {
            public string X;
            public double Y;
            public double Y1;
            public double Y2;
            public double Y3;
        }
    }
}
