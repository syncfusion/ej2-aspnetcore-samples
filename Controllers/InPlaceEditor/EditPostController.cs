using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.InPlaceEditor;

namespace EJ2CoreSampleBrowser.Controllers
{
    public partial class InPlaceEditorController : Controller
    {
        public IActionResult EditPost()
        {
            ViewBag.titleValue = "Succinctly E-Book about TypeScript";
            ViewBag.commentValue = "The extensive adoption of JavaScript for application development, and the ability to use HTML and JavaScript to create Windows Store apps, has made JavaScript a vital part of the Windows development ecosystem. Microsoft has done extensive work to make JavaScript easier to use.";
            ViewBag.popupSettings = new InPlaceEditorPopupSettings { Model = new { width = "document.querySelector('#inplace-editor-control.form-layout ').offsetWidth" } };
            ViewBag.tagValue = new string[] { "TypeScript", "JavaScript" };
            string[] data = new string[] { "Android", "JavaScript", "jQuery", "TypeScript", "Angular", "React", "Vue", "Ionic" };
            ViewBag.tagData = new { mode = "Box", dataSource = data, placeholder = "Enter your tags" };
            ViewBag.tagPopup = new InPlaceEditorPopupSettings { Model = new { width= "auto" }  };
            string[] validation1 = new string[] { "true", "Enter valid tags" };
            ViewBag.tagValidation = new { Tag = new { required = validation1 } };
            string[] validation2 = new string[] { "true", "Enter valid title" };
            ViewBag.titleValidation = new { Title = new { required = validation2 } };
            ViewBag.titleData = new { placeHolder = "Enter your question title" };
            string[] rteItems = new string[] { "Bold", "Italic", "Underline", "FontColor", "BackgroundColor", "LowerCase", "UpperCase", "|", "OrderedList", "UnorderedList" };
            ViewBag.commentData = new { toolbarSettings = new { enableFloating = false, items = rteItems } };
            string[] validation3 = new string[] { "true", "Enter valid comments" };
            ViewBag.commentValidation = new { rte = new { required = validation3 } };
            ViewBag.modeData = new string[] { "Inline", "Popup" };
            return View();
        }
    }
}
