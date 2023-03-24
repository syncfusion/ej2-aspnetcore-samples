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
        public IActionResult ColumnPlacement()
        {
            List<ColumnPlacementChartData> ChartPoints = new List<ColumnPlacementChartData>
            {
                new ColumnPlacementChartData { ConsumerName = "Jamesh", TotalCount = 10, AppleCount = 5, OrangeCount = 4, GrapesCount = 1, DataLabelMappingName = "Total 10" },
                new ColumnPlacementChartData { ConsumerName = "Michael", TotalCount = 9, AppleCount = 4, OrangeCount = 3, GrapesCount = 2, DataLabelMappingName = "Total 9" },
                new ColumnPlacementChartData { ConsumerName = "John", TotalCount = 11, AppleCount = 5, OrangeCount = 4, GrapesCount = 2, DataLabelMappingName = "Total 11" },
                new ColumnPlacementChartData { ConsumerName = "Jack", TotalCount = 8, AppleCount = 5, OrangeCount = 2, GrapesCount = 1, DataLabelMappingName = "Total 8" },
                new ColumnPlacementChartData { ConsumerName = "Lucas", TotalCount = 10, AppleCount = 6, OrangeCount = 3, GrapesCount = 1, DataLabelMappingName = "Total 10" }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class ColumnPlacementChartData
        {
            public string ConsumerName;
            public double TotalCount;
            public double AppleCount;
            public double OrangeCount;
            public double GrapesCount;
            public string DataLabelMappingName;
        }
    }
}