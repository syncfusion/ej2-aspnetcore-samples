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

        public IActionResult LineZone()
        {
            List<ChartSegment> segments = new List<ChartSegment>();
            ChartSegment segment1 = new ChartSegment();
            segment1.Value = 450;
            segment1.Color = "red";
            segments.Add(segment1);

            ChartSegment segment2 = new ChartSegment();
            segment2.Value = 500;
            segment2.Color = "green";
            segments.Add(segment2);

            ChartSegment segment3 = new ChartSegment();
            segment3.Color = "blue";
            segments.Add(segment3);

            ViewBag.segment = segments;
            return View();
        }
    }
}
