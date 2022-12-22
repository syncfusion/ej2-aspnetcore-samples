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
        public IActionResult Column()
        {
            List<ColumnChartData> chartData = new List<ColumnChartData>
            {
                new ColumnChartData { x= "USA", yValue= 46, yValue1=37, yValue2=38 }, 
                new ColumnChartData { x= "GBR", yValue= 27, yValue1=23, yValue2=17 }, 
                new ColumnChartData { x= "CHN", yValue= 26, yValue1=18, yValue2=26 }
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class ColumnChartData
        {
            public string x;
            public double yValue;
            public double yValue1;
            public double yValue2;
        }
    }
}