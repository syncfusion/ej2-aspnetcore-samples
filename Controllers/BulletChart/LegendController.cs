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

namespace EJ2CoreSampleBrowser.Controllers.BulletChart
{
    public partial class BulletChartController : Controller
    {
        public IActionResult Legend()
        {
            List<LegendData> bulletData1 = new List<LegendData>
            {
                new LegendData { value = 25, target = new double[]{ 20, 26, 28 } }
            };
            ViewBag.dataSource = bulletData1;

            return View();
        }
        public class LegendData
        {
            public double value;
            public double[] target;
        }
    }
}