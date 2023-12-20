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
        public IActionResult StackedColumn()
        {
            List<StackedColumnChartData> ChartPoints = new List<StackedColumnChartData>
            {
                new StackedColumnChartData { X = "2018",  Y = 24.5, Y1 = 6.2,  Y2 = 24.5, Y3 = 15.4 },
                new StackedColumnChartData { X = "2019",  Y = 25.6, Y1 = 15.6, Y2 = 23.2, Y3 = 21.1 },
                new StackedColumnChartData { X = "2020",  Y = 29,   Y1 = 14.3, Y2 = 20.4, Y3 = 13.9 },
                new StackedColumnChartData { X = "2021",  Y = 28.5, Y1 = 9.3,  Y2 = 23.2, Y3 = 11.6 },
                new StackedColumnChartData { X = "2022",  Y = 30.6, Y1 = 7.8,  Y2 = 24.5, Y3 = 14.4 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class StackedColumnChartData
        {
            public string X;
            public double Y;
            public double Y1;
            public double Y2;
            public double Y3;
        }
    }
}
