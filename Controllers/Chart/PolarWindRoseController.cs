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

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult PolarWindRose()
        {
            List<PolarWindRoseData> ChartPoints = new List<PolarWindRoseData>
            {
                  new PolarWindRoseData { XValue = "N", YValue= 1, YValue1= 0.8, YValue2= 0.8, YValue3= 0.3, YValue4= 0.2, YValue5= 0.2 },
                  new PolarWindRoseData { XValue = "NNE", YValue= 0.9, YValue1= 0.7, YValue2= 0.7, YValue3= 0.3, YValue4= 0.2, YValue5= 0.2 },
                  new PolarWindRoseData { XValue = "NE", YValue= 0.7, YValue1= 0.8, YValue2= 0.5, YValue3= 1.1, YValue4= 1.2, YValue5= 0.5 },
                  new PolarWindRoseData { XValue = "ENE", YValue= 0.9, YValue1= 1, YValue2= 0.4, YValue3= 0.9, YValue4= 1, YValue5= 0.4 },
                  new PolarWindRoseData { XValue = "E", YValue= 0.9, YValue1= 0.6, YValue2= 0.9, YValue3= 0.5, YValue4= 0.7, YValue5= 0.4 },
                  new PolarWindRoseData { XValue = "ESE", YValue= 0.8, YValue1= 0.5, YValue2= 0.7, YValue3= 0.3, YValue4= 0.8, YValue5= 0.3 },
                  new PolarWindRoseData { XValue = "SE", YValue= 0.7, YValue1= 0.4, YValue2= 0.6, YValue3= 0.5, YValue4= 0.5, YValue5= 0.3 },
                  new PolarWindRoseData { XValue = "SSE", YValue= 1.4, YValue1= 0.4, YValue2= 0.5, YValue3= 0.4, YValue4= 0.6, YValue5= 0.2 },
                  new PolarWindRoseData { XValue = "S", YValue= 2, YValue1= 1.2, YValue2= 0.6, YValue3= 0.6, YValue4= 0.4, YValue5= 0.4 },
                  new PolarWindRoseData { XValue = "SSW", YValue= 2, YValue1= 2.5, YValue2= 2, YValue3= 1, YValue4= 0.5, YValue5= 0.3 },
                  new PolarWindRoseData { XValue = "SW", YValue= 2.2, YValue1= 2, YValue2= 1.8, YValue3= 1, YValue4= 0.4, YValue5= 0.2 },
                  new PolarWindRoseData { XValue = "WSW", YValue= 1.8, YValue1= 1.1, YValue2= 0.8, YValue3= 0.1, YValue4= 0.4, YValue5= 0.2 },
                  new PolarWindRoseData { XValue = "W", YValue= 1.6, YValue1= 1.8, YValue2= 2.1, YValue3= 1, YValue4= 0.4, YValue5= 0.4 },
                  new PolarWindRoseData { XValue = "WNW", YValue= 1.2, YValue1= 1.2, YValue2= 1.5, YValue3= 1.3, YValue4= 1.1, YValue5= 1.2 },
                  new PolarWindRoseData { XValue = "NW", YValue= 2, YValue1= 2.5, YValue2= 2, YValue3= 1, YValue4= 0.2, YValue5= 0.7 },
                  new PolarWindRoseData { XValue = "NNW", YValue= 1.8, YValue1= 1.1, YValue2= 0.8, YValue3= 0.1, YValue4= 0.4, YValue5= 0.2 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class PolarWindRoseData
        {
            public string XValue;
            public double YValue;
            public double YValue1;
            public double YValue2;
            public double YValue3;
            public double YValue4;
            public double YValue5;
        }
    }
}