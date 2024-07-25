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
        public IActionResult StackedArea100()
        {
            List<StackedArea100ChartData> ChartPoints = new List<StackedArea100ChartData>
            {
               new StackedArea100ChartData { Period = new DateTime(2000, 01, 01), OrganicSales = 0.61, FairTradeSales = 0.03, VegAlternativesSales = 0.48, OtherSales = 0.23 },
               new StackedArea100ChartData { Period = new DateTime(2001, 01, 01), OrganicSales = 0.81, FairTradeSales = 0.05, VegAlternativesSales = 0.53, OtherSales = 0.17 },
               new StackedArea100ChartData { Period = new DateTime(2002, 01, 01), OrganicSales = 0.91, FairTradeSales = 0.06, VegAlternativesSales = 0.57, OtherSales = 0.17 },
               new StackedArea100ChartData { Period = new DateTime(2003, 01, 01), OrganicSales = 1.00, FairTradeSales = 0.09, VegAlternativesSales = 0.61, OtherSales = 0.20 },
               new StackedArea100ChartData { Period = new DateTime(2004, 01, 01), OrganicSales = 1.19, FairTradeSales = 0.14, VegAlternativesSales = 0.63, OtherSales = 0.23 },
               new StackedArea100ChartData { Period = new DateTime(2005, 01, 01), OrganicSales = 1.47, FairTradeSales = 0.20, VegAlternativesSales = 0.64, OtherSales = 0.36 },
               new StackedArea100ChartData { Period = new DateTime(2006, 01, 01), OrganicSales = 1.74, FairTradeSales = 0.29, VegAlternativesSales = 0.66, OtherSales = 0.43 },
               new StackedArea100ChartData { Period = new DateTime(2007, 01, 01), OrganicSales = 1.98, FairTradeSales = 0.46, VegAlternativesSales = 0.76, OtherSales = 0.51 },
               new StackedArea100ChartData { Period = new DateTime(2008, 01, 01), OrganicSales = 1.99, FairTradeSales = 0.64, VegAlternativesSales = 0.77, OtherSales = 0.72 },
               new StackedArea100ChartData { Period = new DateTime(2009, 01, 01), OrganicSales = 1.70, FairTradeSales = 0.75, VegAlternativesSales = 0.55, OtherSales = 1.29 },
               new StackedArea100ChartData { Period = new DateTime(2010, 01, 01), OrganicSales = 1.48, FairTradeSales = 1.06, VegAlternativesSales = 0.54, OtherSales = 1.38 },
               new StackedArea100ChartData { Period = new DateTime(2011, 01, 01), OrganicSales = 1.38, FairTradeSales = 1.25, VegAlternativesSales = 0.57, OtherSales = 1.82 },
               new StackedArea100ChartData { Period = new DateTime(2012, 01, 01), OrganicSales = 1.66, FairTradeSales = 1.55, VegAlternativesSales = 0.61, OtherSales = 2.16 },
               new StackedArea100ChartData { Period = new DateTime(2013, 01, 01), OrganicSales = 1.66, FairTradeSales = 1.55, VegAlternativesSales = 0.67, OtherSales = 2.51 },
               new StackedArea100ChartData { Period = new DateTime(2014, 01, 01), OrganicSales = 1.67, FairTradeSales = 1.65, VegAlternativesSales = 0.67, OtherSales = 2.61 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class StackedArea100ChartData
        {
            public DateTime Period;
            public double OrganicSales;
            public double FairTradeSales;
            public double VegAlternativesSales;
            public double OtherSales;
        }
    }
}