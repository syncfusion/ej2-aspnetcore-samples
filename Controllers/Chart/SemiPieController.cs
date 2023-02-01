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

        public IActionResult SemiPie()
        {
            List<SemiPieChartData> chartData = new List<SemiPieChartData>
            {
                new SemiPieChartData { xValue =  "Chrome", yValue = 100, text = "Chrome (100M)<br>40%", tooltipMappingName="40%" },
                new SemiPieChartData { xValue =  "UC Browser", yValue = 40, text = "UC Browser (40M)<br>16%", tooltipMappingName="16%" },
                new SemiPieChartData { xValue =  "Opera", yValue = 30, text = "Opera (30M)<br>12%", tooltipMappingName="12%" },
                new SemiPieChartData { xValue =  "Safari", yValue = 30, text = "Safari (30M)<br>12%", tooltipMappingName="12%" },
                new SemiPieChartData { xValue =  "Firefox", yValue = 25, text = "Firefox (25M)<br>10%", tooltipMappingName="10%" },
                new SemiPieChartData { xValue =  "Others", yValue = 25, text = "Others (25M)<br>10%", tooltipMappingName="10%" }
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class SemiPieChartData
        {
            public string xValue;
            public double yValue;
            public string text;
            public string tooltipMappingName;
        }
    }
}
