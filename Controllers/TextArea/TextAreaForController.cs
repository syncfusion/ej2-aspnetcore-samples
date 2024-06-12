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

namespace EJ2CoreSampleBrowser.Controllers.TextArea
{
    public class TextAreaValue
    {
        [Required(ErrorMessage = "Value is required")]
        public string comments { get; set; }
    }
    public partial class TextAreaController : Controller
    {
        TextAreaValue textarea = new TextAreaValue();
        // GET: TextAreaFor
        public IActionResult TextAreaFor()
        {
            textarea.comments = "";
            return View(textarea);
        }
        [HttpPost]

        public IActionResult TextAreaFor(TextAreaValue model)
        {
            //posted value is obtained from the model
            textarea.comments = model.comments;
            return View(textarea);
        }
    }
}