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

        public IActionResult SemiPie()
        {
            List<PieData> chartData = new List<PieData>  
            {
                new PieData { xValue =  "Australia", yValue = 53, text = "AUS:37" },
                new PieData { xValue =  "China", yValue = 56, text = "CHN:15" },
                new PieData { xValue =  "India", yValue = 61, text = "IND:16" },
                new PieData { xValue =  "Japan", yValue = 19, text = "JPN:19" },
                new PieData { xValue =  "South Africa", yValue = 79, text = "ZAF: 21" },
                new PieData { xValue =  "United Kingdom", yValue = 71, text = "UK: 19" },
                new PieData { xValue =  "United States", yValue = 45, text = "USA: 12" },                
            };
            ViewBag.dataSource = chartData;
            return View();
        }       
    }
}
