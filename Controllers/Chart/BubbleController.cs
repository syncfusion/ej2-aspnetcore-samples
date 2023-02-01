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
        public IActionResult Bubble()
        {
            List<BubbleChartData> chartData = new List<BubbleChartData>
            {
                    new BubbleChartData { x= 92.2, y= 7.8, size= 1.347, text= "China" },
                    new BubbleChartData { x= 74, y= 6.5, size= 1.241, text= "India" },
                    new BubbleChartData { x= 90.4, y= 6.0, size= 0.238, text= "Indonesia" },
                    new BubbleChartData { x= 99.4, y= 2.2, size= 0.312, text= "US" },
                    new BubbleChartData { x= 88.6, y= 1.3, size= 0.197, text= "Brazil" },
                    new BubbleChartData { x= 99, y= 0.7, size= 0.0818, text= "Germany" },
                    new BubbleChartData { x= 72, y= 2.0, size= 0.0826, text= "Egypt" },
                    new BubbleChartData { x= 99.6, y= 3.4, size= 0.143, text= "Russia" },
                    new BubbleChartData { x= 99, y= 0.2, size= 0.128, text= "Japan" },
                    new BubbleChartData { x= 86.1, y= 4.0, size= 0.115, text= "Mexico" },
                    new BubbleChartData { x= 92.6, y= 6.6, size= 0.096, text= "Philippines" },
                    new BubbleChartData { x= 61.3, y= 1.45, size= 0.162, text= "Nigeria" },
                    new BubbleChartData { x= 82.2, y= 3.97, size= 0.7, text= "Hong Kong" },
                    new BubbleChartData { x= 79.2, y= 3.9, size= 0.162, text= "Netherland" },
                    new BubbleChartData { x= 72.5, y= 4.5, size= 0.7, text= "Jordan" },
                    new BubbleChartData { x= 81, y= 3.5, size= 0.21, text= "Australia" },
                    new BubbleChartData { x= 66.8, y= 3.9, size= 0.028, text= "Mongolia" },
                    new BubbleChartData { x= 78.4, y= 2.9, size= 0.231, text= "Taiwan" }
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class BubbleChartData
        {
            public double x;
            public double y;
            public double size;
            public string text;
        }
    }
}