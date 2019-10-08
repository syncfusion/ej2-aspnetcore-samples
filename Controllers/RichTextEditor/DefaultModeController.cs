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
            var tool = new {
                tooltipText = "Preview",
                template = @"<button id='preview-code' class='e-tbar-btn e-control e-btn e-icon-btn'>
                        <span class='e-btn-icon e-md-preview e-icons'></span></button>"
            };
           ViewBag.items = new object[] {"Bold", "Italic", "StrikeThrough", "|",
                "Formats", "OrderedList", "UnorderedList", "Superscript", "Subscript", "|", "CreateTable",
                "CreateLink", "Image", "|", tool
                , "|", "Undo", "Redo"};
            return View();
        }
    }
}
