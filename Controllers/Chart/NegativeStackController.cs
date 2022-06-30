#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
        public IActionResult NegativeStack()
        {
            List<NegativeStackChartData> chartData = new List<NegativeStackChartData>
            {
                    new NegativeStackChartData { x= "4.5", y= 31 },
                    new NegativeStackChartData { x= "4.8", y= 37 },
                    new NegativeStackChartData { x= "5.1", y= 49 },
                    new NegativeStackChartData { x= "5.4", y= 57 },
                    new NegativeStackChartData { x= "5.7", y= 63 },
                    new NegativeStackChartData { x= "6", y= 69 }
            };
            ViewBag.dataSource = chartData;
            List<NegativeStackChartData> chartData1 = new List<NegativeStackChartData>
            {
                new NegativeStackChartData { x= "4.5", y= -31, text= "31 KG" },
                new NegativeStackChartData { x= "4.8", y= -39, text= "39 KG" },
                new NegativeStackChartData { x= "5.1", y= -52, text= "52 KG" },
                new NegativeStackChartData { x= "5.4", y= -64, text= "64 KG" },
                new NegativeStackChartData { x= "5.7", y= -70, text= "70 KG" },
                new NegativeStackChartData { x= "6", y= -74, text= "74 KG" }
            };
            ViewBag.dataSource1 = chartData1;
            return View();
        }
        public class NegativeStackChartData
        {
            public string x;
            public double y;
            public string text;
        }
    }
}