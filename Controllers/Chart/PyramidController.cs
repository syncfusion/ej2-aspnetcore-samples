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

        public IActionResult Pyramid()
        {
            List<PyramidChartData> ChartPoints = new List<PyramidChartData>
            {
                new PyramidChartData { Foods =  "Milk, Youghnut, Cheese", Calories = 435, DataLabelMappingName = "Milk, Youghnut, Cheese: 435 cal" },
                new PyramidChartData { Foods =  "Vegetables",             Calories = 470, DataLabelMappingName = "Vegetables: 470 cal" },
                new PyramidChartData { Foods =  "Meat, Poultry, Fish",    Calories = 475, DataLabelMappingName = "Meat, Poultry, Fish: 475 cal" },                
                new PyramidChartData { Foods =  "Fruits",                 Calories = 520, DataLabelMappingName = "Fruits: 520 cal" },
                new PyramidChartData { Foods =  "Bread, Rice, Pasta",     Calories = 930, DataLabelMappingName = "Bread, Rice, Pasta: 930 cal" }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class PyramidChartData
        {
            public string Foods;
            public double Calories;
            public string DataLabelMappingName;
        }
    }
}
