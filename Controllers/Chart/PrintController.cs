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
        public IActionResult Print()
        {
            List<exportData> chartData = new List<exportData>
            {
               new exportData { xValue = "John", yValue = 10000 },
               new exportData { xValue = "Jake", yValue = 12000 },
               new exportData { xValue = "Peter", yValue = 18000 },
               new exportData { xValue = "James", yValue = 11000 },
               new exportData { xValue = "Mary", yValue = 9700 }
            };
            ViewBag.dataSource = chartData;
            return View();
        }        
    }
}