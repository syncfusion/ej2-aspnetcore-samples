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
        public IActionResult AreaNegative()
        {
            List<AreaNegativeChartData> MaryValues = new List<AreaNegativeChartData>
            {
                new AreaNegativeChartData { Vegetable = "Onion",  Price = 3000 },
                new AreaNegativeChartData { Vegetable = "Potato", Price = 4000 },
                new AreaNegativeChartData { Vegetable = "Tomato", Price = -4000 },
                new AreaNegativeChartData { Vegetable = "Corn", Price = -2000 },
                new AreaNegativeChartData { Vegetable = "Carrot", Price = 5000 }
            };
            List<AreaNegativeChartData> PatriciaValues = new List<AreaNegativeChartData>
            {
                new AreaNegativeChartData { Vegetable = "Onion",  Price = 2000 },
                new AreaNegativeChartData { Vegetable = "Potato", Price = 3000 },
                new AreaNegativeChartData { Vegetable = "Tomato", Price = 4000 },
                new AreaNegativeChartData { Vegetable = "Corn", Price = 2000 },
                new AreaNegativeChartData { Vegetable = "Carrot", Price = 3000 }
            };
            List<AreaNegativeChartData> LindaValues = new List<AreaNegativeChartData>
            {
                new AreaNegativeChartData { Vegetable = "Onion",  Price = 2000 },
                new AreaNegativeChartData { Vegetable = "Potato", Price = -1000 },
                new AreaNegativeChartData { Vegetable = "Tomato", Price = -3000 },
                new AreaNegativeChartData { Vegetable = "Corn", Price = 4000 },
                new AreaNegativeChartData { Vegetable = "Carrot", Price = 1000 }
            };
            ViewBag.dataSource1 = MaryValues;
            ViewBag.dataSource2 = PatriciaValues;
            ViewBag.dataSource3 = LindaValues;
            return View();
        }
        public class AreaNegativeChartData
        {
            public string Vegetable;
            public double Price;
        }
    }
}