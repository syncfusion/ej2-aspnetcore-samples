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
using System.ComponentModel.DataAnnotations;

namespace EJ2CoreSampleBrowser.Controllers.TextBoxes
{
    public class TextBoxValue
    {
        [Required(ErrorMessage = "Value is required")]
        public string firstname { get; set; }
    }
    public partial class TextBoxesController : Controller
    {
        TextBoxValue textbox = new TextBoxValue();
        public IActionResult TextboxFor()
        {
            textbox.firstname = "John";
            return View(textbox);
        }
        [HttpPost]

        public IActionResult TextboxFor(TextBoxValue model)
        {
            textbox.firstname = model.firstname;
            return View(textbox);
        }
    }
}