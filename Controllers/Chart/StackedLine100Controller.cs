#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
        public IActionResult StackedLine100()
        {
                List<StackedLineChartData> chartData = new List<StackedLineChartData>
            {
                new StackedLineChartData { x = "Food" , y = 90, y1 = 40 , y2 = 70, y3 = 120},
                new StackedLineChartData { x = "Transport", y = 80, y1 = 90, y2 = 110, y3 = 70 },
                new StackedLineChartData { x = "Medical",y = 50, y1 = 80, y2 = 120, y3 = 50 },
                new StackedLineChartData { x = "Clothes",y = 70, y1 = 30, y2 = 60, y3 = 180 },
                new StackedLineChartData { x = "Personal Care", y = 30, y1 = 80, y2 = 80, y3 = 30 },
                new StackedLineChartData { x = "Books", y = 10, y1 = 40, y2 = 30, y3 = 270},
                new StackedLineChartData { x = "Fitness",y = 100, y1 = 30, y2 = 70, y3 = 40 },
                new StackedLineChartData { x = "Electricity", y = 55, y1 = 95, y2 = 55, y3 = 75},
                new StackedLineChartData { x = "Tax", y = 20, y1 = 50, y2 = 40, y3 = 65 },
                new StackedLineChartData { x = "Pet Care", y = 40, y1 = 20, y2 = 80, y3 = 95 },
                new StackedLineChartData { x = "Education", y = 45, y1 = 15, y2 = 45, y3 = 195 },
                new StackedLineChartData { x = "Entertainment", y = 75, y1 = 45, y2 = 65, y3 = 115 }
            };
                ViewBag.dataSource = chartData;
                return View();
            }

        public class StackedLineChartData
        {
            public string x;
            public double y;
            public double y1;
            public double y2;
            public double y3;
        }
    }
}
