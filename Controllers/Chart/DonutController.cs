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

        public IActionResult Donut()
        {
            List<DoughnutData> chartData = new List<DoughnutData>  
            {
                new DoughnutData { xValue =  "Labour", yValue = 18, text = "18%" },
                new DoughnutData { xValue =  "Legal", yValue = 8, text = "8%" },
                new DoughnutData { xValue =  "Production", yValue = 15, text = "15%" },
                new DoughnutData { xValue =  "License", yValue = 11, text = "11%" },
                new DoughnutData { xValue =  "Facilities", yValue = 18, text = "18%" },
                new DoughnutData { xValue =  "Taxes", yValue = 14, text = "14%" },
                new DoughnutData { xValue =  "Insurance", yValue = 16, text = "16%" },
            };
            ViewBag.dataSource = chartData;
            return View();
        }

        public class DoughnutData
        {
            public string xValue;
            public double yValue;
            public string text;
        }
    }
}
