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

        public IActionResult AxisCrossing()
        {

            List<AxisData> scatterData = new List<AxisData>
            {
                new AxisData { xValue = -6, yValue1 = 2},
                new AxisData { xValue = -3, yValue1 = -4 },
                new AxisData { xValue = 1.5, yValue1 = 3.5 },
                new AxisData { xValue = 6, yValue1 = 4.5},

                            };

            List<AxisData> splineData = new List<AxisData>
            {
                new AxisData { xValue = -6, yValue1 = 2},
                new AxisData { xValue = -5.291, yValue1 = 0.1 },
                new AxisData { xValue = -5, yValue1 = -0.77},
                new AxisData { xValue = -3, yValue1 = -4},
                new AxisData { xValue = -0.6, yValue1 = -0.965},
                new AxisData { xValue = -0.175, yValue1 = 0.1},
                new AxisData { xValue = 0.1, yValue1 = 0.404},
                new AxisData { xValue = 1.5, yValue1 = 3.5},
                new AxisData { xValue = 3.863, yValue1 = 5.163},
                new AxisData { xValue = 6, yValue1 = 4.5},

                            };

            List<AxisData> lineData = new List<AxisData>
            {
                new AxisData { xValue = -6, yValue1 = 2},
                new AxisData { xValue = -5, yValue1 = 0.1 },
                new AxisData { xValue = -4.511, yValue1 = -0.977},
                new AxisData { xValue = -3, yValue1 = -4},
                new AxisData { xValue = -1.348, yValue1 = -1.247},
                new AxisData { xValue = -0.6, yValue1 = 0.11},
                new AxisData { xValue = 0.1, yValue1 = 1},
                new AxisData { xValue = 1.5, yValue1 = 3.5},
                new AxisData { xValue = 6, yValue1 = 4.5},

                            };
            ViewBag.scatter = scatterData;
            ViewBag.spline = splineData;
            ViewBag.line = lineData;
            ViewBag.axis = new String[] { "xAxis", "yAxis" };
            return View();
        }

        public class AxisData
        {
            public Nullable<double> xValue;
            public Nullable<double> yValue1;
           
        }
    }
}
