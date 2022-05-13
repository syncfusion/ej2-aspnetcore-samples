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
        public IActionResult DropDowns()
        {
            ViewBag.dropdownValue = "Canada";
            ViewBag.autoValue = "Australia";
            ViewBag.comboValue = "Finland";
            ViewBag.multiValue = new string[] {"Canada", "Bermuda" };
            string[] data = new string[] { "Australia", "Bermuda", "Canada", "Cameroon", "Denmark", "Finland", "Greenland", "Poland" };
            ViewBag.popupSettings = new  InPlaceEditorPopupSettings { Model = new { width= "auto" }  };
            ViewBag.multiSelectData = new { placeholder = "Choose the countries", dataSource = data, mode = "Box" };
            ViewBag.dropdownData = new { placeholder = "Find a country", dataSource = data };
            ViewBag.autocompleteData = new { placeholder = "Type to search country", dataSource = data };
            ViewBag.comboData = new { placeholder = "Find a country", dataSource = data };
            ViewBag.modeData = new string[] { "Inline", "Popup" };
            return View();
        }

    }
}
