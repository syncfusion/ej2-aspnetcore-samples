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

namespace EJ2CoreSampleBrowser.Controllers.Splitter
{
    public partial class SplitterController : Controller
    {
        public IActionResult AccordionMenu()
        {
			List<object> data = new List<object>();
            data.Add(new { text = "Grid", id = "1" });
            data.Add(new { text = "Schedule", id = "2" });
            data.Add(new { text = "Chart", id = "7" });
            ViewBag.dataSource1 = data;

            List<object> data1 = new List<object>();
            data.Add(new { text = "Grid", id = "3" });
            data.Add(new { text = "Schedule", id = "4" });
            data.Add(new { text = "Chart", id = "8" });
            ViewBag.dataSource2 = data1;

            List<object> data2 = new List<object>();
            data.Add(new { text = "Grid", id = "5" });
            data.Add(new { text = "Schedule", id = "6" });
            data.Add(new { text = "Chart", id = "9" });
            ViewBag.dataSource3 = data2;

            return View();
        }
    }
}