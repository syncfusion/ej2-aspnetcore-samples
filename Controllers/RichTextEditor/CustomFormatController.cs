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
        public IActionResult CustomFormat()
        {
            ViewBag.value = @"The sample is configured with customized markdown syntax using the __formatter__ property. Type the content and click the toolbar item to view customized markdown syntax. For unordered list, 
                you need to add a plus sign before the word (e.g., + list1). Or To make a phrase bold,you need to add two underscores before and after the phrase (e.g., __this text is bold__).";
            ViewBag.items = new object[] {"Bold", "Italic", "StrikeThrough", "|",
                "Formats", "OrderedList", "UnorderedList", "|",
                "CreateLink", "Image", "|",
                new {
                tooltipText= "Preview",
                    template= @"<button id='preview-code' class='e-tbar-btn e-control e-btn e-icon-btn'>
                        <span class='e-btn-icon e-icons e-md-preview'></span></button>"
                }, "Undo", "Redo"};
            return View();
        }
    }
}
