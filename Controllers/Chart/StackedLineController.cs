#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
        public IActionResult StackedLine()
        {
            List<StackedChartData> chartData = new List<StackedChartData>
            {
                new StackedChartData { x = "Food" , y = 90, y1 = 40 , y2 = 70, y3 = 120},
                new StackedChartData { x = "Transport", y = 80, y1 = 90, y2 = 110, y3 = 70 },
                new StackedChartData { x = "Medical",y = 50, y1 = 80, y2 = 120, y3 = 50 },
                new StackedChartData { x = "Clothes",y = 70, y1 = 30, y2 = 60, y3 = 180 },
                new StackedChartData { x = "Personal Care", y = 30, y1 = 80, y2 = 80, y3 = 30 },
                new StackedChartData { x = "Books", y = 10, y1 = 40, y2 = 30, y3 = 270},
                new StackedChartData { x = "Fitness",y = 100, y1 = 30, y2 = 70, y3 = 40 },
                new StackedChartData { x = "Electricity", y = 55, y1 = 95, y2 = 55, y3 = 75},
                new StackedChartData { x = "Tax", y = 20, y1 = 50, y2 = 40, y3 = 65 },
                new StackedChartData { x = "Pet Care", y = 40, y1 = 20, y2 = 80, y3 = 95 },
                new StackedChartData { x = "Education", y = 45, y1 = 15, y2 = 45, y3 = 195 },
                new StackedChartData { x = "Entertainment", y = 75, y1 = 45, y2 = 65, y3 = 115 }
            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class StackedChartData
        {
            public string x;
            public double y;
            public double y1;
            public double y2;
            public double y3;
        }
    }
}
