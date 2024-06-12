#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;
using System.Collections.Generic;


namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class ScheduleController : Controller
    {

        public IActionResult Print()
        {
            ViewBag.appointments = new ScheduleData().GetScheduleData();
            ViewBag.printHeightAndWidthData = new List<string> { "auto", "100%", "500px" };
            return View();
        }
    }
}