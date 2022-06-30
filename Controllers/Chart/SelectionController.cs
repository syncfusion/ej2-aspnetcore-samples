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

        public IActionResult Selection()
        {
            List<SelectionData> chartData = new List<SelectionData>
            {
                new SelectionData { x = "CHN", y1 = 17, y2 = 54, y3 = 9 },
                new SelectionData { x = "USA", y1 = 19, y2 = 67, y3 = 14 },
                new SelectionData { x = "IDN", y1 = 29, y2 = 65, y3 = 6 },
                new SelectionData { x = "JAP", y1 = 13, y2 = 61, y3 = 26 },
                new SelectionData { x = "BRZ", y1 = 24, y2 = 68, y3 = 8 },
       
             };
            ViewBag.dataSource = chartData;
            ViewBag.selection = new String[] { "Point", "Series", "Cluster" };
            return View();
        }
        public class SelectionData
        {
            public string x;
            public double y1;
            public double y2;
            public double y3;
        }
    }
}
