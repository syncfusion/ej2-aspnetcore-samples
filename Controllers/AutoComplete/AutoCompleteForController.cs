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
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public class AutoCompleteValue
    {
        [Required(ErrorMessage = "Please enter a value")]
        public string val { get; set; }
        public string[] data { get; set; }
    }
    public partial class AutoCompleteController : Controller
    {
		public string[] datasource = new string[] { "American Football", "Badminton", "Basketball", "Cricket", "Football", "Golf", "Hockey", "Rugby", "Snooker", "Tennis" };
        public IActionResult AutoCompleteFor()
        {
            AutoCompleteValue model = new AutoCompleteValue();
            model.data = datasource;
            return View(model);
        }
		[HttpPost]
		public IActionResult AutoCompleteFor(AutoCompleteValue model)
        {
            model.data = datasource;
            model.val = model.val;
            return View(model);
        }
    }
}
