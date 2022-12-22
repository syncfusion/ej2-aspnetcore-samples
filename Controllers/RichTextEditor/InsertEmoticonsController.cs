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
using Syncfusion.EJ2.Navigations;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RichtextEditorController : Controller
    {
        public IActionResult InsertEmoticons()
        {
            ViewBag.headerTextOne = new TabHeader { Text = "&#128578;" };
            ViewBag.headerTextTwo = new TabHeader { Text = "&#128053;" };

            var tools = new
            {
                tooltipText = "Insert Emoticons",
                template = "<button class='e-tbar-btn e-btn' tabindex='-1' id='emot_tbar'  style='width:100%'><div class='e-tbar-btn-text rtecustomtool' style='font-weight: 500;'> &#128578;</div></button>"
            };

            ViewBag.items = new object[] { "Bold", "Italic", "Underline", "|", "Formats", "Alignments", "OrderedList",
                "UnorderedList", "|", "CreateLink", "Image", "|", "SourceCode", tools
                , "|", "Undo", "Redo"
            };
            ViewBag.insertBtn = new
            {
                content = "Insert",
                isPrimary = true
            };
            ViewBag.cancelBtn = new
            {
                content = "Cancel"
            };

            return View();
        }
    }
}
