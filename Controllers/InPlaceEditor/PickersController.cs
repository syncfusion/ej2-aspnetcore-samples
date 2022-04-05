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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class InPlaceEditorController : Controller
    {
        public IActionResult Pickers()
        {
            ViewBag.dateData = new { placeholder = "Select a date" };
            ViewBag.timeData = new { placeholder = "Select a time" };
            ViewBag.dateTimeData = new { placeholder = "Select a date and time" };
            ViewBag.dateRangeData = new { placeholder = "Select a date range" };
            ViewBag.dateRangeValue =new DateTime[2] { new DateTime(2017, 05, 23), new DateTime(2017, 07, 05) };
            ViewBag.dateValue =new DateTime(2017, 05, 23);
            ViewBag.modeData = new string[] { "Inline", "Popup" };
            return View();
        }
    }
}
