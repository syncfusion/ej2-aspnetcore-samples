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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {

        public IActionResult DashedLine()
        {
            List<DashedLineChartData> ChartData = new List<DashedLineChartData>
            {
                new DashedLineChartData { Period= "Jan", Banana_ProductionRate= 100 },
                new DashedLineChartData { Period= "Feb", Banana_ProductionRate= 110 },
                new DashedLineChartData { Period= "Mar", Banana_ProductionRate= 125 },
                new DashedLineChartData { Period= "Apr", Banana_ProductionRate= 150 },
                new DashedLineChartData { Period= "May", Banana_ProductionRate= 140 },
                new DashedLineChartData { Period= "Jun", Banana_ProductionRate= 160 }
            };
            ViewBag.ChartData = ChartData;
            List<DashedLineChartData> ChartDataValues = new List<DashedLineChartData>
            {
                new DashedLineChartData { Period= "Jun", Banana_ProductionRate= 160 },
                new DashedLineChartData { Period= "Jul", Banana_ProductionRate= 170 },
                new DashedLineChartData { Period= "Aug", Banana_ProductionRate= 180 },
                new DashedLineChartData { Period= "Sep", Banana_ProductionRate= 190 },
                new DashedLineChartData { Period= "Oct", Banana_ProductionRate= 200 },
                new DashedLineChartData { Period= "Nov", Banana_ProductionRate= 230 },
                new DashedLineChartData { Period= "Dec", Banana_ProductionRate= 270 }
            };
            ViewBag.ChartDataValues = ChartDataValues;
            return View();
        }
        public class DashedLineChartData
        {
            public string Period;
            public double Banana_ProductionRate;
        }
    }
}
