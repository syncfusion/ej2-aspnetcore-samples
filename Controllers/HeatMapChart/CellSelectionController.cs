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

namespace EJ2CoreSampleBrowser.Controllers.HeatMapChart
{
    public partial class HeatMapChartController : Controller
    {
        public IActionResult CellSelection()
        {
            double[,] dataSource = new double[7, 5]
            {
                {2.9, 5.2, 3.4, 5.6, 4.4 },
                {6.6, 4.8, 8, 3.9, 6.5},
                {5.1, 4.6, 5.4, 3.9, 4.3},
                {5.2, 4.3, 3.9, 6.2, 6.4},
                {7, 3, 1.9, 5.9, 3.5},
                {7.8, 5.9, 3.9, 4.3, 4.3},
                {6.5, 4.3, 3.9, 5.2, 3.9},
            };
            ViewBag.dataSource = dataSource;
            List<ChartData> chartData = new List<ChartData>
            {
               new ChartData { x= "2014", y = 2.9 },
               new ChartData { x= "2015", y = 5.2 },
               new ChartData { x= "2016", y = 3.4 },
               new ChartData { x= "2017", y = 5.6 },
               new ChartData { x= "2018", y = 4.4 }
            };
            ViewBag.dataSource1 = chartData;
            List<ChartData> chartData1 = new List<ChartData>
            {
               new ChartData { x= "2014", y = 6.6 },
               new ChartData { x= "2015", y = 4.8 },
               new ChartData { x= "2016", y = 8 },
               new ChartData { x= "2017", y = 3.9 },
               new ChartData { x= "2018", y = 6.5 }
            };
            ViewBag.dataSource2 = chartData1;
            List<ChartData> chartData2 = new List<ChartData>
            {
               new ChartData { x= "2014", y = 5.1 },
               new ChartData { x= "2015", y = 4.6 },
               new ChartData { x= "2016", y = 5.4 },
               new ChartData { x= "2017", y = 3.9 },
               new ChartData { x= "2018", y = 4.3 }
            };
            ViewBag.dataSource3 = chartData2;
            List<ChartData> chartData3 = new List<ChartData>
            {
               new ChartData { x= "2014", y = 5.2 },
               new ChartData { x= "2015", y = 4.3 },
               new ChartData { x= "2016", y = 3.9 },
               new ChartData { x= "2017", y = 6.2 },
               new ChartData { x= "2018", y = 6.4 }
            };
            ViewBag.dataSource4 = chartData3;
            List<ChartData> chartData4 = new List<ChartData>
            {
               new ChartData { x= "2014", y = 7 },
               new ChartData { x= "2015", y = 3 },
               new ChartData { x= "2016", y = 1.9 },
               new ChartData { x= "2017", y = 5.9 },
               new ChartData { x= "2018", y = 3.5 }
            };
            ViewBag.dataSource5 = chartData4;
            List<ChartData> chartData5 = new List<ChartData>
            {
               new ChartData { x= "2014", y = 7.8 },
               new ChartData { x= "2015", y = 5.9 },
               new ChartData { x= "2016", y = 3.9 },
               new ChartData { x= "2017", y = 4.3 },
               new ChartData { x= "2018", y = 4.5 }
            };
            ViewBag.dataSource6 = chartData5;
            List<ChartData> chartData6 = new List<ChartData>
            {
               new ChartData { x= "2014", y = 6.5 },
               new ChartData { x= "2015", y = 4.3 },
               new ChartData { x= "2016", y = 3.9 },
               new ChartData { x= "2017", y = 5.2 },
               new ChartData { x= "2018", y = 3.9 }
            };
            ViewBag.dataSource7 = chartData6;
            return View();
        }
        public class ChartData
        {
            public string x;
            public double y;
        }
    }
}