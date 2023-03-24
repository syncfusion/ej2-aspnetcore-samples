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
        public IActionResult Waterfall()
        {
            List<WaterfallChartData> ChartPoints = new List<WaterfallChartData>
            {
                new WaterfallChartData { X = "Income", Y = 971  },
                new WaterfallChartData { X = "Sales", Y = -101 },
                new WaterfallChartData { X = "Development", Y = -268 },
                new WaterfallChartData { X = "Revenue", Y = 403 },
                new WaterfallChartData { X = "Balance" },
                new WaterfallChartData { X = "Expense", Y = -136 },
                new WaterfallChartData { X = "Tax", Y = -365 },
                new WaterfallChartData { X = "Net Profit" }
            };
            ViewBag.ChartPoints = ChartPoints;
            ViewBag.intermediateSumIndexes = new int[] {4};
            ViewBag.sumIndexes = new int[] {7};
            ViewBag.connector = new {width = 2, length = 1, color = "#5F6A6A"};
            return View();
        }
        public class WaterfallChartData 
        {
            public string X;
            public double Y;
        }
    }
}