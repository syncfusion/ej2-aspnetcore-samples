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
        public IActionResult StackedBar100()
        {
            List<StackedBar100ChartData> ChartPoints = new List<StackedBar100ChartData>
            {
                new StackedBar100ChartData { Month = "Jan", AppleSales = 6, OrangeSales = 6, Wasteage = 1 },
                new StackedBar100ChartData { Month = "Feb", AppleSales = 8, OrangeSales = 8, Wasteage = 1.5 },
                new StackedBar100ChartData { Month = "Mar", AppleSales = 12, OrangeSales = 11, Wasteage = 2 },
                new StackedBar100ChartData { Month = "Apr", AppleSales = 15, OrangeSales = 16, Wasteage = 2.5 },
                new StackedBar100ChartData { Month = "May", AppleSales = 20, OrangeSales = 21, Wasteage = 3 },
                new StackedBar100ChartData { Month = "Jun", AppleSales = 24, OrangeSales = 25, Wasteage = 3.5 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class StackedBar100ChartData
        {
            public string Month;
            public double AppleSales;
            public double OrangeSales;
            public double Wasteage;
        }
    }
}