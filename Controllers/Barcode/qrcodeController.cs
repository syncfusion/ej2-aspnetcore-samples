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
        public IActionResult qrcode()
        {
            List<coorectionLevel> level = new List<coorectionLevel>();
            level.Add(new coorectionLevel() { text = "Low", value = "7" });
            level.Add(new coorectionLevel() { text = "Medium", value = "15" });
            level.Add(new coorectionLevel() { text = "Quartile", value = "25" });
            level.Add(new coorectionLevel() { text = "High", value = "30" });
            ViewBag.level = level;
            ViewBag.value = "Medium";
         
            return View();
        }

    }
    public class coorectionLevel
    {
        public string text;
        public string value;
    }
}