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

        public IActionResult SmartAxisLabel()
        {
            List<CategoryData> chartData = new List<CategoryData>
            {
                new CategoryData { x = "South Korea", y = 39 },
                new CategoryData { x = "India", y = 61 },
                new CategoryData { x = "Pakistan", y = 20 },
                new CategoryData { x = "Germany", y = 65 },
                new CategoryData { x = "Australia", y = 16 },
                new CategoryData { x = "Italy", y = 29 },
                new CategoryData { x = "France", y = 45 },
                new CategoryData { x = "United Arab Emirates", y = 10 },
                new CategoryData { x = "Russia", y = 41 },
                new CategoryData { x = "Mexico", y = 31 },
                new CategoryData { x = "Brazil", y = 76 },
                new CategoryData { x = "China", y = 51 },
             };
            ViewBag.dataSource = chartData;
            ViewBag.interSect = new String[] { "Trim", "None", "Hide", "Wrap", "MultipleRows", "Rotate45", "Rotate90" };
            ViewBag.edgeLabel = new String[] { "None", "Hide", "Shift" };
            ViewBag.labelPosition = new String[] { "Outside", "Inside" };
            return View();
        }        
    }
}
