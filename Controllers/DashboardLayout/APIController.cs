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

namespace EJ2CoreSampleBrowser.Controllers
{
    public class ModelSpace
    {
        public double[] cellSpacing { get; set; }

    }
    public partial class DashboardLayoutController : Controller
    {
        public IActionResult API()
        {
            ModelSpace modelValue = new ModelSpace();
            modelValue.cellSpacing = new double[] { 10, 10 };
            return View(modelValue);
        }
    }
}