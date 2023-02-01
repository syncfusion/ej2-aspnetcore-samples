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
        public IActionResult MarkerChart()
        {
            List<SymbolsData> chartData = new List<SymbolsData>
            {
                new SymbolsData { x= "WW", y= 12, text= "World Wide" },
                new SymbolsData { x= "EU", y= 9.9, text= "Europe" },
                new SymbolsData { x= "APAC", y= 4.4, text= "Asia Pacific" },
                new SymbolsData { x= "LATAM", y= 6.4, text= "Latin America" },
                new SymbolsData { x= "MEA", y= 30, text= "Middle East Africa" },
                new SymbolsData { x= "NA", y= 25.3, text= "North America" }    
            };
            ViewBag.dataSource = chartData;
            List<SymbolsData> chartData1 = new List<SymbolsData>
            {
                new SymbolsData { x= "WW", y= 22, text= "World Wide" },
                new SymbolsData { x= "EU", y= 26, text= "Europe" },
                new SymbolsData { x= "APAC", y= 9.3, text= "Asia Pacific" },
                new SymbolsData { x= "LATAM", y= 28, text= "Latin America" },
                new SymbolsData { x= "MEA", y= 45.7, text= "Middle East Africa" },
                new SymbolsData { x= "NA", y= 35.9, text= "North America" }
            };
            ViewBag.dataSource1 = chartData1;
            List<SymbolsData> chartData2 = new List<SymbolsData>
            {
                new SymbolsData { x= "WW", y= 38.3, text= "World Wide" },
                new SymbolsData { x= "EU", y= 45.2, text= "Europe" },
                new SymbolsData { x= "APAC", y= 18.2, text= "Asia Pacific" },
                new SymbolsData { x= "LATAM", y= 46.7, text= "Latin America" },
                new SymbolsData { x= "MEA", y= 61.5, text= "Middle East Africa" },
                new SymbolsData { x= "NA", y= 64, text= "North America" }
            };
            ViewBag.dataSource2 = chartData2;
            return View();
        }
        public class SymbolsData
        {
            public string x;
            public double y;
            public string text;
        }
    }
}