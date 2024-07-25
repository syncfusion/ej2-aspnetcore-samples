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
        public IActionResult PolarArea()
        {
            List<PolarAreaChartData> ChartPoints = new List<PolarAreaChartData>
            {
                new PolarAreaChartData { Period = "2000", ProductRevenue_A = 4  , ProductRevenue_B = 2.6, ProductRevenue_C = 2.8},
                new PolarAreaChartData { Period = "2001", ProductRevenue_A = 3.0, ProductRevenue_B = 2.8, ProductRevenue_C = 2.5 },
                new PolarAreaChartData { Period = "2002", ProductRevenue_A = 3.8, ProductRevenue_B = 2.6, ProductRevenue_C = 2.8 },
                new PolarAreaChartData { Period = "2003", ProductRevenue_A = 3.4, ProductRevenue_B = 3  , ProductRevenue_C = 3.2 },
                new PolarAreaChartData { Period = "2004", ProductRevenue_A = 3.2, ProductRevenue_B = 3.6, ProductRevenue_C = 2.9 },
                new PolarAreaChartData { Period = "2005", ProductRevenue_A = 3.9, ProductRevenue_B = 3  , ProductRevenue_C = 2   }
            };
            ViewBag.ChartPoints = ChartPoints;
            ViewBag.select = new string[] { "Polar", "Radar" };
            return View();
        }
        public class PolarAreaChartData
        {
            public string Period;
            public double ProductRevenue_A;
            public double ProductRevenue_B;
            public double ProductRevenue_C;
        }
    }
}