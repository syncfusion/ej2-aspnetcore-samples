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
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class MultiSelectController : Controller
    {
        public IActionResult ChipCustomization()
        {
            ViewBag.data = new ColorsData().GetColorsData();
            ViewBag.val = new string[] { "#2F5D81", "#D44FA3", "#4CD242", "#FE2A00", "#75523C"};
            return View();
        }
    }
}