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
        public IActionResult ColumnPlacement()
        {
            List<ColumnPlacementChartData> chartData = new List<ColumnPlacementChartData>
            {
                new ColumnPlacementChartData { x= "Jamesh", yValue= 10, yValue1=5, yValue2=4, yValue3=1, text= "Total 10" },
                new ColumnPlacementChartData { x= "Michael", yValue= 9, yValue1=4, yValue2=3, yValue3=2, text= "Total 9" }, 
                new ColumnPlacementChartData { x= "John", yValue= 11, yValue1=5, yValue2=4, yValue3=2, text= "Total 11" }
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class ColumnPlacementChartData
        {
            public string x;
            public double yValue;
            public double yValue1;
            public double yValue2;
            public double yValue3;
            public string text;
        }
    }
}