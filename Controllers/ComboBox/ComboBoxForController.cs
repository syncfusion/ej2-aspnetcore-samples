#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class ComboBoxValue
    {
        [Required(ErrorMessage = "Please enter a value")]
        public string val { get; set; }
        public string[] data { get; set; }
    }
    public partial class ComboBoxController : Controller
    {
        public string[] dataSource = new string[] { "American Football", "Badminton", "Basketball", "Cricket", "Football", "Golf", "Hockey", "Rugby", "Snooker", "Tennis" };

        public IActionResult ComboBoxFor()
        {
            ComboBoxValue model = new ComboBoxValue();
            model.data = dataSource;
            return View(model);
        }
        [HttpPost]
        public IActionResult ComboBoxFor(ComboBoxValue model)
        {
            model.data = dataSource;
            model.val = model.val;
            return View(model);
        }
    }
}
