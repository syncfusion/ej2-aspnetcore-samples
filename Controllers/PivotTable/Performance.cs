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
using EJ2CoreSampleBrowser.Models;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class PivotTableController : Controller
    {

        public IActionResult Performance()
        {
            ViewBag.performanceOptions = new PerformanceOptions().GetPerformanceOptions();
            return View();
        }

        public class PerformanceOptions
        {
            public string text { get; set; }

            public int value { get; set; }

            public List<PerformanceOptions> GetPerformanceOptions()
            {
                List<PerformanceOptions> performanceOptions = new List<PerformanceOptions>();
                performanceOptions.Add(new PerformanceOptions { text = "10,000 Rows and 10 Columns", value = 10000 });
                performanceOptions.Add(new PerformanceOptions { text = "1,00,000 Rows and 10 Columns", value = 100000 });
                performanceOptions.Add(new PerformanceOptions { text = "1,000,000 Rows and 10 Columns", value = 1000000 });
                return performanceOptions;
            }
        }
    }
}
