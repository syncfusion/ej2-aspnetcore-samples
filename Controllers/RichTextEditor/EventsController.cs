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

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RichTextEditorController : Controller
    {
        public IActionResult Events()
        {
            ViewBag.items = new[] { "Bold", "Italic", "Underline", "StrikeThrough", "SuperScript", "SubScript", "|",
                "FontName", "FontSize", "FontColor", "BackgroundColor",  "|",
                "LowerCase", "UpperCase",
                "Formats", "Alignments", "|", "NumberFormatList", "BulletFormatList", "|",
                "Outdent", "Indent", "|",
                "CreateLink", "Image", "FileManager", "Video", "Audio", "CreateTable", "|", "FormatPainter", "ClearFormat", "|", "EmojiPicker", "Print", "|",
                "SourceCode", "FullScreen", "|", "Undo", "Redo"};
            return View();
        }
    }
}