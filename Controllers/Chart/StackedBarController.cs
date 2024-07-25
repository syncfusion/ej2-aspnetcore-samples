#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
        public IActionResult StackedBar()
        {
            List<StackedBarChartData> ChartPoints = new List<StackedBarChartData>
            {
                new StackedBarChartData { Month = "Jan", AppleSales = 6, OrangeSales = 6, Wastage = -1 },
                new StackedBarChartData { Month = "Feb", AppleSales = 8, OrangeSales = 8, Wastage = -1.5 },
                new StackedBarChartData { Month = "Mar", AppleSales = 12, OrangeSales = 11, Wastage = -2 },
                new StackedBarChartData { Month = "Apr", AppleSales = 15.5, OrangeSales = 16, Wastage = -2.5 },
                new StackedBarChartData { Month = "May", AppleSales = 20, OrangeSales = 21, Wastage = -3 },
                new StackedBarChartData { Month = "Jun", AppleSales = 24, OrangeSales = 25, Wastage = -3.5 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class StackedBarChartData
        {
            public string Month;
            public double AppleSales;
            public double OrangeSales;
            public double Wastage;
        }
    }
}