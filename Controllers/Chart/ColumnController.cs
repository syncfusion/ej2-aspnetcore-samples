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
        public IActionResult Column()
        {
            List<ColumnChartData> ChartPoints = new List<ColumnChartData>
            {
                new ColumnChartData { Country = "GBR", GoldMedal = 27, SilverMedal = 23, BronzeMedal = 17, MappingName = "Great Britain" },
                new ColumnChartData { Country = "CHN", GoldMedal = 26, SilverMedal = 18, BronzeMedal = 26, MappingName = "China" },
                new ColumnChartData { Country = "AUS", GoldMedal = 8, SilverMedal = 11, BronzeMedal = 10, MappingName = "Australia" },
                new ColumnChartData { Country = "RUS", GoldMedal = 19, SilverMedal = 17, BronzeMedal = 20, MappingName = "Russia" },
                new ColumnChartData { Country = "GER", GoldMedal = 17, SilverMedal = 10, BronzeMedal = 15, MappingName = "Germany" },
                new ColumnChartData { Country = "UA", GoldMedal = 2, SilverMedal = 5, BronzeMedal = 24, MappingName = "Ukraine" },       
                new ColumnChartData { Country = "ES", GoldMedal = 7, SilverMedal = 4, BronzeMedal = 6, MappingName = "Spain" },
                new ColumnChartData { Country = "UZB", GoldMedal = 4, SilverMedal = 2, BronzeMedal = 7, MappingName = "Uzbekistan" },
                new ColumnChartData { Country = "JPN", GoldMedal = 12, SilverMedal = 8, BronzeMedal = 21, MappingName = "Japan" },
                new ColumnChartData { Country = "NL", GoldMedal = 8, SilverMedal = 7, BronzeMedal = 4, MappingName = "NetherLand" },
                new ColumnChartData { Country = "USA", GoldMedal = 46, SilverMedal = 37, BronzeMedal = 38, MappingName = "United States" },
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class ColumnChartData
        {
            public string Country;
            public double GoldMedal;
            public double SilverMedal;
            public double BronzeMedal;
            public string MappingName;
        }
    }
}