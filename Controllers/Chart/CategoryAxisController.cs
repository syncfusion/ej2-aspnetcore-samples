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

        public IActionResult CategoryAxis()
        {
            List<CategoryData> chartData = new List<CategoryData>
            {
                new CategoryData { x = "Germany", y = 72, country = "GER: 72" },
                new CategoryData { x = "Russia", y = 103.1, country = "RUS: 103.1" },
                new CategoryData { x = "Brazil", y = 139.1, country = "BRZ: 139.1" },
                new CategoryData { x = "India", y = 462.1, country = "IND: 462.1" },
                new CategoryData { x = "China", y = 721.4, country = "CHN: 721.4" },
                new CategoryData { x = "United States<br>of America", y = 286.9, country = "USA: 286.9" },
                new CategoryData { x = "Great Britain", y = 115.1, country = "GBR: 115.1" },
                new CategoryData { x = "Nigeria", y = 97.2, country = "NGR: 97.2" },
             };
            ViewBag.dataSource = chartData;
            return View();
        }        
    }
}
