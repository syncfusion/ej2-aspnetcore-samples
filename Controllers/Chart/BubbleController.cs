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
        public IActionResult Bubble()
        {
            List<BubbleChartData> ChartPoints = new List<BubbleChartData>
            {
                new BubbleChartData { Literacy= 92.2,  GDPGrowth= 7.8,  BubbleSize= 1.347,  Text= "China",          TooltipMappingName= "China" },
                new BubbleChartData { Literacy= 74,    GDPGrowth= 6.5,  BubbleSize= 1.241,  Text= "India",          TooltipMappingName= "India" },
                new BubbleChartData { Literacy= 90.4,  GDPGrowth= 6.0,  BubbleSize= 0.238,  Text= "Indonesia",      TooltipMappingName= "Indonesia" },              
                new BubbleChartData { Literacy= 99.4,  GDPGrowth= 2.2,  BubbleSize= 0.312,  Text= "United States",  TooltipMappingName= "US" },
                new BubbleChartData { Literacy= 88.6,  GDPGrowth= 1.3,  BubbleSize= 0.197,  Text= "Brazil",         TooltipMappingName= "Brazil" },
                new BubbleChartData { Literacy= 99,    GDPGrowth= 0.7,  BubbleSize= 0.0818, Text= "Germany",        TooltipMappingName= "Germany" },
                new BubbleChartData { Literacy= 72,    GDPGrowth= 2.0,  BubbleSize= 0.0826, Text= "Egypt",          TooltipMappingName= "Egypt" },     
                new BubbleChartData { Literacy= 99.6,  GDPGrowth= 3.4,  BubbleSize= 0.143,  Text= "Russia",         TooltipMappingName= "Russia" },
                new BubbleChartData { Literacy= 96.5,  GDPGrowth= 0.2,  BubbleSize= 0.128,  Text= "Japan",          TooltipMappingName= "Japan" },
                new BubbleChartData { Literacy= 86.1,  GDPGrowth= 4.0,  BubbleSize= 0.115,  Text= "MeLiteracy Ion", TooltipMappingName= "MLI" },
                new BubbleChartData { Literacy= 92.6,  GDPGrowth= 5.2,  BubbleSize= 0.096,  Text= "Philippines",    TooltipMappingName= "PH" },
                new BubbleChartData { Literacy= 61.3,  GDPGrowth= 1.45, BubbleSize= 0.162,  Text= "Nigeria",        TooltipMappingName= "Nigeria" },
                new BubbleChartData { Literacy= 82.2,  GDPGrowth= 3.97, BubbleSize= 0.7,    Text= "Hong Kong",      TooltipMappingName= "Hong Kong" },
                new BubbleChartData { Literacy= 79.2,  GDPGrowth= 4.9,  BubbleSize= 0.162,  Text= "Netherland",     TooltipMappingName= "NL" },
                new BubbleChartData { Literacy= 72.5,  GDPGrowth= 4.5,  BubbleSize= 0.7,    Text= "Jordan",         TooltipMappingName= "Jordan" },
                new BubbleChartData { Literacy= 81,    GDPGrowth= 2.5,  BubbleSize= 0.21,   Text= "Australia",      TooltipMappingName= "Australia" },
                new BubbleChartData { Literacy= 66.8,  GDPGrowth= 3.9,  BubbleSize= 0.028,  Text= "Mongolia",       TooltipMappingName= "MN" },
                new BubbleChartData { Literacy= 78.4,  GDPGrowth= 2.9,  BubbleSize= 0.231,  Text= "Taiwan",         TooltipMappingName= "Taiwan" }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class BubbleChartData
        {
            public double Literacy;
            public double GDPGrowth;
            public double BubbleSize;
            public string Text;
            public string TooltipMappingName;
        }
    }
}