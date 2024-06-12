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
        public IActionResult DataLabelTemplate()
        {
            List<TemplateData> PopulationDetails = new List<TemplateData>
            {
                new TemplateData { Sports= "Tennis", Boys= 50, Girls= 38 },
                new TemplateData { Sports= "Badminton", Boys= 30, Girls= 40 },
                new TemplateData { Sports= "Cycling", Boys= 37, Girls= 20 },
                new TemplateData { Sports= "Football", Boys= 60, Girls= 21 },
                new TemplateData { Sports= "Hockey", Boys= 15, Girls= 8 }
            };
            ViewBag.PopulationDetails = PopulationDetails;
            ViewBag.margin = new { Right = 30 };
            ViewBag.margin1 = new { Right = 15 };
            return View();
        }
        public class TemplateData
        {
            public string Sports;
            public double Boys;
            public double Girls;
        }
    }
}