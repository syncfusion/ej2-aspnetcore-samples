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
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class MultiselectValue
    {
        [Required(ErrorMessage = "Please enter a value")]
        public string[] val { get; set; }
        public string[] data { get; set; }
    }
    public partial class MultiSelectController : Controller
    {
        public string[] dataSource = new string[] { "American Football", "Badminton", "Basketball", "Cricket", "Football", "Golf", "Hockey", "Rugby", "Snooker", "Tennis" };

        public IActionResult MultiselectFor()
        {
            MultiselectValue model = new MultiselectValue();
            model.data = dataSource;
            return View(model);
        }
        [HttpPost]
        public IActionResult MultiselectFor(MultiselectValue model)
        {
            model.data = dataSource;
            model.val = model.val;
            return View(model);
        }
    }
}
