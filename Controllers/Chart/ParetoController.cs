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

namespace EJ2CoreSampleBrowser.Controllers.Chart
{
    public partial class ChartController : Controller
    {
        public IActionResult PareTo()
        {
            List<PareToData> ChartPoints = new List<PareToData>
            {
                new PareToData { DefectCategory = "Button Defect", Y = 23 },
                new PareToData { DefectCategory = "Pocket Defect", Y = 16 },
                new PareToData { DefectCategory = "Collar Defect", Y = 10 },
                new PareToData { DefectCategory = "Cuff Defect", Y = 7 },
                new PareToData { DefectCategory = "Sleeve Defect", Y = 6 },
                new PareToData { DefectCategory = "Other Defect", Y = 2 }
            };
            ViewBag.ChartPoints = ChartPoints;
            return View();
        }
        public class PareToData
        {
            public string DefectCategory;
            public double Y;
        }
    }
}