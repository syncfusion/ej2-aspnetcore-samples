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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ChartController : Controller
    {

        public IActionResult IndexedCategoryAxis()
        {           

            List<CategoryData> chartData1 = new List<CategoryData>
            {
                new CategoryData { x = "Myanmar", y = 7.3 },
                new CategoryData { x = "India", y = 7.9 },
                new CategoryData { x = "Bangladesh", y = 6.0 },
                new CategoryData { x = "Cambodia", y = 7.0 },
                new CategoryData { x = "China", y = 6.9 },
             };
            ViewBag.dataSource = chartData1;
            List<CategoryData> chartData2 = new List<CategoryData>
            {
                new CategoryData { x = "Poland", y = 2.7 },
                new CategoryData { x = "Australia", y = 2.5 },
                new CategoryData { x = "Singapore", y = 2.0 },
                new CategoryData { x = "Canada", y = 1.4 },
                new CategoryData { x = "Germany", y = 1.8 },
             };
            ViewBag.dataSource2 = chartData2;
            return View();
        }

        public class CategoryData
        {
            public string x;
            public double y;
            public double y2;
            public string country;
        }
    }
}
