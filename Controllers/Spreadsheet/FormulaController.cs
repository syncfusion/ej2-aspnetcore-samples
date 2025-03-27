#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        public IActionResult Formula()
        {
            List<object> formulaData = new List<object>()
            {
                new { Date= "08-01-2019", Open= "2625.75", Close= "2640.75", High= "2634.45", Low= "2620.65", Profit= "=C2-B2" },
                new { Date= "08-02-2019", Open= "2640.75", Close= "2638.75", High= "2640.75", Low= "2638.75", Profit= "=C3-B3" },
                new { Date= "08-03-2019", Open= "2638.75", Close= "2697.65", High= "2690.25", Low= "2647.65", Profit= "=C4-B4" },
                new { Date= "08-04-2019", Open= "2697.65", Close= "2700.25", High= "2699.21", Low= "2585.10", Profit= "=C5-B5" },
                new { Date= "08-05-2019", Open= "2700.25", Close= "2730.25", High= "2727.65", Low= "2704.95", Profit= "=C6-B6" },
                new { Date= "08-06-2019", Open= "2730.25", Close= "2725.25", High= "2727.45", Low= "2725.67", Profit= "=C7-B7" },
                new { Date= "08-07-2019", Open= "2725.25", Close= "2778.75", High= "2770.45", Low= "2730.60", Profit= "=C8-B8" },
                new { Date= "08-08-2019", Open= "2778.75", Close= "2800.67", High= "2790.27", Low= "2780.78", Profit= "=C9-B9" },
                new { Date= "08-09-2019", Open= "2800.67", Close= "2840.80", High= "2838.78", Low= "2827.78", Profit= "=C10-B10" },
                new { Date= "08-10-2019", Open= "2840.80", Close= "2865.35", High= "2863.30", Low= "2850.20", Profit= "=C11-B11" }
            };
            ViewData["formulaData"] = formulaData;
            return View();
        }
    }
}