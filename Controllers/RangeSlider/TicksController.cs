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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers.Button
{
    public partial class RangeSliderController : Controller
    {
        public IActionResult Ticks()
        {
            List<object> placement = new List<object>();
            placement.Add(new { value = "Before", text = "Before" });
            placement.Add(new { value = "After", text = "After" });
            placement.Add(new { value = "Both", text = "Both" });
            placement.Add(new { value = "None", text = "None" });
            ViewBag.rangeValue = new int[] { 30, 70 };
            ViewBag.placement = placement;
            return View();
        }
    }
}




