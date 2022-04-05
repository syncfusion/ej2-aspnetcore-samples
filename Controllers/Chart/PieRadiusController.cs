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

        public IActionResult PieRadius()
        {
            List<PieData1> chartData = new List<PieData1>  
            {
                new PieData1 { xValue = "Argentina", yValue = 505370, r = "50%"},
                new PieData1 { xValue = "Belgium",    yValue = 551500, r = "70%"},
                new PieData1 { xValue = "Cuba",  yValue = 312685 , r = "84%"},
                new PieData1 { xValue = "Dominican Republic", yValue = 350000 , r = "97%"},
                new PieData1 { xValue = "Egypt", yValue = 301000 , r = "84%"},
                new PieData1 { xValue = "Kazakhstan", yValue = 300000, r = "70%"},
                new PieData1 { xValue = "Somalia",  yValue = 357022, r = "90%"}
            };
            ViewBag.dataSource = chartData;
            return View();
        }
		public class PieData1
        {
            public string xValue;
            public double yValue;
            public string r;
        }
    }
}
