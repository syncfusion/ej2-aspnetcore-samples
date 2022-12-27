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
        public IActionResult Vertical()
        {
       
            List<VerticalChartData> chartData = new List<VerticalChartData>
            {
                new VerticalChartData {x = 0, y = 0 }
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class VerticalChartData
        {
            public double x;
            public double y;
        }
    }
}