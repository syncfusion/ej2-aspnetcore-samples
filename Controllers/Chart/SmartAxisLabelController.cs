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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {

        public IActionResult SmartAxisLabel()
        {
            List<SmartAxisLabelsChartData> ChartPoints = new List<SmartAxisLabelsChartData>
            {
                new SmartAxisLabelsChartData { Country = "South Korea",  User = 39, DataLabelMappingName = "39M" },
                new SmartAxisLabelsChartData { Country = "India",        User = 61, DataLabelMappingName = "61M" },
                new SmartAxisLabelsChartData { Country = "Pakistan",     User = 20, DataLabelMappingName = "20M" },
                new SmartAxisLabelsChartData { Country = "Germany",      User = 65, DataLabelMappingName = "65M" },
                new SmartAxisLabelsChartData { Country = "Australia",    User = 16, DataLabelMappingName = "16M" },
                new SmartAxisLabelsChartData { Country = "Italy",        User = 29, DataLabelMappingName = "29M" },
                new SmartAxisLabelsChartData { Country = "France",       User = 45, DataLabelMappingName = "45M" },
                new SmartAxisLabelsChartData { Country = "United Arab Emirates", User = 10, DataLabelMappingName = "10M" },
                new SmartAxisLabelsChartData { Country = "Russia",       User = 41, DataLabelMappingName = "41M" },
                new SmartAxisLabelsChartData { Country = "Mexico",       User = 31, DataLabelMappingName = "31M" },
                new SmartAxisLabelsChartData { Country = "Brazil",       User = 76, DataLabelMappingName = "76M" },
                new SmartAxisLabelsChartData { Country = "China",        User = 51, DataLabelMappingName = "51M" }
            };
            ViewBag.ChartPoints = ChartPoints;
            ViewBag.font = new { fontWeight = "600", color = "#ffffff" };
            ViewBag.interSect = new string[] { "Hide", "Trim", "Wrap", "MultipleRows", "Rotate45", "Rotate90", "None" };
            ViewBag.edgeLabel = new string[] { "None", "Shift", "Hide" };
            ViewBag.labelPosition = new string[] { "Outside", "Inside" };
            return View();
        }
        public class SmartAxisLabelsChartData
        {
            public string Country;
            public double User;
            public string DataLabelMappingName;
        } 
    }
}
