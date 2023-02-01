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

        public IActionResult Drilldown()
        {
            List<CategoryData> chartData = new List<CategoryData>
            {
                new CategoryData { x = "SUV", y = 25 },
                new CategoryData { x = "Car", y = 37 },
                new CategoryData { x = "Pickup", y = 15 },
                new CategoryData { x = "Minivan", y = 23 },

             };
            ViewBag.datalabel = new
            {
                visible = true,
                position = "Inside",
                name = "text",
                font = new
                {
                    fontWeight = "600"
                }
            };
            ViewBag.dataSource = chartData;

            return View();
        }


    }

    public class CategoryData
    {
        public string x;
        public double y;
    }
}
