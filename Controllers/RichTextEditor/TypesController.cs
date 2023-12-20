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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RichTextEditorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Types()
        {
            List<Data> datasource = new List<Data>();
            datasource.Add(new Data() { text = "Expand", value = 1 });
            datasource.Add(new Data() { text = "MultiRow", value = 2 });
            datasource.Add(new Data() { text = "Scrollable", value = 3 });
            ViewBag.data = datasource;
            ViewBag.items = new[] {"Bold", "Italic", "Underline", "StrikeThrough", "SuperScript", "SubScript", "|",
                "FontName", "FontSize", "FontColor", "BackgroundColor",  "|",
                "LowerCase", "UpperCase",
                "Formats", "Alignments", "|", "NumberFormatList", "BulletFormatList", "|",
                "Outdent", "Indent", "|",
                "CreateLink", "Image", "Video", "Audio", "CreateTable", "|", "FormatPainter", "ClearFormat", "|", "EmojiPicker", "Print", "|",
                "SourceCode", "FullScreen", "|", "Undo", "Redo"};
            return View();
        }
    }

    public class Data
    {
        public Data()
        {
        }

        public string text { get; set; }
        public int value { get; set; }
    }
}
