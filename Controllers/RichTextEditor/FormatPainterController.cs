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
using EJ2CoreSampleBrowser.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJ2CoreSampleBrowser.Controllers.RichTextEditor
{
    public partial class RichTextEditorController : Controller
    {
        // GET: /<controller>/
        public IActionResult FormatPainter()
        {
            ViewBag.Items = new object[] {"FormatPainter", "Bold", "Italic", "Underline", "StrikeThrough", "SuperScript", "SubScript", "|",
                "FontName", "FontSize", "FontColor", "BackgroundColor",
                "LowerCase", "UpperCase", "|",
                "Formats", "Alignments", "|", "OrderedList", "UnorderedList", "|",
                "Outdent", "Indent", "|",
                "CreateLink", "Image", "Video", "Audio", "CreateTable", "|",
                "SourceCode", "Undo", "Redo"};
            return View();
        }
    }
}
