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


namespace EJ2CoreSampleBrowser.Controllers.Barcode
{
    public partial class BarcodeController : Controller
    {
        public IActionResult code93()
        {
            List<ExpandOptions> position = new List<ExpandOptions>();
            position.Add(new ExpandOptions() { text = "Bottom", value = "bottom" });
            position.Add(new ExpandOptions() { text = "Top", value = "top" });

            ViewBag.position = position;
            ViewBag.expandValue = "Bottom";
            List<alignment> align = new List<alignment>();
            align.Add(new alignment() { text = "Left", value = "left" });
            align.Add(new alignment() { text = "Right", value = "right" });
            align.Add(new alignment() { text = "Center", value = "center" });

            ViewBag.align = align;
            ViewBag.alignmentValue = "Center";
            return View();
        }

    }
}