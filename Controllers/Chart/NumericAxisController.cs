#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

        public IActionResult NumericAxis()
        {
            List<DoubleData> ChartPoints = new List<DoubleData>
            {
                new DoubleData { Over = 16, ENG_Score = 2, WI_Score = 7},
                new DoubleData { Over = 17, ENG_Score = 14, WI_Score = 7 },
                new DoubleData { Over = 18, ENG_Score = 7, WI_Score = 11 },
                new DoubleData { Over = 19, ENG_Score = 7, WI_Score = 8 },
                new DoubleData { Over = 20, ENG_Score = 10, WI_Score = 24 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }

        public class DoubleData
        {
            public double Over;
            public double ENG_Score;
            public double WI_Score;
        }
    }
}
