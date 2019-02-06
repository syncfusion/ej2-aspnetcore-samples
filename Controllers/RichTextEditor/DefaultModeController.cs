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
        public IActionResult DefaultMode()
        {
            ViewBag.value = @"The sample is added to showcase **markdown editing**.

Type or edit the content and apply formatting to view markdown formatted content.

We can add our own custom formation syntax for the Markdown formation, [sample link](http://npmci.syncfusion.com/development/demos/#/material/rte/markdown-editor-custom-format.html).

The third-party library <b>Marked</b> is used in this sample to convert markdown into HTML content";
            var tool = new {
                tooltipText = "Preview",
                template = @"<button id='preview-code' class='e-tbar-btn e-control e-btn e-icon-btn'>
                        <span class='e-btn-icon e-md-preview e-icons'></span></button>"
            };
            ViewBag.items = new object[] {"Bold", "Italic", "StrikeThrough", "|",
                "Formats", "OrderedList", "UnorderedList", "|", "CreateTable",
                "CreateLink", "Image", "|", tool
                , "|", "Undo", "Redo"};
            return View();
        }
    }
}
