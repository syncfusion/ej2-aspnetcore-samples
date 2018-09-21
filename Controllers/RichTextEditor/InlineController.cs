using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class RichtextEditorController : Controller
    {
        public IActionResult Inline()
        {
            ViewBag.items = new[] { "Bold", "Italic", "Underline",
                "Formats", "-", "Alignments", "OrderedList", "UnorderedList",
                "CreateLink" };
            ViewBag.width = new
            {
                width = "auto"
            };
            ViewBag.inlineMode = new
            {
                enable = true,
                onSelection = true
            };
            ViewBag.value = @"<p>The sample is configured with inline mode of editor. Initially, the editor is rendered without a 
                            <a href='http://npmci.syncfusion.com/development/demos/#/material/toolbar/default.html'>toolbar</a>. 
                            The toolbar becomes visible only when the content is selected.</p>";
            return View();
        }
    }
}
