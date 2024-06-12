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

        public IActionResult Grouping()
        {
            List<GroupingChartData> ChartPoints = new List<GroupingChartData>
            {
                new GroupingChartData { Country =  "China",         Medal = 26, DataLabelMappingName = "China: 26" },
                new GroupingChartData { Country =  "Russia",        Medal = 19, DataLabelMappingName = "Russia: 19" },
                new GroupingChartData { Country =  "Germany",       Medal = 17, DataLabelMappingName = "Germany: 17" },
                new GroupingChartData { Country =  "Japan",         Medal = 12, DataLabelMappingName = "Japan: 12" },
                new GroupingChartData { Country =  "France",        Medal = 10, DataLabelMappingName = "France: 10" },
                new GroupingChartData { Country =  "South Korea",   Medal = 9,  DataLabelMappingName = "South Korea: 9" },
                new GroupingChartData { Country =  "Great Britain", Medal = 27, DataLabelMappingName = "Great Britain: 27" },
                new GroupingChartData { Country =  "Italy",         Medal = 8,  DataLabelMappingName = "Italy: 8" },
                new GroupingChartData { Country =  "Australia",     Medal = 8,  DataLabelMappingName = "Australia: 8" },
                new GroupingChartData { Country =  "Netherlands",   Medal = 8,  DataLabelMappingName = "Netherlands: 8" },
                new GroupingChartData { Country =  "Hungary",       Medal = 8,  DataLabelMappingName = "Hungary: 8" },
                new GroupingChartData { Country =  "Brazil",        Medal = 7,  DataLabelMappingName = "Brazil: 7" },
                new GroupingChartData { Country =  "Spain",         Medal = 7,  DataLabelMappingName = "Spain: 7" },
                new GroupingChartData { Country =  "Kenya",         Medal = 6,  DataLabelMappingName = "Kenya: 6" }
            };
            ViewBag.ChartPoints = ChartPoints;
            ViewBag.data = new string[] { "Point", "Value" };
            return View();
        }
        public class GroupingChartData
        {
            public string Country;
            public double Medal;
            public string DataLabelMappingName;
        }
    }
}
