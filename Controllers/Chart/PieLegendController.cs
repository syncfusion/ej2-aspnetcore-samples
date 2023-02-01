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

        public IActionResult PieLegend()
        {
            List<pieDataPoints> chartData = new List<pieDataPoints>  
            {
                new pieDataPoints { x =  "Internet Explorer", y = 6.12, text="Internet <br> Explorer" },
                new pieDataPoints { x =  "Chrome", y = 57.28, text="Chrome" },
                new pieDataPoints { x =  "Safari", y = 4.73, text="Safari" },
                new pieDataPoints { x =  "QQ", y = 5.96, text="QQ" },
                new pieDataPoints { x =  "UC Browser", y = 4.37, text="UC Browser" },
                new pieDataPoints { x =  "Edge", y = 7.48, text="Edge" },
                new pieDataPoints { x =  "Others", y = 14.06, text="Others" }
            };
            ViewBag.dataSource = chartData;
            return View();
        }
        public class pieDataPoints
        {
            public string x;
            public double y;
            public string text;
        }
    }
}
