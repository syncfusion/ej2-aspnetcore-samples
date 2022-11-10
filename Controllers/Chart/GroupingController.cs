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

        public IActionResult Grouping()
        {
            List<PieData> chartData = new List<PieData>  
            {
                new PieData { xValue =  "China", yValue = 26, text = "China: 26" },
                new PieData { xValue =  "Russia", yValue = 19, text = "Russia: 19" },
                new PieData { xValue =  "Japan", yValue = 12, text = "Germany: 17" },
                new PieData { xValue =  "France", yValue = 10, text = "France: 10" },
                new PieData { xValue =  "South Korea", yValue = 9, text = "South korea: 9" },
                new PieData { xValue =  "Great Britain", yValue = 27, text = "France: 27" },
                new PieData { xValue =  "Italy", yValue = 8, text = "Italy: 8" },
                new PieData { xValue =  "Australia", yValue = 8, text = "Australia: 8" },
                new PieData { xValue =  "Netherlands", yValue = 8, text = "Netherlands: 8" },
                new PieData { xValue =  "Hungery", yValue = 8, text = "HUngery: 8" },
                new PieData { xValue =  "Brazil", yValue = 7, text = "Brazil: 7" },
                new PieData { xValue =  "Spain", yValue = 7, text = "Spain: 7" },
                new PieData { xValue =  "Kenya", yValue = 7, text = "Kenya: 7" },
            };
            ViewBag.dataSource = chartData;
            ViewBag.data = new string[] { "Point", "Value" };
            return View();
        }        
    }
}
