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
using Syncfusion.EJ2.InPlaceEditor;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class InPlaceEditorController : Controller
    {
 
        public IActionResult DefaultFunctionalities()
        {
            ViewBag.textValue = "Andrew";
            ViewBag.textModel = new { placeholder = "Enter employee name" };
            ViewBag.textPopupSettings = new InPlaceEditorPopupSettings  { Title = "Enter Employee Name" };
            ViewBag.numericValue = "$100.00";
            ViewBag.numericModel = new { placeholder = "Currency format", value = 100, format = "c2" };
            ViewBag.maskedModel = new { mask = "000-000-0000" };
            ViewBag.maskValue = "012-345-6789";
            ViewBag.modeData = new string[] { "Inline", "Popup" };
            ViewBag.editableData = new string[] { "Click", "Double Click", "Edit Icon Click" };
            return View();
        }
    }
}
