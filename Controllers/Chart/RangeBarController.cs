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
        public IActionResult RangeBar()
        {
            List<RangeBarChartData> chartData = new List<RangeBarChartData>
            {
                new RangeBarChartData { x= "Jul", low= 28, high= 72 },
                new RangeBarChartData { x= "Aug", low= 18, high= 65 }, 
                new RangeBarChartData { x= "Sep", low= 56, high= 87 },
                new RangeBarChartData { x= "Oct", low= 40, high= 78 },
                new RangeBarChartData { x= "Nov", low= 43, high= 64 }, 
                new RangeBarChartData { x= "Dec", low= 28, high= 54 }
            };
            ViewBag.dataSource = chartData;
            List<RangeBarChartData> chartData1 = new List<RangeBarChartData>
            {
                    new RangeBarChartData { x= "Jul", low= 38, high= 78 },
                    new RangeBarChartData { x= "Aug", low= 27, high= 78 },
                    new RangeBarChartData { x= "Sep", low= 28, high= 79 },
                    new RangeBarChartData { x= "Oct", low= 37, high= 66 },
                    new RangeBarChartData { x= "Nov", low= 25, high= 52 },
                    new RangeBarChartData { x= "Dec", low= 20, high= 60 }
            };
            ViewBag.dataSource1 = chartData1;
            return View();
        }
        public class RangeBarChartData
        {
            public string x;
            public double low;
            public double high;
        }
    }
}